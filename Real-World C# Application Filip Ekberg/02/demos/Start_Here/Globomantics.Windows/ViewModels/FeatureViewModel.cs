using CommunityToolkit.Mvvm.Input;
using Globalmantics.Domain;
using Globalmantics.Infrastructure.Data.Repositories;
using System.Threading.Tasks;

namespace Globomantics.Windows.ViewModels;

internal class FeatureViewModel : BaseTodoViewModel<Feature>
{
    private readonly IRepository<Feature> repository;

    private string? description;
    public string? Description
    {
        get => description;
        set
        {
            description = value;
            OnPropertyChanged(nameof(Description));
        }
    }
    public FeatureViewModel(IRepository<Feature> repository) : base()
    {
        this.repository = repository;

        SaveCommand = new RelayCommand(async () => await SaveAsync());
    }
    public override async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            ShowError?.Invoke($"{nameof(Title)} cannot be empty");

            return;
        }

        if (Model is null)
        {
            Model = new Feature(Title, Description, "UI?", 1,
                                App.CurrentUser, App.CurrentUser)
            {
                DueDate = System.DateTimeOffset.Now.AddDays(10),
                Parent = Parent,
                IsCompleted = IsCompleted
            };
        }
        else
        {
            Model = Model with
            {
                Title = Title,
                Description = Description,
                Parent = Parent,
                IsCompleted = IsCompleted
            };
        }

        await repository.AddAsync(Model);
        await repository.SaveChangesAsync();

        //TODO: send message that the item is saved

    }

    public override void UpdateModel(ToDo model)
    {
        if (Model is not Feature feature) return;

        base.UpdateModel(feature);

        Description = feature.Description;
    }
}
