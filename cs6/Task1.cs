using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs6
{
    interface IWalk
    {
        void Walk();
    }
    interface IEat
    {
        void Eat();
    }
    interface ISleep
    {
        void Sleep();
    }
    abstract class Animal : IWalk, IEat, ISleep
    {
        public string Name { get; set; }

        public virtual void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping");
        }

        public void Walk()
        {
            Console.WriteLine($"{Name} is walking.");
        }
    }
    class Bear : Animal
    {
        public Bear(string name) { Name = name; }
        public override string ToString()
        {
            return $"Bear {Name}";
        }
    }
    class Parrot : Animal
    {
        public Parrot(string name) { Name = name; }
        public override string ToString()
        {
            return $"Parrot {Name}";
        }
    }
    class Fox : Animal
    {
        public Fox(string name) { Name = name; }
        public override string ToString()
        {
            return $"Fox {Name}";
        }
    }
    interface IWatch
    {
        void Watch(object obj);
    }
    class VideoCamera : IWatch
    {
        public override string ToString()
        {
            return $"Camera";
        }

        public void Watch(object obj)
        {
            Console.WriteLine($"{this.ToString()} is watching {obj?.ToString()}");
        }
    }
    class ZooWorker : IWatch
    {
        public string Name { get; set; }
        public ZooWorker(string name) { Name = name; }
        public override string ToString()
        {
            return $"Zooworker";
        }

        public void Watch(object obj)
        {
            Console.WriteLine($"{this.ToString()} is watching {obj?.ToString()}");
        }
    }
    class Zoo
    {
        List<Animal> animals = new List<Animal>();
        List<ZooWorker> zooworkers = new List<ZooWorker>();
        List<VideoCamera> cameras = new List<VideoCamera>();
    }
}
