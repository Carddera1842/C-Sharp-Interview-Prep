using CommunityToolkit.Mvvm.Messaging.Messages;
using Globalmantics.Domain;

namespace Globomantics.Windows.Messages;

public class TodoSavedMessage : ValueChangedMessage<ToDo>
{
    public TodoSavedMessage(ToDo value) : base(value)
    {
    }
}
