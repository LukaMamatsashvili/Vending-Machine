using System;
using Vending_Machine.Strategy;

namespace Vending_Machine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Controller c = new Controller();
            c.VMController();
        }
    }
}