using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Caja
    {
        public int Id { get; set; }
        public List<Ticket> tickets { get; private set; }

        //Delegate: puntero a funcion que determina la forma de la funcion, es decir, parametros y el tipo del return
        public delegate void TotalEventHandler(object o, TotalEventArgs e);
        //Evento que esta basado en el delegate, es decir, que contendra la forma especificada en el delegate
        public event TotalEventHandler Total;
        public Caja()
        {
            this.tickets = new List<Ticket>();
        }

        public void cobrar(int id,decimal importe)
        {
            Console.WriteLine("Cobrando");
            OnTotal(id,importe);
        }
        public virtual void OnTotal(int id, decimal importe)
        {
            /*Hay que ver "Total" como una lista de los suscriptores. Por tanto, si no esta vacia
            notificamos a cada uno de la lista lanzando el evento. Le pasamos al suscriptor la Caja, por eso se pone "this", que seria
            me mando a mi mismo y los argumentos extra encapsulados en la clase TotalEventsArgs*/
            var handler = Total;
            if (null != handler)
            {
                handler(this, new TotalEventArgs(id,importe));
            }
        }

        public class TotalEventArgs : EventArgs
        {
            public int Id { get; private set; }
            public decimal Total { get; private set; }
            public TotalEventArgs(int id, decimal total)
            {
                Id = id;
                Total = total;
            }

        }
    }
}
