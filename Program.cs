﻿using Design_Pattern.Abstract_Factory_Pattern;
using Design_Pattern.Decorator_Pattern;
using Design_Pattern.Factory_Pattern;
using Design_Pattern.Observer_Pattern;
using Design_Pattern.Strategy_Pattern;

internal class Program {
	private static void Main(string[] args) {
		int id;
		if (args.Length == 0) {
			Console.WriteLine("1. Strategy - Caculator");
			Console.WriteLine("2. Strategy - Duck Simulator");
			Console.WriteLine("3. Observer - Number Converter");
			Console.WriteLine("4. Observer - Weather Station");
			Console.WriteLine("5. Decorator - Alonbarks");
			Console.WriteLine("6. Decorator - Shape Decorator");
			Console.WriteLine("7. Factory - Simple/Static Pizza (Actually they're not Factory Pattern)");
			Console.WriteLine("8. Factory - Logger");
			Console.WriteLine("9. Abstract Factory - Cloth Store");
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
				CaculatorMain.SingleRun();
				break;
			case 2:
				DuckSimulatorMain.SingleRun();
				break;
			case 3:
				NumberConverterMain.SingleRun();
				break;
			case 4:
				WeatherStationMain.SingleRun();
				break;
			case 5:
				AlonbarksMain.SingleRun();
				break;
			case 6:
				ShapeDecoratorMain.SingleRun();
				break;
			case 7:
				SimpleFactoryAndStaticFactoryMain.SingleRun();
				break;
			case 8:
				LoggerMain.SingleRun();
				break;
			case 9:
				ClothStoreMain.SingleRun();
				break;
			default:
				Console.WriteLine("Unknown pattern!");
				break;
		}
	}
}