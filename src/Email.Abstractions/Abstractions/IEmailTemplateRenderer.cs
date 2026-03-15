namespace Email.Abstractions.Abstractions;

/// <summary>
/// Renders email templates by replacing placeholders with provided data.
/// </summary>
public interface IEmailTemplateRenderer
{
  /// <summary>
  /// Render a named template with the given data.
  /// </summary>
  /// <param name="templateName">The template identifier (e.g., "otp-code", "welcome").</param>
  /// <param name="data">Key-value pairs for placeholder replacement.</param>
  /// <param name="cancellationToken">Cancellation token.</param>
  /// <returns>The rendered HTML string.</returns>
  Task<string> RenderAsync(
    string templateName,
    Dictionary<string, string> data,
    CancellationToken cancellationToken = default);
}
