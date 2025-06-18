using System.Reflection.Metadata;

namespace Globalmantics.Domain;

public abstract record ToDo(Guid id,
                            string Title,
                            DateTimeOffset CreatedDate,
                            User CreatedBy,
                            bool IsCompleted = false,
                            bool IsDeleted = false)
{
    public ToDo? Parent { get; init; }
}
