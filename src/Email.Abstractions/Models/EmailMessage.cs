namespace Email.Abstractions;

/// <summary>
/// Represents an email message to be sent.
/// </summary>
public sealed record EmailMessage
{
  /// <summary>
  /// The recipient of the email.
  /// </summary>
  public required EmailRecipient To { get; init; }

  /// <summary>
  /// The sender email address.
  /// </summary>
  public required string FromAddress { get; init; }

  /// <summary>
  /// The sender display name.
  /// </summary>
  public string? FromName { get; init; }

  /// <summary>
  /// The email subject line.
  /// </summary>
  public required string Subject { get; init; }

  /// <summary>
  /// The HTML body of the email. Takes priority over PlainTextBody when both are set.
  /// </summary>
  public string? HtmlBody { get; init; }

  /// <summary>
  /// The plain text body of the email. Used as fallback when HtmlBody is not set.
  /// </summary>
  public string? PlainTextBody { get; init; }

  /// <summary>
  /// Optional reply-to email address.
  /// </summary>
  public string? ReplyTo { get; init; }

  /// <summary>
  /// Optional extra MIME headers to set on the outgoing message, e.g.
  /// <c>List-Unsubscribe</c> / <c>List-Unsubscribe-Post</c> (RFC 8058) for
  /// one-click unsubscribe on marketing/lifecycle mail. Header names and values
  /// are written verbatim, so callers MUST validate them (allowlist + no CRLF).
  /// </summary>
  public IReadOnlyDictionary<string, string>? CustomHeaders { get; init; }
}
