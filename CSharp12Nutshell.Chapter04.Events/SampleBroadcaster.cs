using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter04.Events
{
    internal class SampleBroadcaster
    {
        //public event PriceChangedHandler PriceChanged;

        PriceChangedHandler priceChanged;   // private delegate
        public event PriceChangedHandler PriceChanged
        {
            add { priceChanged += value; }
            remove { priceChanged -= value; }
        }
    }

    public class Stock
    {
        string symbol;
        decimal price;

        public Stock(string symbol) => this.symbol = symbol;


        //private EventHandler priceChanged;         // Declare a private delegate
        //public event EventHandler PriceChanged
        //{
        //    add { priceChanged += value; }
        //    remove { priceChanged -= value; }
        //}

        //public event PriceChangedHandler PriceChanged;  // old way without generic delegate
        public event EventHandler<PriceChangedEventArgs> PriceChanged;
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            //if (PriceChanged != null) PriceChanged(this, e);

            //way 1
            //var temp = PriceChanged;
            //if (temp != null) temp(this, e);

            //way 2
            PriceChanged?.Invoke(this, e);
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (price == value) return;      // Exit if nothing has changed
                decimal oldPrice = price;
                price = value;
                //if (PriceChanged != null)           // If invocation list not
                //    PriceChanged(oldPrice, price);   // empty, fire event.

                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }
    }

    public class PriceChangedEventArgs : System.EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }

    public class Foo
    {
        public static event EventHandler<EventArgs> StaticEvent;
        public virtual event EventHandler<EventArgs> VirtualEvent;
    }
}
