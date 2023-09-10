namespace Design_Pattern.Strategy_Pattern {
	// 策略（接口），策略接口的内容与具体执行的操作有关，它其中有一个未被实现的方法等待具体的、同一个算法族的不同实际策略来实现
	public interface ICaculateStrategy {
		public int DoCaculate(int num1, int num2);
	}

	// 实际策略：加法
	public class AddCaculate : ICaculateStrategy {
		public int DoCaculate(int num1, int num2) {
			Console.WriteLine("ADD");
			return num1 + num2;
		}
	}

	// 实际策略：减法。加法、减法等所有实现同一个策略接口的构成一个算法族，也就是所有策略的集合。
	public class SubtractCaculate : ICaculateStrategy {
		public int DoCaculate(int num1, int num2) {
			Console.WriteLine("SUBTRACT");
			return num1 - num2;
		}
	}

	// 环境
	public class CaculatorEnvironment {
		public ICaculateStrategy strategy;
		public CaculatorEnvironment(ICaculateStrategy strategy) {
			Console.WriteLine("Strategy Set!");
			this.strategy = strategy;
		}
		public void SetStrategy(ICaculateStrategy strategy) {
			Console.WriteLine("Strategy Change!");
			this.strategy = strategy;
		}
		public int DoCaculate(int num1, int num2) {
			Console.WriteLine("Do Caculate");
			return strategy.DoCaculate(num1, num2);
		}
	}

	// 主函数
	public class CaculatorMain {
		public static void SingleRun() {
			CaculatorEnvironment caculator = new(new AddCaculate());  // 创建计算器环境，初始设置其策略为加法
			Console.WriteLine(caculator.DoCaculate(1, 3));  // 实施策略
			caculator.SetStrategy(new SubtractCaculate());  // 更新原来计算器环境的策略为减法
			Console.WriteLine(caculator.DoCaculate(1, 3));  // 实施策略
		}
	}
}
