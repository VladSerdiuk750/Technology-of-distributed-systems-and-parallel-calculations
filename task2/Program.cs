using System;

namespace task2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "   Creating arrays of chars";
			Console.BackgroundColor = ConsoleColor.White;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Black;
			// Setting console


			var keyEvent = new KeyEvent();
			var processEvent = new ProcessKey();
			ConsoleKeyInfo consoleKeyInfo;
			string str = "";

			keyEvent.KeyPress += new KeyHandler(processEvent.keyhandler);
			//adding handler

			Console.WriteLine(" Adding chars in array " + "(for ending of entering press key <F1>)\n");

			do
			{
				Console.WriteLine("Enter key. ");
				consoleKeyInfo = Console.ReadKey(true);
				// Reading
				keyEvent.OnKeyPress(consoleKeyInfo);
				//Invoke event
				str += consoleKeyInfo.KeyChar;
				//Writing in variable
			} while (consoleKeyInfo.Key != ConsoleKey.F1);

			Console.WriteLine("Array of chars: " + str);

			Console.WriteLine("For exit press <Enter>");
			Console.ReadKey();
		}
	}
}
