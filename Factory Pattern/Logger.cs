using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Factory_Pattern {
	// 抽象产品
	public abstract class Logger {
		public string LoggerName { get; set; }
		public void WriteLog(string logContent) {
			Console.WriteLine($"> Content {logContent} is written to the logger {LoggerName}.");
		}
	}
	// 具体产品
	public class Server : Logger {
		public Server() => LoggerName = "Server";
	}
    public class Disk:Logger
    {
		public Disk() => LoggerName = "Disk";
	}
	// 抽象工厂
    public abstract class LoggerFactory {
		public abstract Logger CreateLogger();
		public void ConnectToLogger() { // 与具体创建哪个类无关（哪个类都需要），但也隶属与“创建”过程的操作
			Console.WriteLine($"> Successfully connected to the logger.");
		}
	}
	// 具体工厂
	public class ServerFactory :LoggerFactory{
		public override Logger CreateLogger() => new Server();
	}
	public class DiskFactory : LoggerFactory {
		public override Logger CreateLogger() => new Disk();
	}
	// 主程序
	public class LoggerMain {
		public static void SingleRun() {
			Console.WriteLine("> You are now trying to write some log content to a logger.");
			Console.WriteLine("> First, what is your log content?");
			string logContent = Console.ReadLine();
			Console.WriteLine($"> Good, your log content is {logContent}. Now, where do you want to write into? [A] for Server and [B] for Disk!");
			string loggerName = Console.ReadLine();
			LoggerFactory factory = null;
			if(loggerName == "A") {
				factory = new ServerFactory();
			}
			else {
				factory = new DiskFactory();
			}
			Logger logger = factory.CreateLogger();
			factory.ConnectToLogger();
			logger.WriteLog(logContent);
		}
	}
}
