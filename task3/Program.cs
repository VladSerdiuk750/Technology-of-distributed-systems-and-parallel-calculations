using System;
using System.Threading;

namespace task3
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "   Name of the car";
			Console.BackgroundColor = ConsoleColor.White;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Black;

			Console.WriteLine("Enter the name of car - ");
			var nameOfCar = Console.ReadLine();

			var enteredWord = "";

			var carEvent = new CarEvent();
			var carEvent2 = new CarEvent();
			var process = new ProcessNameChange();
			var confirm = new ConfirmingNameChange();

			carEvent.CarNameChange += new CarEventHandler(confirm.handler);
			carEvent2.CarNameChange += new CarEventHandler(process.handler);

			do
			{
				Console.WriteLine("Enter new name for the car - ");
				enteredWord = Console.ReadLine();
				if (enteredWord.ToUpper() != "exit".ToUpper())
				{ 
					carEvent.OnCarNameChange(nameOfCar, enteredWord);
					var result = Console.ReadKey(true);
					if (result.Key == ConsoleKey.Y)
					{
						carEvent2.OnCarNameChange(nameOfCar, enteredWord);
						nameOfCar = enteredWord;
					}
					else Console.WriteLine("The name wasn't confirm.");
				}
				else break;
			} while (true);

			Console.WriteLine("For exit press <Enter>");
			Console.ReadKey();
		}
	}
}
