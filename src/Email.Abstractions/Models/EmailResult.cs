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
  /// Why the send failed, when it did — see <see cref="EmailFailureKind"/>.
  /// <see cref="EmailFailureKind.None"/> on success.
  /// </summary>
  /// <remarks>
  /// Defaults to <see cref="EmailFailureKind.Transient"/> for failures created
  /// via <see cref="Failure(string)"/>, which keeps every pre-1.3.0 call-site
  /// behaving exactly as before (retryable) without recompilation.
  /// </remarks>
  public EmailFailureKind FailureKind { get; init; } = EmailFailureKind.None;

  /// <summary>
  /// Convenience for the one question call-sites actually ask: is retrying
  /// this message pointless?
  /// </summary>
  public bool IsPermanentFailure => FailureKind == EmailFailureKind.Permanent;

  /// <summary>
  /// Creates a successful result.
  /// </summary>
  public static EmailResult Success() => new() { IsSuccess = true };

  /// <summary>
  /// Creates a <see cref="EmailFailureKind.Transient"/> failure result — the
  /// safe default, see <see cref="EmailFailureKind"/> on why unrecognised
  /// failures must not be assumed permanent.
  /// </summary>
  /// <param name="errorMessage">Description of what went wrong.</param>
  public static EmailResult Failure(string errorMessage) =>
    new() { IsSuccess = false, ErrorMessage = errorMessage, FailureKind = EmailFailureKind.Transient };

  /// <summary>
  /// Creates a failure result with an explicit <see cref="EmailFailureKind"/>.
  /// </summary>
  /// <param name="errorMessage">Description of what went wrong.</param>
  /// <param name="kind">Whether retrying could ever succeed.</param>
  public static EmailResult Failure(string errorMessage, EmailFailureKind kind) =>
    new() { IsSuccess = false, ErrorMessage = errorMessage, FailureKind = kind };

  /// <summary>
  /// Creates a <see cref="EmailFailureKind.Permanent"/> failure result — the
  /// message can never be delivered as addressed, so callers must not requeue.
  /// </summary>
  /// <param name="errorMessage">Description of what went wrong.</param>
  public static EmailResult PermanentFailure(string errorMessage) =>
    new() { IsSuccess = false, ErrorMessage = errorMessage, FailureKind = EmailFailureKind.Permanent };
}
