using System;

namespace VendingMachine
{
	/// <summary>
	/// The class for snack products
	/// </summary>
	internal class Snack : Product
	{
		/// <summary>
		/// Create new snack product
		/// </summary>
		/// <param name="initName">The name of the product</param>
		/// <param name="description">The description of the product</param>
		public Snack(string initName, string description)
		{
			Name = initName;
			Price = 15;
			Description = description;
		}
		
		/// <summary>
		/// Get information of the snack product
		/// </summary>
		public override void GetInfo()
		{
			Console.WriteLine(Description);
		}
		/// <summary>
		/// Purchase the snack product
		/// </summary>
		/// <returns>The price of snack product</returns>
		public override int Purchase()
		{
			Console.WriteLine($"The {Name} cost {Price}");

			return Price;
		}
		/// <summary>
		/// Use the snack product
		/// </summary>
		public override void Use()
		{
			Console.WriteLine($"Eat the {Name}.");
		}
	}
}
