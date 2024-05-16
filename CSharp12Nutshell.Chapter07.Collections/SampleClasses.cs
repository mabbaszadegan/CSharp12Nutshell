using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter07.Collections
{
    public class MyCollection : IEnumerable
    {
        int[] data = { 1, 2, 3 };

        public IEnumerator GetEnumerator()
        {
            foreach (int i in data)
                yield return i;
        }
    }

    public class MyGenCollection : IEnumerable<int>
    {
        int[] data = { 1, 2, 3 };

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int i in data)
                yield return i;
        }

        // Explicit implementation keeps it hidden:
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Animal
    {
        public string Name;
        public int Popularity;
        public Zoo Zoo { get; internal set; }
        public Animal(string name, int popularity)
        {
            Name = name; Popularity = popularity;
        }
    }
    public class AnimalCollection : Collection<Animal>
    {
        Zoo zoo;
        public AnimalCollection(Zoo zoo) { this.zoo = zoo; }

        protected override void InsertItem(int index, Animal item)
        {
            base.InsertItem(index, item);
            item.Zoo = zoo;
        }
        protected override void SetItem(int index, Animal item)
        {
            base.SetItem(index, item);
            item.Zoo = zoo;
        }
        protected override void RemoveItem(int index)
        {
            this[index].Zoo = null;
            base.RemoveItem(index);
        }
        protected override void ClearItems()
        {
            foreach (Animal a in this) a.Zoo = null;
            base.ClearItems();
        }
    }

    public class Zoo
    {
        public readonly AnimalCollection Animals;
        public Zoo() { Animals = new AnimalCollection(this); }
    }

}
