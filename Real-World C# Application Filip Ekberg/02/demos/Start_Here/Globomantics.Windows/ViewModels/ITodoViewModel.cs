using Globalmantics.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Globomantics.Windows.ViewModels;

public interface ITodoViewModel : IViewModel
{
    IEnumerable<ToDo>?  AvailableParentTasks { get; set; }
    ICommand DeleteCommand { get; }
    ICommand SaveCommand { get; set; } 
    Task SaveAsync();
    void UpdateModel(ToDo model);
}
