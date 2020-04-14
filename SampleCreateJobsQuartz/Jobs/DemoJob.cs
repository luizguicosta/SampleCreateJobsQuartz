using Quartz;
using SampleCreateJobsQuartz.Jobs.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SampleCreateJobsQuartz.Jobs
{
    public class DemoJob : BaseJob
    {
        public override Task Execute(IJobExecutionContext context)
        {
			try
			{
				return Task.Run(() =>
				{
					Debug.WriteLine($"DemoJob: {DateTime.Now}");
					Debug.WriteLine($"JobKey: {context.JobDetail.Key}");
				});
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error: {ex.Message} -- Date: {DateTime.Now}");
				throw;
			}
		}
    }
}