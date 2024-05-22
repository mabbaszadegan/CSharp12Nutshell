using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter08.EFCore.Entities
{
    public class Customer : INotifyPropertyChanged, INotifyPropertyChanging
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public event PropertyChangingEventHandler? PropertyChanging;

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public virtual List<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
