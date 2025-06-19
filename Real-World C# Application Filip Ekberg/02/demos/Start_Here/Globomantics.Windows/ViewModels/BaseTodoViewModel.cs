using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Globalmantics.Domain;
using Globomantics.Windows.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Globomantics.Windows.ViewModels;

public abstract class BaseTodoViewModel<T> : ObservableObject, ITodoViewModel
    where T : ToDo
{
    private T? model;
    private string? title;
    private bool isCompleted;
    private ToDo? parent;

    public ToDo Parent
    {
        get => parent;
        set
        {
            parent = value;
            OnPropertyChanged(nameof(Title));
        }
    }
    public bool IsCompleted
    {
        get => isCompleted;
        set
        {
            isCompleted = value;
            OnPropertyChanged(nameof(isCompleted));
        }
    }
    public string Title
    {
        get => title;
        set
        {
            title = value;
            OnPropertyChanged(nameof(Title));
        }
    }
    public T? Model
    {
        get => model;
        set
        {
            model = value;
            OnPropertyChanged(nameof(Model));
            OnPropertyChanged(nameof(IsExisting));
        }
    }

    public bool IsExisting => Model is not null;

    #region From ITodoModel and IViewModel
    public IEnumerable<ToDo>? AvailableParentTasks { get; set; }

    public ICommand DeleteCommand { get; }

    public ICommand SaveCommand { get; set; } = default!;

    public Action<string>? ShowAlert { get; set; }
    public Action<string>? ShowError { get; set; }
    public Func<string>? ShowSaveFileDialog { get; set; }
    public Func<string, bool>? AskForConfirmation { get; set; }
    public Func<IEnumerable<string>>? ShowOpenFileDialog { get; set; }

    #endregion
    public abstract Task SaveAsync();
    

    public virtual void UpdateModel(ToDo model)
    {
        if (model is null)
        {
            return;
        }

        var parent = AvailableParentTasks?.SingleOrDefault(
            t => t.Parent is not null && t.Parent?.Id == model.Parent?.Id
        );

        Model = model as T;
        Title = model.Title;
        IsCompleted = model.IsCompleted;
        Parent = parent;
    }

    public BaseTodoViewModel()
    {
        DeleteCommand = new RelayCommand(() =>
        {
            if (Model is not null)
            {
                Model = Model with { IsDeleted = true };

                //TODO: Send message that Model is deleted
                WeakReferenceMessenger.Default.Send<TodoDeleteMessage>(new(Model));
            }
        });
    }
}


