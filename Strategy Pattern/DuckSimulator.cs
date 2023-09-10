namespace Design_Pattern.Strategy_Pattern {
	// 飞行策略（接口），策略接口的内容与具体执行的操作有关，这个接口用来实现所有飞行动作
	public interface IFlyBehavior {
		public void fly();
	}

	// 下列为飞行策略的两个具体策略，组成一个算法族
	public class Fly : IFlyBehavior {
		public void fly() {
			Console.WriteLine("I'm flying!");
		}
	}

	public class CantFly : IFlyBehavior {
		public void fly() {
			Console.WriteLine("I can't fly!");
		}
	}

	// 叫策略（接口），策略接口的内容与具体执行的操作有关，这个接口用来实现所有叫动作
	public interface IQuackBehavior {
		public void quack();
	}

	// 下列为叫策略的三个具体策略，组成一个算法族
	public class Quack : IQuackBehavior {
		public void quack() {
			Console.WriteLine("Quack! Quack!");
		}
	}

	public class Squeak : IQuackBehavior {
		public void quack() {
			Console.WriteLine("Squeak~ Squeak~");
		}
	}

	public class MuteQuack : IQuackBehavior {
		public void quack() {
			Console.WriteLine("... Nothing makes sound.");
		}
	}

	// 环境，这里的环境是另一个鸭子类。鸭子类可以有多个实例，事实上环境都能有多个实例~
	public class Duck {
		public IFlyBehavior fly;
		public IQuackBehavior quack;
		public Duck(IFlyBehavior fly, IQuackBehavior quack) {
			this.fly = fly;
			this.quack = quack;
		}
		public void Fly() {
			fly.fly();
		}
		public void Quack() {
			quack.quack();
		}
		public void SetFly(IFlyBehavior fly) {
			Console.WriteLine("Fly Set");
			this.fly = fly;
		}
		public void SetQuack(IQuackBehavior quack) {
			Console.WriteLine("Quack Set");
			this.quack = quack;
		}
	}

	// 主函数
	public class DuckSimulator {
		public static void SingleRun() {
			Duck normalDuck = new(new Fly(), new Quack()); // 能叫能飞的普通鸭子
			Duck rubberDuck = new(new CantFly(), new Squeak()); // 能吱吱叫不能飞的橡皮鸭子
			Console.WriteLine("> Normal duck showtime!");
			normalDuck.Fly();
			normalDuck.Quack();
			Console.WriteLine("> Rubber duck showtime!");
			rubberDuck.Fly();
			rubberDuck.Quack();
			Console.WriteLine("> Mute the rubber duck but make it fly-able with some magic!");
			rubberDuck.SetFly(new Fly());
			rubberDuck.SetQuack(new MuteQuack());
			Console.WriteLine("> Rubber duck showtime 2.0!");
			rubberDuck.Fly();
			rubberDuck.Quack();
		}
	}
}
