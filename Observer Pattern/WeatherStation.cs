namespace Design_Pattern.Observer_Pattern {
	// 此样例中的一个实体类，仅是封装一些值，不是必须
	public class WeatherData {
		public int Temperature;
		public int Humidity;
		public int Pressure;
		public WeatherData() {
			Temperature = 0;
			Humidity = 50;
			Pressure = 1000;
		}
	}

	// 逻辑主题接口
	public interface Subject {
		public void RegisterObserver(Observer observer);
		public void UnregisterObserver(Observer observer);
		public void NotifyObservers();
	}

	// 实际主题
	public class WeatherStation : Subject {
		private WeatherData data = new();
		private List<Observer> observers = new();
		public void RegisterObserver(Observer observer) {
			observers.Add(observer);
		}
		public void UnregisterObserver(Observer observer) {
			observers.Remove(observer);
		}
		public void NotifyObservers() {
			foreach(Observer observer in observers) {
				observer.Update(data);
			}
		}
		// 此样例中的获取信息的方法，不是必须
		public void GetData() {
			Random rnd = new Random();
			data.Humidity = rnd.Next(0, 101);
			data.Temperature = rnd.Next(-20, 41);
			data.Pressure = rnd.Next(950, 1051);
		}
	}

	// 逻辑观察者接口
	public interface Observer {
		public void Update(WeatherData data);
	}

	// 此样例中“显示屏”显示数值的接口，不是必须
	public interface DisplayData {
		public void Display();
	}

	// 下面将实现三个实际观察者，它们都要实现①逻辑观察者接口②显示数值接口
	public class NormalScreen:Observer,DisplayData {
		WeatherData data = new();
		public void Update(WeatherData data) {
			this.data= data;
			Display();
		}
		public void Display() {
			Console.WriteLine("I am a Normal Screen that shows everything!");
			Console.WriteLine($"Temperature: {data.Temperature}℃");
			Console.WriteLine($"Humidity: {data.Humidity}%");
			Console.WriteLine($"Pressure: {data.Pressure}hPa");
		}
	}
	public class HotOrColdScreen : Observer, DisplayData {
		WeatherData data = new();
		public void Update(WeatherData data) {
			this.data = data;
			Display();
		}
		public void Display() {
			Console.WriteLine("I am a Hot/Cold Screen that shows HOT or COLD!");
			if (data.Temperature > 25) {
				Console.WriteLine("HOT!");
			}
			else if (data.Temperature < 5) {
				Console.WriteLine("COLD!");
			}
			else {
				Console.WriteLine("YUMMY, Not too hot and not too cold!");
			}
		}
	}
	public class DryWarningScreen : Observer, DisplayData {
		WeatherData data = new();
		public void Update(WeatherData data) {
			this.data = data;
			Display();
		}
		public void Display() {
			Console.WriteLine("I will tell you if it is too dry!");
			if (data.Humidity <= 30) {
				Console.WriteLine("WARNING! TOO DRY!");
			}
			else if (data.Humidity <=  50) {
				Console.WriteLine("CAUTION! A LITTLE DRY!");
			}
		}
	}

	// 主函数
	public class WeatherStationMain {
		public static void SingleRun() {
			WeatherStation station = new();
			Observer observer1 = new NormalScreen();
			Observer observer2 = new HotOrColdScreen();
			Observer observer3 = new DryWarningScreen();

			Console.WriteLine("> Register 2 Screen: Normal and HotOrCold.");
			station.RegisterObserver(observer1);
			station.RegisterObserver(observer2);
			Console.WriteLine("> Get Data Once. Then notify observers.");
			station.GetData();
			station.NotifyObservers();
			Console.WriteLine("> Register DryWarning and Unregister HotOrCold.");
			station.RegisterObserver(observer3);
			station.UnregisterObserver(observer2);
			Console.WriteLine("> Get Data Once. Then notify observers.");
			station.GetData();
			station.NotifyObservers();
		}
	}
}
