using CommunityToolkit.Mvvm.Messaging.Messages;
using Globalmantics.Domain;

namespace Globomantics.Windows.Messages;

public class TodoDeleteMessage : ValueChangedMessage<ToDo>
{
    public TodoDeleteMessage(ToDo value) : base(value)
    {
    }
}