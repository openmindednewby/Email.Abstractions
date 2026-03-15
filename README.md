# Email.Abstractions

Email service abstractions for multi-tenant SaaS applications.

## Interfaces

- **`IEmailService`** — Send plain/HTML emails and templated emails
- **`IEmailTemplateRenderer`** — Render named templates with placeholder data

## Models

- **`EmailMessage`** — Email message with HTML/plain text body
- **`EmailRecipient`** — Recipient with address and optional display name
- **`EmailResult`** — Success/failure result with error details

## Template Names

`EmailTemplateNames` provides well-known template identifiers:
- `otp-code` — OTP verification
- `welcome` — Account creation
- `password-reset` — Password reset
- `payment-receipt` — Successful payment
- `payment-failed` — Failed payment
- `account-deletion` — Account deletion confirmation

## Usage

```csharp
// Register an implementation (e.g., Email.Smtp)
builder.Services.AddSmtpEmail(options => { ... });

// Inject and use
public class MyService(IEmailService emailService)
{
    public async Task SendOtp(string email, string code)
    {
        var result = await emailService.SendTemplatedAsync(
            EmailTemplateNames.OtpCode,
            new EmailRecipient { Address = email },
            "Your Verification Code",
            new Dictionary<string, string> { ["Code"] = code });
    }
}
```
