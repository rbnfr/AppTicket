using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var caja = new Caja() { };
            caja.Total += Caja_Total;
            // caja.Total -= Caja_Total;
            int id = 2;
            decimal importe = 20;
            caja.cobrar(id,importe);
            Console.ReadLine();

        }

        private static void Caja_Total(object o, Caja.TotalEventArgs e)
        {
            Console.WriteLine("Oyente lo ha oido");
        }
    }
}
