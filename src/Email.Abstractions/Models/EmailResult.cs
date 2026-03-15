namespace Email.Abstractions;

/// <summary>
/// Result of an email send operation.
/// </summary>
public sealed record EmailResult
{
  /// <summary>
  /// Whether the email was sent successfully.
  /// </summary>
  public required bool IsSuccess { get; init; }

  /// <summary>
  /// Error message when IsSuccess is false.
  /// </summary>
  public string? ErrorMessage { get; init; }

  /// <summary>
  /// Creates a successful result.
  /// </summary>
  public static EmailResult Success() => new() { IsSuccess = true };

  /// <summary>
  /// Creates a failure result with the given error message.
  /// </summary>
  /// <param name="errorMessage">Description of what went wrong.</param>
  public static EmailResult Failure(string errorMessage) =>
    new() { IsSuccess = false, ErrorMessage = errorMessage };
}
