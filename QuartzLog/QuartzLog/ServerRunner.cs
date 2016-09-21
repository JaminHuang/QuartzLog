using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Topshelf;

namespace QuartzLog
{
	public sealed class ServerRunner : ServiceControl, ServiceSuspend
	{
		private readonly IScheduler scheduler;

		public ServerRunner()
		{
			scheduler = StdSchedulerFactory.GetDefaultScheduler();
		}

		public bool Start(HostControl hostControl)
		{
			var jobList = new List<JobInfo>();

			//配置JobList任务
			jobList.AddRange(JobInfoList.JobList_ZhongShanHos);

			jobList.ForEach(
				x =>
				{
					var dic = new Dictionary<string, JobInfo> { { "KEY", x } };
					var map = new JobDataMap(dic);
					var job =
						JobBuilder.Create<TestJob>()
							.WithIdentity(x.JobName, x.Group)
							.UsingJobData(map)
							.RequestRecovery()
							.Build();
					var trigger =
						TriggerBuilder.Create()
							.WithIdentity(x.JobName, x.Group)
							.WithCronSchedule(x.Trigger)
							.Build();
					scheduler.ScheduleJob(job, trigger);
				});
			scheduler.Start();
			return true;
		}

		public bool Stop(HostControl hostControl)
		{
			scheduler.Shutdown(false);
			return true;
		}

		public bool Continue(HostControl hostControl)
		{
			scheduler.ResumeAll();
			return true;
		}

		public bool Pause(HostControl hostControl)
		{
			scheduler.PauseAll();
			return true;
		}
	}
}
