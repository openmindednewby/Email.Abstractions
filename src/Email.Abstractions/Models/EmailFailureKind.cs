namespace Email.Abstractions;

/// <summary>
/// Why an email send failed, in the only dimension a caller can act on:
/// is retrying this exact message worth anything?
/// </summary>
/// <remarks>
/// <para>
/// Callers map this onto their own transport. An HTTP API fronting a mail send
/// should surface <see cref="Permanent"/> as a 4xx (the request cannot succeed
/// as written) and <see cref="Transient"/> as a 5xx (the upstream is unwell,
/// come back later) — because .NET's standard resilience handler retries 5xx
/// and not 4xx, a mis-mapped permanent failure becomes a silent retry storm.
/// </para>
/// <para>
/// <b><see cref="Transient"/> is the deliberate default for anything
/// unrecognised.</b> The asymmetry matters: mis-labelling a transient failure
/// as permanent DROPS a legitimate email, while mis-labelling a permanent one
/// as transient merely wastes a retry. Only classify as
/// <see cref="Permanent"/> on positive evidence.
/// </para>
/// </remarks>
public enum EmailFailureKind
{
  /// <summary>The send succeeded — no failure. Default so that
  /// <c>default(EmailFailureKind)</c> on a successful result is coherent.</summary>
  None = 0,

  /// <summary>
  /// Retrying later may succeed: connection refused, timeout, TLS handshake
  /// failure, greylisting, or an SMTP 4xx transient negative reply.
  /// </summary>
  Transient = 1,

  /// <summary>
  /// Retrying this message will never succeed: the recipient does not exist,
  /// the address is malformed, or the server issued an SMTP 5xx permanent
  /// negative reply. The caller should surface it and stop, not requeue.
  /// </summary>
  Permanent = 2,
}
