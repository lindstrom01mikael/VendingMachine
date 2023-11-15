using System;

namespace VendingMachine
{
	/// <summary>
	/// The start class for this program
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// The name of this program
		/// </summary>
		public const string ProgramName = "The Vending Machine 2000";
		
		/// <summary>
		/// The start point of this program
		/// </summary>
		/// <param name="args">Anything</param>
		static void Main(string[] args)
		{
			// Welcome the user to this program
			Console.WriteLine($"Welcome to {ProgramName}!");

			// Make a pause in this program
			Console.ReadKey();

			// Start the machine
			Machine machine = new Machine();
		}
	}
}
