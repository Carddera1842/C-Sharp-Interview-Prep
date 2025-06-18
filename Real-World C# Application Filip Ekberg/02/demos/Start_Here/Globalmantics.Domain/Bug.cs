namespace Globalmantics.Domain;

public record Bug(string Title,
                  string Description,
                  Severity Severity,
                  string AffectedVersion,
                  int AffectedUsers,
                  User CreatedBy,
                  User? AssignedTo,
                  IEnumerable<byte[]> Images)
    : ToDoTask(Title, DateTimeOffset.MinValue, CreatedBy);
