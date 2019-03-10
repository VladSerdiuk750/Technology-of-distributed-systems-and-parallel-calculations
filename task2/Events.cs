using System;

namespace task2
{
	class KeyEventArgs : EventArgs
	{
		public ConsoleKeyInfo consoleKeyInfo;
	}

	delegate void KeyHandler(object source, KeyEventArgs args);

	class KeyEvent
	{
		public event KeyHandler KeyPress;

		public void OnKeyPress(ConsoleKeyInfo consoleKeyInfo)
		{
			var keyEventArgs = new KeyEventArgs();
			if (KeyPress != null)
			{
				keyEventArgs.consoleKeyInfo = consoleKeyInfo;
				KeyPress(this, keyEventArgs);
			}
		}
	}

	class ProcessKey
	{
		public void keyhandler(object source, KeyEventArgs args) => 
							Console.WriteLine($"You pressed key: {args.consoleKeyInfo.Key} (key '{args.consoleKeyInfo.KeyChar}')");
	}
}
