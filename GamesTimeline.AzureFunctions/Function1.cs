using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace GamesTimeline.AzureFunctions;

public class Function1(ILogger<Function1> logger)
{
    [Function("Function1")]
    public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
    {
        logger.LogInformation("C# Timer trigger function executed at: {executionTime}", DateTime.Now);

        if (myTimer.ScheduleStatus is not null)
        {
            logger.LogInformation("Next timer schedule at: {nextSchedule}", myTimer.ScheduleStatus.Next);
            
        }
    }
}