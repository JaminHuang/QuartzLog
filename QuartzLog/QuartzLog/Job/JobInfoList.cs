using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzLog
{
	public class JobInfoList
	{
		/// <summary>
		/// 脚本服务组
		/// </summary>
		public static List<JobInfo> JobList_ZhongShanHos = new List<JobInfo>
        {
            new JobInfo("任务1", "测试脚本", "*/5 * * * * ?", JobType.Job1),
			new JobInfo("任务2", "测试脚本", "*/7 * * * * ?", JobType.Job2)
            
        };
	}
}
