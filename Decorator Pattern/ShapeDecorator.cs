namespace Design_Pattern.Decorator_Pattern {
	// 抽象组件接口
	public interface Shape {
		public void Draw();
	}
	// 抽象装饰器抽象类。装饰器必须至少是抽象类，因为它有一个成员变量shape！接口是不能有成员变量的。
	public abstract class ShapeDecorator : Shape {
		public Shape shape;
		public ShapeDecorator(Shape shape) {
			this.shape = shape;
		}
		public abstract void Draw(); // 由于不会通过一个“空”装饰器包裹形状，因此Draw方法可以是抽象的
	}
	// 两个具体组件
	public class Circle : Shape {
		public void Draw() {
			Console.WriteLine("Circle");
		}
	}
	public class Square : Shape {
		public void Draw() {
			Console.WriteLine("Square");
		}
	}
	// 两个装饰器
	public class Bordered : ShapeDecorator {
		public Bordered(Shape shape) : base(shape) {
		}
		public override void Draw() {
			shape.Draw();
			Console.WriteLine("And it is bordered.");
		}
	}
	public class Colored : ShapeDecorator {
		public Colored(Shape shape) : base(shape) {
		}
		public override void Draw() {
			shape.Draw();
			Console.WriteLine("And it is colored.");
		}
	}
	public class ShapeDecoratorMain {
		public static void SingleRun() {
			Console.WriteLine("> 绘制一个普通圆形。");
			Shape shape1 = new Circle();
			shape1.Draw();

			Console.WriteLine("> 绘制一个填色、描边的方形。");
			Shape shape2 = new Bordered(new Colored(new Square()));
			shape2.Draw();

			Console.WriteLine("> 绘制一个描边、填色的方形。");
			Shape shape3 = new Colored(new Bordered(new Square()));
			shape3.Draw();
		}
	}
}
