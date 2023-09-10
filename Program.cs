using Design_Pattern.Strategy_Pattern;

internal class Program {
	private static void Main(string[] args) {
		int id;
		if (args.Length == 0) {
			Console.WriteLine("1. Strategy - Caculator");
			Console.Write("Please input pattern ID: ");
			while (!int.TryParse(Console.ReadLine(), out id)) {
				Console.Write("Wrong ID format! Retry: ");
			}
		}
		else {
			id = int.Parse(args[0]);
		}
		switch (id) {
			case 1:
				Caculator.SingleRun();
				break;
			default:
				Console.WriteLine("Unknown pattern!");
				break;
		}
	}
}