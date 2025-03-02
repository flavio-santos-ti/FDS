namespace FDS.NetCore.ApiResponse.Types;

/// <summary>
/// Represents an action type used to categorize API responses.
/// </summary>
public sealed class ActionType
{
    /// <summary>
    /// Gets the value of the action type.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Prevents external instantiation, ensuring controlled usage of predefined instances.
    /// </summary>
    /// <param name="value">The string representation of the action type.</param>
    // Makes the class impossible to instantiate externally.
    private ActionType(string value) => Value = value;

    // Predefined instances (simulating an enum-like behavior).

    /// <summary>Indicates a create operation.</summary>
    public static readonly ActionType CREATE = new("CREATE");

    /// <summary>Indicates a create operation with file upload.</summary>
    public static readonly ActionType CREATE_UPLOAD = new("CREATE_UPLOAD");

    /// <summary>Indicates a create operation during login.</summary>
    public static readonly ActionType CREATE_LOGIN = new("CREATE_LOGIN");

    /// <summary>Indicates a delete operation.</summary>
    public static readonly ActionType DELETE = new("DELETE");

    /// <summary>Indicates an error occurred.</summary>
    public static readonly ActionType ERROR = new("ERROR");

    /// <summary>Indicates a not found response.</summary>
    public static readonly ActionType NOT_FOUND = new("NOT_FOUND");

    /// <summary>Indicates an update operation.</summary>
    public static readonly ActionType UPDATE = new("UPDATE");

    /// <summary>Indicates a successful login.</summary>
    public static readonly ActionType LOGIN_SUCCESS = new("LOGIN_SUCCESS");

    /// <summary>Indicates a validation error.</summary>
    public static readonly ActionType VALIDATION_ERROR = new("VALIDATION_ERROR");

    /// <summary>Indicates a read operation.</summary>
    public static readonly ActionType READ = new("READ");


    /// <summary>
    /// Returns the string representation of the action type.
    /// </summary>
    /// <returns>The string value of the action type.</returns>
    public override string ToString() => Value;
}
