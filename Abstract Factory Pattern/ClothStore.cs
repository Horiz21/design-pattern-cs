using Design_Pattern.Factory_Pattern;
using System.Security.Cryptography.X509Certificates;

namespace Design_Pattern.Abstract_Factory_Pattern {
	// 抽象产品
	public abstract class ClothSet {
		public string Match { get; set; }  // 衣服的搭配，此处是说有哪几件
		public Top top;
		public Bottom bottom;
		public Accessory accessory;

		public abstract void Produce(); // 生产衣服的抽象方法
		public void Introduce() {
			Console.WriteLine($"Introducing the {Match}-match cloth set!");
			Console.WriteLine("Here we got: ");
			if (top != null) Console.WriteLine($"- {top.Name} as top. ");
			if (bottom != null) Console.WriteLine($"- {bottom.Name} as bottom. ");
			if (accessory != null) Console.WriteLine($"- Moreover, {accessory.Name} accompanied!");
			Console.WriteLine();  // 空行
		}
	}

	// 具体产品
	public class JustBottom : ClothSet {  // 1. 只穿裤子
		ClothSetComponentFactory clothFactory;
		public JustBottom(ClothSetComponentFactory clothFactory) {
			this.clothFactory = clothFactory;
			Match = "NOT-BE-CHARGED-WITH-HOOLIGANISM";
		}
		public override void Produce() {
			Console.WriteLine($"Preparing a {Match} cloth set.");
			bottom = clothFactory.CreateBottom();
		}
	}
	public class SimpleSet : ClothSet {  // 2. 简单装，只有上下装
		ClothSetComponentFactory clothFactory;
		public SimpleSet(ClothSetComponentFactory clothFactory) {
			this.clothFactory = clothFactory;
			Match = "Simple";
		}
		public override void Produce() {
			Console.WriteLine($"Preparing a {Match} cloth set.");
			bottom = clothFactory.CreateBottom();
			accessory = clothFactory.CreateAccessory();
		}
	}
	public class FullSet : ClothSet {  // 3. 完整装，有上下装和配饰
		ClothSetComponentFactory clothFactory;
		public FullSet(ClothSetComponentFactory clothFactory) {
			this.clothFactory = clothFactory;
			Match = "Full";
		}
		public override void Produce() {
			Console.WriteLine($"Preparing a {Match} cloth set.");
			top = clothFactory.CreateTop();
			bottom = clothFactory.CreateBottom();
			accessory = clothFactory.CreateAccessory();
		}
	}

	// 抽象原料
	public abstract class Top { public string Name { get; set; } }  // 上装
	public abstract class Bottom { public string Name { get; set; } }  // 下装
	public abstract class Accessory { public string Name { get; set; } }  // 配饰

	// 具体原料
	public class TShirt : Top { public TShirt() => Name = "T-Shirt"; } // T恤
	public class Shorts : Bottom { public Shorts() => Name = "Shorts"; }  // 短裤
	public class Cap : Accessory { public Cap() => Name = "McDonald's Cap"; }  // 帽子
	public class Suit : Top { public Suit() => Name = "Formal Suit"; }  // 西装
	public class Trousers : Bottom { public Trousers() => Name = "Formal Trousers"; }  // 西裤
	public class Necktie : Accessory { public Necktie() => Name = "Necktie"; }  // 领带

	// 抽象原料工厂，下面每个原料对应一个新类
	public interface ClothSetComponentFactory {
		public Top CreateTop();
		public Bottom CreateBottom();
		public Accessory CreateAccessory();
	}

	// 具体原料工厂，需要实现所有方法
	public class CasualClothSetComponentFactory : ClothSetComponentFactory {
		public Top CreateTop() => new TShirt();
		public Bottom CreateBottom() => new Shorts();
		public Accessory CreateAccessory() => new Cap();
	}
	public class FormalClothSetComponentFactory : ClothSetComponentFactory {
		public Top CreateTop() => new Suit();
		public Bottom CreateBottom() => new Trousers();
		public Accessory CreateAccessory() => new Necktie();
	}

	// 抽象客户，抽象工厂的客户是一个Store，或者直接使用具体客户——也就是主函数，简单地说就是一个使用工厂的客户
	public abstract class ClothStore {
		protected abstract ClothSet ProduceClothSet(string match);  // 这个方法不能被外部直接调用噢，只能从内调用
		public ClothSet OrderClothSet(string match) {  // 这个方法才是外部调用的入口
			Console.WriteLine("Hello and welcome. What do you want to get today?");
			ClothSet clothSet = ProduceClothSet(match);
			clothSet.Produce();
			clothSet.Introduce();
			return clothSet;
		}
	}

	// 具体客户，具体客户也不是必要角色。
	public class CasualClothStore : ClothStore {
		protected override ClothSet ProduceClothSet(string match) {
			ClothSetComponentFactory componentFactory = new CasualClothSetComponentFactory();
			if (match == "full") return new FullSet(componentFactory);
			if (match == "simple") return new SimpleSet(componentFactory);
			return new JustBottom(componentFactory);
		}
	}
	public class FormalClothStore : ClothStore {
		protected override ClothSet ProduceClothSet(string match) {
			ClothSetComponentFactory componentFactory = new FormalClothSetComponentFactory();
			if (match == "full") return new FullSet(componentFactory);
			if (match == "simple") return new SimpleSet(componentFactory);
			return new JustBottom(componentFactory);
		}
	}

	public class ClothStoreMain {
		public static void SingleRun() {
			// 有两家店，分别是正装店和休闲装店
			ClothStore[] stores = { new CasualClothStore(), new FormalClothStore() };

			// 从正装店里买一条裤子
			ClothSet clothSet1 = stores[0].OrderClothSet("just-bottom");

			// 从休闲装店的分别买一套完整的衣服，和一套简单的衣服
			ClothSet clothSet2 = stores[1].OrderClothSet("full");
			ClothSet clothSet3 = stores[1].OrderClothSet("simple");
		}
	}
}
