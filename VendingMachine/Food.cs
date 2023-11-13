using System;

namespace VendingMachine
{
	/// <summary>
	/// The class for food products
	/// </summary>
	internal class Food : Product
	{
		/// <summary>
		/// Create new food product
		/// </summary>
		/// <param name="initName">The name of the product</param>
		/// <param name="description">The description of the product</param>
		public Food(string initName , string description)
		{
			Name = initName;
			Price = 25;
			Description = description;
		}
		/// <summary>
		/// Get information of the food product
		/// </summary>
		public override void GetInfo()
		{
			Console.WriteLine(Description);
		}
		/// <summary>
		/// Purchase the food product
		/// </summary>
		/// <returns>The price of the product</returns>
		public override int Purchase()
		{
			Console.WriteLine($"The {Name} cost {Price}.");

			return Price;
		}

		/// <summary>
		/// Use the food product
		/// </summary>
		public override void Use()
		{
			Console.WriteLine($"Eat the {Name}");
		}
	}
}
