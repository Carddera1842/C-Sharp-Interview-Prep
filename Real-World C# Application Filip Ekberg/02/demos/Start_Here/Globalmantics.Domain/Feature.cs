namespace Globalmantics.Domain;

public record Feature(string Title,
                      string Description,
                      string Component,
                      int Priority,
                      User CreatedBy,
                      User AssignedTo)
    : ToDoTask(Title, DateTimeOffset.MinValue, CreatedBy);
