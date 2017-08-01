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
            int id = 2;
            Console.WriteLine("Caso de ticket con 20 euros(no debe avisar a nadie)");
            decimal importe = 20;
            caja.addTicket(id,importe);

            Console.WriteLine("Caso de ticket con 201 euros(debe avisar)");
            importe = 201;
            caja.addTicket(id, importe);

            Console.WriteLine("Caso de añadir 50 cuando y ya habia superado 200(no debe avisar porque se pone a 0)");
            importe = 50;
            caja.addTicket(id, importe);

            Console.WriteLine("Caso de desuscribir al oyente. No importa ahora el importe y no debe oir");
            importe = 200;
            caja.Total -= Caja_Total;
            caja.addTicket(id, importe);

            Console.ReadLine();
        }

        private static void Caja_Total(object o, Caja.TotalEventArgs e)
        {
            Console.WriteLine("Soy el oyente y lo he oido");
        }
    }
}
