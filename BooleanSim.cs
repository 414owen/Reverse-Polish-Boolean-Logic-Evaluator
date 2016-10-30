using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
	class BooleanSim {
		static void Main(string[] args) {
			Console.WriteLine("Reverse Polish Boolean Logic Evaluator");
			Console.WriteLine("Enter 'h' for help, or 'q' for quit");
			while (true) {
				Console.Write(" -> ");
				string line = Console.ReadLine();
				var tokens = line.Split().Select(s => char.ToLower(s[0])).ToList();
				if (tokens[0] == 'q') { break; }
				else if (tokens[0] == 'h') {
					PrintHelp();
					continue;
				}
				Stack<bool> stack = new Stack<bool>();
				bool invalidInput = false;
				foreach (char token in tokens) {
					switch (token) {
						case '0':
							stack.Push(false);
							break;
						case '1':
							stack.Push(true);
							break;
						case 'n':
							bool b = stack.Pop();
							stack.Push(!b);
							break;
						case 'a':
							bool c = stack.Pop();
							bool d = stack.Pop();
							stack.Push(d && c);
							break;
						case 'r':
							bool e = stack.Pop();
							bool f = stack.Pop();
							stack.Push(e || f);
							break;
						case 'x':
							bool g = stack.Pop();
							bool h = stack.Pop();
							stack.Push(g ^ h);
							break;
						case 'h':
							PrintHelp();
							break;
						default:
							invalidInput = true;
							break;
					}
				}
				if (invalidInput) {
					Console.WriteLine("Didn't understand that, sorry");
				} else {
					bool res = stack.Pop();
					if (stack.Count == 0) {
						Console.WriteLine("  = " + (res ? 1 : 0));
					} else {
						Console.WriteLine("Malformed expression, finished with more that one element on the stack");
					}
				}
			}
		}

		private static void PrintError() {
			Console.WriteLine("Something went wrong, try entering 'h' for help\n");
		}

		private static void PrintHelp() {
			Console.WriteLine("0: false\n"
				+ "1: true\n"
				+ "A: and\n"
				+ "R: or\n"
				+ "X: xor\n"
				+ "N: negation\n"
				+ "\n"
				+ "Here's an example:\n"
				+ "0 0 A 0 N 0 N A R\n"
				+ "\n"
				+ "0 and 0 = 0\n"
				+ "not 0 = 1\n"
				+ "not 0 = 1\n"
				+ "1 and 1 = 1\n"
				+ "0 or 1 = 1\n"
				+ "\n"
				+ "Therefore, the answer is 1\n");
		}
	}
}
