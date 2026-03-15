namespace Email.Abstractions.Enums;

/// <summary>
/// Well-known email template names used across services.
/// </summary>
public static class EmailTemplateNames
{
  /// <summary>
  /// OTP verification code email.
  /// </summary>
  public const string OtpCode = "otp-code";

  /// <summary>
  /// Welcome email sent after account creation.
  /// </summary>
  public const string Welcome = "welcome";

  /// <summary>
  /// Password reset email.
  /// </summary>
  public const string PasswordReset = "password-reset";

  /// <summary>
  /// Payment receipt after successful charge.
  /// </summary>
  public const string PaymentReceipt = "payment-receipt";

  /// <summary>
  /// Payment failed notification.
  /// </summary>
  public const string PaymentFailed = "payment-failed";

  /// <summary>
  /// Account deletion confirmation.
  /// </summary>
  public const string AccountDeletion = "account-deletion";
}
