namespace Email.Abstractions;

/// <summary>
/// Represents an email recipient.
/// </summary>
public sealed record EmailRecipient
{
  /// <summary>
  /// The recipient's email address.
  /// </summary>
  public required string Address { get; init; }

  /// <summary>
  /// The recipient's display name.
  /// </summary>
  public string? Name { get; init; }
}
