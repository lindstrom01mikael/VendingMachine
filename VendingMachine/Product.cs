namespace VendingMachine
{
	internal abstract class Product
	{
		// Some properties
		public string Name { get; set; }
		public int Price { get; set; }
		public string Description { get; set; }

		// Some abstract methods
		public abstract int Purchase();
		public abstract void GetInfo();
		public abstract void Use();
	}
}
