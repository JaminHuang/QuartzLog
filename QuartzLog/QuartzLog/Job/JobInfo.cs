using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzLog
{
	public class JobInfo
	{
		public JobInfo(string jobName, string group, string trigger, JobType jobType)
		{
			if (jobName == null || trigger == null || group == null)
			{
				throw new ArgumentNullException("jobName");
			}
			this.JobName = jobName;
			this.Trigger = trigger;
			this.Group = group;
			this.JobType = jobType;
		}

		/// <summary>
		/// 名称
		/// </summary>
		public string JobName { get; set; }

		/// <summary>
		/// Job的触发器  cron表达式
		/// </summary>
		public string Trigger { get; set; }

		/// <summary>
		/// 群组
		/// </summary>
		public string Group { get; set; }

		/// <summary>
		/// Job类型
		/// </summary>
		public JobType JobType { get; set; }
	}

	/// <summary>
	/// Job类型枚举
	/// </summary>
	public enum JobType
	{
		/// <summary>
		/// 任务1
		/// </summary>
		Job1 = 1,
		/// <summary>
		/// 任务2
		/// </summary>
		Job2 = 2
	}
}
