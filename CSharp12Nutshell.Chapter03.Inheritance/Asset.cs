using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter03.Inheritance
{
    public abstract class Asset
    {
        public string Name;
        public virtual decimal Liability => 0;   // Expression-bodied property
        public abstract decimal NetValue { get; }
        public abstract Asset Clone();
    }

    public class Stock : Asset   // inherits from Asset
    {
        public long SharesOwned;
        public decimal CurrentPrice;

        public override decimal NetValue => CurrentPrice * SharesOwned;

        public override Stock Clone() => new Stock
        {
            Name = Name,
            SharesOwned = SharesOwned,
        };
    }

    public class House : Asset   // inherits from Asset
    {
        public decimal Mortgage;
        public sealed override decimal Liability => base.Liability + Mortgage;

        public override decimal NetValue => throw new NotImplementedException();

        public override House Clone() => new House
        {
            Name = Name,
            Mortgage = Mortgage
        };
    }

    public class Villa : House
    {
        //public override decimal Liability => base.Liability * 1.5M;
    }
}
