using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCreateJobsQuartz.Jobs.Base
{
    public abstract class BaseJob : IJob
    {
        public abstract Task Execute(IJobExecutionContext context);
    }
}
