using System;

namespace task3
{
	class CarEventArgs : EventArgs
	{
		public string oldName;
		public string newName;
	}

	delegate void CarEventHandler(object source, CarEventArgs carEventArgs);

	class CarEvent
	{
		public event CarEventHandler CarNameChange;

		public void OnCarNameChange(string oldName, string newName)
		{
			var carEventArgs = new CarEventArgs();
			if (CarNameChange != null)
			{
				carEventArgs.oldName = oldName;
				carEventArgs.newName = newName;
				CarNameChange(this, carEventArgs);
			}
		}
	}

	class ConfirmingNameChange
	{
		public void handler(object source, CarEventArgs carEventArgs) =>
														Console.WriteLine($"Do you really wanna change the name of the car to {carEventArgs.newName}? (Y-yes, N-no)");
	}

	class ProcessNameChange
	{
		public void handler(object source, CarEventArgs carEventArgs) =>
														Console.WriteLine($"The name of the car changed from {carEventArgs.oldName} to {carEventArgs.newName}.");
	}

}
