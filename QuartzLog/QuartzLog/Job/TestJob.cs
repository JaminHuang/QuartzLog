using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace QuartzLog
{
	public class TestJob : IJob
	{
		private static readonly log4net.ILog LogInfo = log4net.LogManager.GetLogger("LogCustomEx");
		private static readonly log4net.ILog LogError = log4net.LogManager.GetLogger("LogError");

		public void Execute(IJobExecutionContext context)
		{
			var map = context.JobDetail.JobDataMap;
			var jobInfo = map["KEY"] as JobInfo;
			if (jobInfo == null) { return; }

			//记录日志
			LogInfo.Info("\n【服务已启动】" + "\n【启动组】：" + jobInfo.Group + "\n【启动名称】：" + jobInfo.JobName + "\n【启动时间】：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

			try
			{
				switch (jobInfo.JobType)
				{
					//基础信息
					case JobType.Job1: LogInfo.Info("这是任务1"); break;
					case JobType.Job2: LogInfo.Info("这是任务2"); break;

					default: break;
				}
			}
			catch (Exception ex)
			{
				//记录日志
				LogError.Error("\n【服务执行出错】" +
							  "\n【启动组】：" + jobInfo.Group +
							  "\n【启动名称】：" + jobInfo.JobName +
							  "\n【时间】：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
							  "\n【错误信息】：" + ex.Message);
				return;
			}
		}
	}
}
