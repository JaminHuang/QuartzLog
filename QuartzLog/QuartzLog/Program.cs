using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace QuartzLog
{
	class Program
	{
		static void Main(string[] args)
		{
			//配置Log4日志
			log4net.Config.XmlConfigurator.Configure();

			//Windows服务
			HostFactory.Run(x =>
			{
				x.UseLog4Net();

				x.Service<ServerRunner>();

				x.SetDescription("Quartz日志记录服务");
				x.SetDisplayName("Quartz");
				x.SetServiceName("QuartzLog");

				x.EnablePauseAndContinue();
			});
		}
	}
}
