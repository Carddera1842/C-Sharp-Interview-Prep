﻿namespace ConsoleCalculator;

public class CalculationOperationNotSupportedException : CalculationException
{
    private const string DefaultMessage = "Specified operation was " +
        "out of the range of valid values.";

    public string? Operation { get; }

    /// <summary>
    /// Creates a new <see cref="CalculationOperatonsNotSupportedException"/>
    /// witha predefined message.
    /// </summary>
    public CalculationOperationNotSupportedException() : base(DefaultMessage)
    {
    }

    /// <summary>
    /// Creates a new <see cref="CalculationOperatonsNotSupportedException"/>
    /// witha predefined message and a wrapped inner exception.
    /// </summary>
    public CalculationOperationNotSupportedException(Exception innerException)
        : base(DefaultMessage, innerException)
    {
    }

    /// <summary>
    /// Creates a new <see cref="CalculationOperatonsNotSupportedException"/>
    /// with a user-supplied message and a wrapped inner exception.
    /// </summary>
    public CalculationOperationNotSupportedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Creates a new <see cref="CalculationOperatonsNotSupportedException"/>
    /// with a default message and the operation that is not supported.
    /// </summary>
    public CalculationOperationNotSupportedException(string operation)
        : this() => Operation = operation;

    /// <summary>
    /// Creates a new <see cref="CalculationOperatonsNotSupportedException"/>
    /// with the operation and a user-supplied message.
    /// </summary>
    public CalculationOperationNotSupportedException(string operation, string message)
        : base(message) => Operation = operation;

    public override string Message
    {
        get
        {
            if (Operation is null)
            {
                return base.Message;
            }

            return base.Message + Environment.NewLine +
                $"Unsupported operation: {Operation}";
        }
    }


}
