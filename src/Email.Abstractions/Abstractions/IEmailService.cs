namespace Email.Abstractions.Abstractions;

/// <summary>
/// Service for sending transactional emails via SMTP or an email provider API.
/// </summary>
public interface IEmailService
{
  /// <summary>
  /// Send a plain or HTML email message.
  /// </summary>
  /// <param name="message">The email message to send.</param>
  /// <param name="cancellationToken">Cancellation token.</param>
  /// <returns>Result indicating success or failure with error details.</returns>
  Task<EmailResult> SendAsync(EmailMessage message, CancellationToken cancellationToken = default);

  /// <summary>
  /// Send a templated email by rendering a named template with the provided data.
  /// </summary>
  /// <param name="templateName">The template identifier (e.g., "otp-code", "welcome").</param>
  /// <param name="recipient">The email recipient.</param>
  /// <param name="subject">The email subject line.</param>
  /// <param name="templateData">Key-value pairs for template placeholder replacement.</param>
  /// <param name="cancellationToken">Cancellation token.</param>
  /// <returns>Result indicating success or failure with error details.</returns>
  Task<EmailResult> SendTemplatedAsync(
    string templateName,
    EmailRecipient recipient,
    string subject,
    Dictionary<string, string> templateData,
    CancellationToken cancellationToken = default);
}
