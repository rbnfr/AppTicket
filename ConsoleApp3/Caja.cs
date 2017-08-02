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
        public decimal ImporteTotal { get; set; }
        public List<Ticket> tickets { get; private set; }
        //Delegate: puntero a funcion que determina la forma de la funcion, es decir, parametros y el tipo del return
        public delegate void TotalEventHandler(object o, TotalEventArgs e);
        //Evento que esta basado en el delegate, es decir, que contendra la forma especificada en el delegate
        public event TotalEventHandler Total;

        public Caja()
        {
            this.tickets = new List<Ticket>();
        }

        private bool CajaEnRiesgo(Ticket ticket)
        {
            if (ImporteTotal > 200)
            {
                Console.WriteLine("Ha superado 200, se llama al oyente si esta suscrito");
                ImporteTotal = 0;
                return true;
            }
            return false;
        }

        public void addTicket(Ticket ticket)
        {
            if (null == ticket)
            {
                throw new Exception("Ticket nulo");
            }
            Console.WriteLine("Almacenando " + ticket.Total + "-> Importe total=" + ImporteTotal);
            tickets.Add(ticket);
            ImporteTotal += ticket.Total;
            if (CajaEnRiesgo(ticket)){
                OnTotal(new TotalEventArgs(ticket.Id,ticket.Total));
            }          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnTotal(TotalEventArgs e)
        {
            /*Hay que ver "Total" como una lista de los suscriptores. Por tanto, si no esta vacia
            notificamos a cada uno de la lista lanzando el evento. Le pasamos al suscriptor la Caja, por eso se pone "this", que seria
            me mando a mi mismo y los argumentos extra encapsulados en la clase TotalEventsArgs*/
            var handler = Total;
            if (null != handler)
            {
                handler(this, e);
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
