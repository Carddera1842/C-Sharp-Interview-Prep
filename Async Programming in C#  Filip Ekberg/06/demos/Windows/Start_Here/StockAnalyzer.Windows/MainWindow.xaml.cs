using Newtonsoft.Json;
using StockAnalyzer.Core;
using StockAnalyzer.Core.Domain;
using StockAnalyzer.Core.Services;
using StockAnalyzer.Windows.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace StockAnalyzer.Windows;

public partial class MainWindow : Window
{
    private static string API_URL = "https://ps-async.fekberg.com/api/stocks";
    private Stopwatch stopwatch = new Stopwatch();

    public MainWindow()
    {
        InitializeComponent();
    }


    CancellationTokenSource? cancellationTokenSource;

    private async Task Search_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            BeforeLoadingStockData();
            var progress = new Progress<IEnumerable<StockPrice>>(); 

            progress.ProgressChanged += (_, stocks) =>
            {
                StockProgress.Value += 1;
                Notes.Text += $"Loaded {stocks.Count()} for {stocks.First().Identifier}{Environment.NewLine}";
            };
            await SearchForStocks(progress);
        }
        catch(Exception ex)
        {
            Notes.Text = ex.Message;
        }
        finally
        {
            AfterLoadingStockData();
        }
        
    }

    private async Task SearchForStocks(IProgress<IEnumerable<StockPrice>> progress)
    {
        var service = new StockService();
        var loadingTasks = new List<Task<IEnumerable<StockPrice>>>();

        foreach(var identifier in StockIdentifier.Text.Split(' ', ','))
        {
            var loadTask = service.GetStockPricesFor(identifier,
                CancellationToken.None);

            loadTask = loadTask.ContinueWith(completedTask =>
            {
                progress?.Report(completedTask.Result);

                return completedTask.Result;
            });

            loadingTasks.Add(loadTask);
        }

        var data = await Task.WhenAll(loadingTasks);

        Stocks.ItemsSource = data.SelectMany(stock => stock);
    }


    private async Task<IEnumerable<StockPrice>>
        GetStocksFor(string identifier)
    {
        var service = new StockService();
        var data = await service.GetStockPricesFor(identifier,
            CancellationToken.None).ConfigureAwait(false);

        return data.Take(5);
    }

    private static Task<IEnumerable<StockPrice>> SearchForStocks(
        CancellationToken cancellationToken    
    )
    {
        var tcs = new TaskCompletionSource<IEnumerable<StockPrice>>();  

        ThreadPool.QueueUserWorkItem(_ =>
        {
            var lines = File.ReadAllLines("StockPrices_Small.csv");
            var prices = new List<StockPrice>();

            foreach (var line in lines.Skip(1))
            {
                prices.Add(StockPrice.FromCSV(line));
            }

            //TODO: Communicate the reslut of 'prices' ?
            tcs.SetResult(prices);
        });
        //TODO: retrn a Task<IEnumerablt<StockPrice>> ?

        return tcs.Task;
    }

    private async Task GetStocks()
    {
        try
        {
            var store = new DataStore();

            var responseTask = store.GetStockPrices(StockIdentifier.Text);

            Stocks.ItemsSource = await responseTask;
        }
        catch (Exception ex)
        {
            throw;
        }
    }















    private void BeforeLoadingStockData()
    {
        stopwatch.Restart();
        StockProgress.Visibility = Visibility.Visible;
        StockProgress.IsIndeterminate = false;
        StockProgress.Value = 0;
        StockProgress.Maximum = StockIdentifier.Text.Split(',', ' ').Length;
    }

    private void AfterLoadingStockData()
    {
        StocksStatus.Text = $"Loaded stocks for {StockIdentifier.Text} in {stopwatch.ElapsedMilliseconds}ms";
        StockProgress.Visibility = Visibility.Hidden;
    }

    private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = e.Uri.AbsoluteUri, UseShellExecute = true });

        e.Handled = true;
    }

    private void Close_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}