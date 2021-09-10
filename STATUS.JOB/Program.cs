using Quartz;
using Quartz.Impl;
using STATUS.JOB.Jobs;
using System;
using System.Threading.Tasks;

namespace STATUS.JOB
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<StatusJob>()
                .WithIdentity("job1", "group1")
                .Build();

            var seconds = 60;
            var minutes = seconds*5;

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(minutes)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);

            Console.WriteLine("Pressione a tecla ESC para finalizar a execução do job...");

            var execute = true;
            
            while (execute)
            {
                execute = Console.ReadKey().Key != ConsoleKey.Escape;
            }

            await scheduler.Shutdown();
        }
    }
}
