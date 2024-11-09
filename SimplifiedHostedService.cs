using Microsoft.Extensions.Hosting;
namespace SimpleHostedService;

/// <summary>
/// This is simplified hosted service
/// with one task for execution
/// It can be easily added in service
/// collection of application
/// </summary>
public class SimplifiedHostedService : IHostedService
{
    private CancellationTokenSource? _cts;
    private Func<CancellationToken, Task> _executeTask;

    /// <summary>
    /// Initialize
    /// </summary>
    /// <param name="executeTask">The task for executing</param>
    public SimplifiedHostedService(Func<CancellationToken, Task> executeTask)
    {
        _executeTask = executeTask??throw new ArgumentException("The executed task can not be null");
    }

    /// <summary>
    /// Starts executed task
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        return Task.Run(() => _executeTask(_cts.Token), cancellationToken);
    }

    /// <summary>
    /// Stops executed task
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _cts!.Cancel();
        return Task.CompletedTask;
    }
}