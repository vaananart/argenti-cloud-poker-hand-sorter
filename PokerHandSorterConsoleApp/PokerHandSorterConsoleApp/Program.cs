using System;
using System.Collections.Generic;

using PokerHanderSorterService;

namespace PokerHandSorterConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			IList<string> inputs = new List<string>();
			string line = string.Empty;
			bool noNewLines = false;
			
			do
			{
				line = Console.ReadLine();
				if (!string.IsNullOrEmpty(line))
					inputs.Add(line);
				else
					noNewLines = true;

			} while ( noNewLines != true );


			Console.WriteLine("\n==Feed Back== \n");
			foreach (var lineElement in inputs)
				Console.WriteLine(lineElement);
			//var sortService = new SorterService(inputs);

		}
	}
}
