using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter04.Events
{
    //public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);
    public delegate void PriceChangedHandler(object sender, PriceChangedEventArgs e);

}
