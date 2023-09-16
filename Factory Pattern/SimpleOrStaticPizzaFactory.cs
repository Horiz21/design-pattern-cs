using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern.Factory_Pattern {
	public abstract class Pizza {
		public abstract string Name { get; set; }
	}
	public class CheesePizza : Pizza {
		public override string Name { get; set; } = "Cheese Pizza";
		public CheesePizza() {

		}
	}
	public class VegetablePizza : Pizza {
		public override string Name { get; set; } = "Vegetable Pizza";
	}
	public class SimplePizzaFactory {
		public virtual Pizza CreatePizza(string type) {
			Pizza pizza = null;
			if (type == "cheese") {
				pizza = new CheesePizza();
			}
			else { //  if(type == "vegetable") 
				pizza = new VegetablePizza();
			}
			Console.WriteLine($"Just created a {pizza.Name}, oho!");
			return pizza;
		}
		public static Pizza CreatePizzaStaticly(string type) {
			Pizza pizza = null;
			if (type == "cheese") {
				pizza = new CheesePizza();
			}
			else { //  if(type == "vegetable") 
				pizza = new VegetablePizza();
			}
			Console.WriteLine($"Just created a {pizza.Name} staticly, yummy!");
			return pizza;
		}
	}
	public class SimpleExpensivePizzaFactory : SimplePizzaFactory {
		public override Pizza CreatePizza(string type) {
			Pizza pizza = null;
			if (type == "cheese") {
				pizza = new CheesePizza();
			}
			else { //  if(type == "vegetable") 
				pizza = new VegetablePizza();
			}
			Console.WriteLine($"Just created a SUPER EXPENSIVE {pizza.Name}, oho!");
			return pizza;
		}
		public static Pizza CreatePizzaStaticly(string type) {
			Pizza pizza = null;
			if (type == "cheese") {
				pizza = new CheesePizza();
			}
			else { //  if(type == "vegetable") 
				pizza = new VegetablePizza();
			}
			Console.WriteLine($"Just created a SUPER EXPENSIVE {pizza.Name} staticly, yummy!");
			return pizza;
		}
	}
	public class SimpleFactoryAndStaticFactoryMain {
		public static void SingleRun() {
			SimplePizzaFactory factory = new();
			Pizza pizza1 = factory.CreatePizza("cheese");
			Pizza pizza2 = SimplePizzaFactory.CreatePizzaStaticly("vegetable");

			SimplePizzaFactory expensiveFactory = new SimpleExpensivePizzaFactory();
			Pizza pizza3 = expensiveFactory.CreatePizza("cheese");
			Pizza pizza4 = SimpleExpensivePizzaFactory.CreatePizzaStaticly("vegetable");  // 当用自己的类名调用自己的方法时，是可以调用到隐藏的方法的
		}
	}
}
