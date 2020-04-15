using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCreateJobsQuartz.Jobs.Base
{
    public static class BaseExecuteJobs<TEntity> where TEntity : IJob
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="nameJob">Name of job</param>
		/// <param name="nameTrigger">Name of Trigger</param>
		/// <param name="hours">Hours run job ex: 12</param>
		/// <param name="minutes">Minutes run job ex: 45</param>
		/// <returns></returns>
        public async static Task StartJobDaily(string nameJob, string nameTrigger, int  hours, int minutes)
        {
			try
			{
				IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
				await scheduler.Start();
				IJobDetail job = JobBuilder.Create<TEntity>().WithIdentity(nameJob, "Job Group").Build();
				ITrigger trigger = TriggerBuilder.Create()
				  .WithIdentity(nameTrigger, "trigger Group")
				  .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(hours, minutes))
				  .Build();
				scheduler.ScheduleJob(job, trigger).Wait();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error: {ex.Message} - Date: {DateTime.Now}");
				throw;
			}
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="nameJob">Name of job</param>
		/// <param name="nameTrigger">Name of Trigger</param>
		/// <param name="hours">Hours interval run job ex: 1</param>
		/// <returns></returns>
		public async static Task StartHourlyJob(string nameJob, string nameTrigger, int hours)
		{
			try
			{
				IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
				await scheduler.Start();
				IJobDetail job = JobBuilder.Create<TEntity>().WithIdentity(nameJob, "Job Group").Build();
				ITrigger trigger = TriggerBuilder.Create()
				  .WithIdentity(nameTrigger, "trigger Group")
				  .WithSimpleSchedule(x => x.WithIntervalInHours(hours).RepeatForever())
				  .Build();
				scheduler.ScheduleJob(job, trigger).Wait();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error: {ex.Message} - Date: {DateTime.Now}");
				throw;
			}
		}
	}
}
