using System;
using System.Collections.Generic;

namespace VendingMachine
{
	/// <summary>
	/// The class for the vending machine itself
	/// </summary>
	internal class Machine
	{
		// A properties for status of machine
		public bool IsAlived { get; set; }

		// Some private field
		private readonly int[] denominations = new int[10] { 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };
		private int[] moneyPool = new int[1];
		private int countBankNotes = 0, sum = 0, temp;
		private IList<Product> products = new List<Product>();

		/// <summary>
		/// Start new machine
		/// </summary>
		public Machine()
		{
			InsertBankNotes();
			CreateProductList();
			Buying();
			ChangeBack();

			// Make a pause in the program
			Console.ReadKey();
		}

		/// <summary>
		/// Insert some banknotes into the machine
		/// </summary>
		private void InsertBankNotes()
		{
			// Set machine status of IsAlived to true
			IsAlived = true;

			do
			{
				// Ask the user to insert money into the machine
				Console.Write("Write which denomination you will insert? (This are allowed ");
				foreach(var item in denominations)
				{
					Console.Write(item);
					Console.Write(", ");
				}
				Console.Write(") ");
				int.TryParse(Console.ReadLine(), out temp);

				for(int i = 0; i < denominations.Length; i++)
				{
					if (denominations[i].Equals(temp))
					{
						moneyPool[countBankNotes] = temp;
						sum += temp;
						countBankNotes++;
						break;
					}
					else if(i == denominations.Length -1)
						Console.WriteLine("The denomination you will insert aren't allowed.");
				}
				// Ask the user if they will insert more
				Console.Write("Will you insert more? ");
				char input = Console.ReadKey().KeyChar;
				Console.WriteLine();

				if (input.Equals('n') || input.Equals("N"))
					IsAlived = false;
				else
					Array.Resize(ref moneyPool, moneyPool.Length + 1);

			} while (IsAlived == true);
			Array.Reverse(moneyPool);
		
		}
		/// <summary>
		/// Give back some banknotes to the user from machine
		/// </summary>
		private void ChangeBack()
		{
			// A array of integer that calculate how much many of each denomination the machine give back
			int[] cashBack = new int[denominations.Length];

			// Set cashBack to zero
			for (int i = 0; i < denominations.Length; i++)
				cashBack[i] = 0;

			// Create a empty console window then show name of the program
			Console.Clear();
			Console.WriteLine(Program.ProgramName);

			// Tell the user about how much the machine give back them.
			Console.WriteLine($"Your shall {sum} money back. That in: ");

			// Calculate which denominations and how much of each that machine give back
			while (sum > 0)
			{
				// Run throw all denomination
				for(int i = denominations.Length-1;i >= 0;i--)
				{
					// Run until the value of sum aren't higher then denominations[i] value
					while ((sum / denominations[i]) > 0)
					{
						// Check if moneyPool are empty or not
						if (moneyPool.Length == 0)
						{
							sum -= denominations[i];
							cashBack[i]++;
						}
						else
						{
							for(int y = 0; y < moneyPool.Length; y++) 
							{
								if (moneyPool[y] == denominations[i])
								{
									sum -= denominations[i];
									cashBack[i]++;

									for(int z = 0; (y+z) < moneyPool.Length-1; z++)
									{
										moneyPool[y + z] = moneyPool[(y + z + 1)];
									}
									Array.Resize(ref moneyPool, moneyPool.Length - 1);
									break;
								}
								else if(y == (moneyPool.Length -1))
								{
									sum -= denominations[i];
									cashBack[i]++;
								}
							}
						}
					}
				}
			}
			// Show the result of calcualtion of what the machine give the user back.
			for(int i = denominations.Length-1; i >= 0;i--)
			{
				if (cashBack[i] != 0)
					Console.WriteLine($"{cashBack[i]} in {denominations[i]}.");
			}

		}
		
		/// <summary>
		/// Add some products to machine
		/// </summary>
		private void CreateProductList()
		{
			products.Add(new Drink("Coca Cola", "Coca Cola are a drink from Coca Cola Corp"));
			products.Add(new Drink("Fanta", "Fanta are a drink from Coca Cola Corp"));
			products.Add(new Snack("Chips", "Chips are make from potato"));
			products.Add(new Food("Sandswich", "Sandswich "));
		}
		/// <summary>
		/// Show list of product in console window
		/// </summary>
		private void ShowProductList()
		{
			// Variables for show product list
			int count = 1;
			int quit = 99;

			// Show product list in console window
			foreach(Product item in products) 
			{
				Console.WriteLine($"{count}. {item.Name} \t {item.Price}");
				count++;
			}

			// Check if machine had more then 97 products then show how user can quit the program
			if (count > 97)
				quit = count + 1;
			Console.WriteLine($"{quit}. Quit the program");
		}
		/// <summary>
		/// The mehtod that give user choise to buy some products from machine
		/// </summary>
		private void Buying()
		{
			// Set status IsAlived to true
			IsAlived = true;

			do
			{
				// Create a empty console window then show name of this program
				Console.Clear();
				Console.WriteLine(Program.ProgramName);

				// Check if the user have some money to buy products for
				if(sum > 0)
				{
					// Tell the user how much the have to buy products for then show a list of products
					Console.WriteLine($"You have {sum} to buy products for.");
					ShowProductList();

					// Ask the user if they will buy any products from list of products
					Console.Write("Will you buy any products? ");
					int.TryParse(Console.ReadLine(), out temp);

					// Check if user will quit the program
					if(products.Count < 97 && temp == 99 || temp == products.Count +1)
						IsAlived = false;
					else
					{
						Product item = products[temp-1];
						sum -= item.Purchase();
						item.Use();

						
					}

					// Make a pause in the program
					Console.ReadKey();
				}
				else
					IsAlived = false;
			} while (IsAlived == true);
		}


	}
}
