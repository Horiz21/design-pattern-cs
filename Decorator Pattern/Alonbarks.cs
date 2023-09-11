namespace Design_Pattern.Decorator_Pattern {
	// 抽象组件，此处为饮料
	public abstract class Beverage {
		List<string> description = new() {
				"Unknown!"
			};
		public abstract int Cost(); // 抽象方法：没有具体实现的方法，只有方法签名，需要在派生类中进行实现。
		public virtual List<string> Description() {  // 虚方法有默认的实现，但派生类可以选择重写它们。其实这里并不需要，只是展示一下
			return description;
		}
	}

	// 抽象装饰器，此处为小料
	public abstract class Toppings: Beverage {
		public Beverage beverage; // 装饰器中包裹了一个组件
		public Toppings(Beverage beverage) {
			this.beverage = beverage;
		}
	}

	// 两种具体饮料
	public class MilkTea : Beverage {
		public override int Cost() {
			return 8;
		}
		public override List<string> Description() {

			List<string> list = new() {
				"奶茶"
			};
			return list;
		}
	}

	public class MilkGreenTea: Beverage {
		List<string> description = new() {
				"奶青"
		};
		public override int Cost() {
			return 9;
		}
		public override List<string> Description() {
			return description;
		}
	}

	// 三种具体小料
	public class Pearls : Toppings {
		public Pearls(Beverage beverage) : base(beverage) {
		}// 在构造函数的定义中使用了base(beverage)来调用基类Toppings的构造函数，并将参数beverage传递给基类的构造函数进行初始化

		public override int Cost() {
			return beverage.Cost() + 1;
		}
		public override List<string> Description() {
			List<string> description = beverage.Description();
			description.Add("珍珠");
			return description;
		}
	}
	public class Pudding : Toppings {
		public Pudding(Beverage beverage) : base(beverage) {
		}

		public override int Cost() {
			return beverage.Cost() + 2;
		}
		public override List<string> Description() {
			List<string> description = beverage.Description();
			description.Add("布丁");
			return description;
		}
	}
	public class CreamCrown : Toppings {
		public CreamCrown(Beverage beverage) : base(beverage) {
		}

		public override int Cost() {
			return beverage.Cost() + 4;
		}
		public override List<string> Description() {
			List<string> description = beverage.Description();
			description.Add("奶油顶");
			return description;
		}
	}


	// 主函数
	public class AlonbarksMain {
		// 只是为了该场景下方便实现的外围函数，不是必要
		private static void Order(Beverage beverage) {
			Console.Write("详情：");
			foreach(string item in beverage.Description()) {
				Console.Write(item);
				Console.Write(", ");
			}
			Console.WriteLine();
			Console.Write("价格：");
			Console.WriteLine(beverage.Cost());	
		}

		// 主函数的运行函数
		public static void SingleRun() {
			Console.WriteLine("> 你好，我要一份普通奶茶，什么都不要加。");
			Beverage beverage1 = new MilkTea();
			Order(beverage1);

			Console.WriteLine("> 你好，我要一份奶青，加一份珍珠和两份奶油顶。");
			Beverage beverage2 = new CreamCrown(new CreamCrown(new Pearls(new MilkGreenTea())));
			Order(beverage2);

			Console.WriteLine("> 你好，我要一份奶茶，加一份珍珠，两份布丁，三份奶油顶。");
			Beverage beverage3 = new CreamCrown(new CreamCrown(new CreamCrown(new Pudding(new Pudding(new Pearls(new MilkTea()))))));
			Order(beverage3);
			Console.WriteLine("> 店员：你是猛的。");
		}
	}
}
