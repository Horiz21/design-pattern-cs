namespace Design_Pattern.Observer_Pattern {
	// 逻辑主题
	public interface ISubject {
		public void RegisterObserver(INumberObserver observer);
		public void UnregisterObserver(INumberObserver observer);
		public void NotifyObservers();
	}

	// 实际主题
	public class NumberLoader : ISubject {
		int num = 1;
		List<INumberObserver> observers = new();
		public void RegisterObserver(INumberObserver observer) {
			observers.Add(observer);
		}

		public void UnregisterObserver(INumberObserver observer) {
			observers.Remove(observer);
		}
		public void NotifyObservers() {
			foreach(INumberObserver observer in observers) {
				observer.Update(num);
			}
		}
		public void NextNum(int add = 1) {
			num = num + add;
		}
	}

	// 逻辑观察者
	public interface INumberObserver {
		public void Update(int num);
	}

	// 针对本样例的逻辑输出者，不是必须
	public interface INumberPrinter {
		public void Print();
	}

	// 实际观察者：三个进制的数字
	public class BinObserver : INumberObserver,INumberPrinter {
		int num = 0;
		public void Update(int num) {
			this.num=num;
			Print();
		}
		public void Print() {
			Console.WriteLine("Bin: " + Convert.ToString(num, 2));
		}
	}
	public class DecObserver : INumberObserver, INumberPrinter {
		int num = 0;
		public void Update(int num) {
			this.num = num;
			Print();
		}
		public void Print() {
			Console.WriteLine("Dec: " + Convert.ToString(num, 10));
		}
	}
	public class HexObserver : INumberObserver, INumberPrinter {
		int num = 0;
		public void Update(int num) {
			this.num = num;
			Print();
		}
		public void Print() {
			Console.WriteLine("Hex: " + Convert.ToString(num, 16));
		}
	}

	// 主函数
	public class NumberConverterMain {
		public static void SingleRun() {
			NumberLoader loader = new();
			INumberObserver observer1 = new BinObserver();
			INumberObserver observer2 = new DecObserver();
			INumberObserver observer3 = new HexObserver();

			Console.WriteLine("> Register 2 Converter: [2] and [10].");
			loader.RegisterObserver(observer1);
			loader.RegisterObserver(observer2);
			Console.WriteLine("> Get Data Once. Then notify observers.");
			loader.NextNum(10);
			loader.NotifyObservers();
			Console.WriteLine("> Register [16] and Unregister [2].");
			loader.RegisterObserver(observer3);
			loader.UnregisterObserver(observer1);
			Console.WriteLine("> Get Data Once. Then notify observers.");
			loader.NextNum(12);
			loader.NotifyObservers();
		}
	}
}
