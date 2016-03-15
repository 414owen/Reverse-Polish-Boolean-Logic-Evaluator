﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            while (true) {
                try {
                    Console.WriteLine("Reverse Polish Boolean Logic Evaluator");
                    Console.WriteLine("Enter 'h' for help, or 'q' for quit");
                    string line = Console.ReadLine();
                    var tokens = line.Split().Select(s => char.ToUpper(s[0])).ToList();
                    if (tokens[0] == 'q' || tokens[0] == 'Q') { break; }
                    else if (tokens[0] == 'h' || tokens[1] == 'H') {
                        PrintHelp();
                        continue;
                    }
                    Stack<bool> stack = new Stack<bool>();
                    foreach (char token in tokens) {
                        switch (token) {
                            case '0':
                                stack.Push(false);
                                break;
                            case '1':
                                stack.Push(true);
                                break;
                            case 'N':
                                bool b = stack.Pop();
                                stack.Push(!b);
                                break;
                            case 'A':
                                bool c = stack.Pop();
                                bool d = stack.Pop();
                                stack.Push(d && c);
                                break;
                            case 'R':
                                bool e = stack.Pop();
                                bool f = stack.Pop();
                                stack.Push(e || f);
                                break;
                            case 'X':
                                bool g = stack.Pop();
                                bool h = stack.Pop();
                                stack.Push(g ^ h);
                                break;
                            default:
                                PrintError();
                                break;
                        }
                    }
                    Console.WriteLine((stack.Pop() ? 1 : 0) + "\n");
                }
                catch (Exception e) {
                    PrintError();
                }
            }
        }

        private static void PrintError() {
            Console.WriteLine("Something went wrong, try entering 'h' for help\n");
        }

        private static void PrintHelp() {
            Console.WriteLine("0: true\n"
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