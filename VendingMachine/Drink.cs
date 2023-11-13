using System;

namespace VendingMachine
{
	/// <summary>
	/// The class for drink products
	/// </summary>
	internal class Drink : Product
	{
		/// <summary>
		/// Create new drink product
		/// </summary>
		/// <param name="initName">The name of the product</param>
		/// <param name="description">The description of the product</param>
		public Drink(string initName, string description)
		{
			Name = initName;
			Price = 20;
			Description = description;
		}
		/// <summary>
		/// Get information of the drink product
		/// </summary>
		public override void GetInfo()
		{
			Console.WriteLine(Description);
		}
		/// <summary>
		/// Purchase the drink product
		/// </summary>
		/// <returns>The price of the drink product</returns>
		public override int Purchase()
		{
			Console.WriteLine($"The {Name} cost {Price}.");

			return Price;
		}
		/// <summary>
		/// Use the drink product
		/// </summary>
		public override void Use()
		{
			Console.WriteLine($"Drink the {Name}.");
		}
	}
}
