namespace FDS.DbLogger.PostgreSQL.Published;

/// <summary>
/// Represents different types of log actions that can be recorded.
/// </summary>
public sealed class LogActionType
{
    /// <summary>
    /// Gets the string value of the log action type.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Private constructor to ensure controlled instantiation.
    /// </summary>
    /// <param name="value">The string representation of the log action type.</param>
    private LogActionType(string value) => Value = value;

    /// <summary>
    /// Represents an informational log event.
    /// Used for general messages about application flow.
    /// </summary>
    public static readonly LogActionType INFO = new("INFO");

    /// <summary>
    /// Represents a validation error log event.
    /// Used when a request fails due to invalid input or business rules.
    /// </summary>
    public static readonly LogActionType VALIDATION_ERROR = new("VALIDATION_ERROR");

    /// <summary>
    /// Represents an error log event.
    /// Used for exceptions, failures, or critical issues that affect functionality.
    /// </summary>
    public static readonly LogActionType ERROR = new("ERROR");

    /// <summary>
    /// Represents a "not found" log event.
    /// Used when a requested resource does not exist in the system.
    /// </summary>
    public static readonly LogActionType NOT_FOUND = new("NOT_FOUND");

    /// <summary>
    /// Represents an update log event.
    /// Used when an existing record is modified in the system.
    /// </summary>
    public static readonly LogActionType UPDATE = new("UPDATE");


    /// <summary>
    /// Represents a read log event.
    /// Used when a data retrieval operation is performed, such as GetAll or GetById.
    /// </summary>
    public static readonly LogActionType READ = new("READ");

    /// <summary>
    /// Represents a create log event.
    /// Used when a new record is inserted into the database.
    /// </summary>
    public static readonly LogActionType CREATE = new("CREATE");

    /// <summary>
    /// Represents a user login event.
    /// Used when a user successfully logs into the system.
    /// </summary>
    public static readonly LogActionType CREATE_LOGIN = new("CREATE_LOGIN");

    /// <summary>
    /// Represents a successful user login event.
    /// Used when a user logs in successfully after authentication.
    /// </summary>
    public static readonly LogActionType LOGIN_SUCCESS = new("LOGIN_SUCCESS");

    /// <summary>
    /// Represents a file upload log event.
    /// Used when a file is successfully uploaded to cloud storage or a local server.
    /// </summary>
    public static readonly LogActionType CREATE_UPLOAD = new("CREATE_UPLOAD");

    /// <summary>
    /// Represents a delete log event.
    /// Used when a record is removed from the system.
    /// </summary>
    public static readonly LogActionType DELETE = new("DELETE");

    /// <summary>
    /// Returns the string representation of the log action type.
    /// </summary>
    /// <returns>The string value of the log action type.</returns>
    public override string ToString() => Value;
}
