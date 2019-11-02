using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs6
{
    enum DrinkType { Juice, Coctails, Alcohol }
    class Drink : IComparable, IComparable<Drink>, IEquatable<Drink>
    {
        //о назва
        public string name { get; set; }
        //o тип напою(власного перелічувального типу)
        public DrinkType type { get; set; }
        //o виробник
        public string production { get; set; }
        //o кількість ккал
        public int calories { get; set; }
        //o ціна
        public float price { get; set; }
        //методами
        //o конструктори
        public Drink(string name_, DrinkType type_, string production_, int calories_, float price_)
        {
            name = name_;
            type = type_;
            production = production_;
            calories = calories_;
            price = price_;
        }
        //o перевизначити метод ToString()
        public override string ToString()
        {
            return $"Name:       {name}\n" +
                   $"Type:       {type}\n" +
                   $"Production: {production}\n" +
                   $"Calories:   {calories}\n" +
                   $"Price:      {price}";
        }
        //o реалізувати інтерфейс IComparable(як метод класу int CompareTo(object)) :
        //порівнювати напої за типом, потім за назвою
        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Null obj");
            if (!(obj is Drink))
                throw new ArgumentException("Invalid obj type");
            Drink product = (Drink)obj;
            if (this.type == product.type)
                return this.name.CompareTo(product.name);
            else
                return this.type.CompareTo(product.type);
        }
        //o реалізувати інтерфейс IComparable< >(як метод класу int CompareTo(Drink)) :
        //порівнювати за назвою напою
        public int CompareTo(Drink other)
        {
            return this.name.CompareTo(other.name);
        }

        public bool Equals(Drink other)
        {
            if ((object)other != null)
                return this.CompareTo(other) == 0;//this == other;
            else
                throw new NotImplementedException();
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Drink drink = obj as Drink;
            return this.Equals(drink);
        }

        public override int GetHashCode()
        {
            return (name + production).GetHashCode();
        }

        public static bool operator ==(Drink drink1, Drink drink2)
        {
            if (ReferenceEquals(drink1, drink2))
                return true;
            if ((object)drink1 == null)
                return false;
            return drink1.Equals(drink2);
        }

        public static bool operator !=(Drink drink1, Drink drink2)
        {
            return !(drink1 == drink2);
        }
    }

    //Визначити 3 класи компараторів, які реалізують інтерфейс IComparer, тобто метод int
    //Compare(object, object) для
    //o порівняння напоїв за ціною(за зростанням)
    class PriceComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Drink && y is Drink)
                return (x as Drink).price.CompareTo((y as Drink).price);
            else
                throw new NotImplementedException();
        }
    }
    //o порівняння напоїв за енергетичною цінністю, ккал(спаданням)
    class CaloriesComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Drink && y is Drink)
                return (y as Drink).calories.CompareTo((x as Drink).calories);
            else
                throw new NotImplementedException();
        }
    }
    //o порівняння за виробником(за зростанням)
    class ProductionComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Drink && y is Drink)
                return (x as Drink).production.CompareTo((y as Drink).production);
            else
                throw new NotImplementedException();
        }
    }
    //Визначити 3 класи компараторів, які реалізують інтерфейс IComparer<Drink>, тобто метод int
    //Compare(Drink, Drink) для
    //o порівняння за ціною(за спаданням)
    class DrinkPriceComparer : IComparer<Drink>
    {
        public int Compare(Drink x, Drink y)
        {
            if ((object)x != null && (object)y != null)
                return y.price.CompareTo(x.price);
            else
                throw new NotImplementedException();
        }
    }
    //o порівняння за ккал(зростанням)
    class DrinkCaloriesComparer : IComparer<Drink>
    {
        public int Compare(Drink x, Drink y)
        {
            if ((object)x != null && (object)y != null)
                return y.calories.CompareTo(x.calories);
            else
                throw new NotImplementedException();
        }
    }
    //o порівняння за виробником(зростання)
    class DrinkProductionComparer : IComparer<Drink>
    {
        public int Compare(Drink x, Drink y)
        {
            if ((object)x != null && (object)y != null)
                return x.production.CompareTo(y.production);
            else
                throw new NotImplementedException();
        }
    }
}
