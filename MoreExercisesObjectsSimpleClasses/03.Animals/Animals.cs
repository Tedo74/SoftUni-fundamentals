using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Animals
{
    class Animals
    {
        static void Main()
        {
            Dictionary<string, Animal> animals = new Dictionary<string, Animal>();
            List<Dog> dogs = new List<Dog>();
            List<Cat> cats = new List<Cat>();
            List<Snake> snakes = new List<Snake>();
            string input = Console.ReadLine();
            while (input != "I'm your Huckleberry")
            {
                string[] inputs = input.Split(' ');
                if (inputs[0] == "talk")
                {
                    if (animals.ContainsKey(inputs[1]))
                    {
                        Animal a = animals[inputs[1]];
                        a.ProduceSound();
                    }
                }
                else
                {
                    string className = inputs[0];
                    string name = string.Join(" ", inputs.Skip(1).Take(inputs.Length - 3));
                    int age = int.Parse(inputs.Skip(inputs.Length - 2).First());
                    int dependentFromClass = int.Parse(inputs.Skip(inputs.Length - 1).First());
                    switch (className)
                    {
                        case "Dog":
                            Dog d = new Dog(name, age, dependentFromClass);
                            animals.Add(name, d);
                            dogs.Add(d);
                            break;
                        case "Snake":
                            Snake s = new Snake(name, age, dependentFromClass);
                            animals.Add(name, s);
                            snakes.Add(s);
                            break;
                        case "Cat":
                            Cat c = new Cat(name, age, dependentFromClass);
                            animals.Add(name, c);
                            cats.Add(c);
                            break;
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var dog in dogs)
            {
                Console.WriteLine($"Dog: {dog.Name}, Age: {dog.Age}, Number Of Legs: {dog.NumberOfLegs}");
            }
            foreach (var cat in cats)
            {
                Console.WriteLine($"Cat: {cat.Name}, Age: {cat.Age}, IQ: {cat.Iq}");
            }
            foreach (var lady in snakes)
            {
                Console.WriteLine($"Snake: {lady.Name}, Age: {lady.Age}, Cruelty: {lady.CrueltyCoefficient}");
            }
        }
    }

    abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract void ProduceSound();
    }
    class Dog : Animal
    {
        public int NumberOfLegs { get; set; }

        public Dog(string name, int age, int numberOfLegs)
        {
            this.Name = name;
            this.Age = age;
            this.NumberOfLegs = numberOfLegs;
        }
        public override void ProduceSound()
        {
            Console.WriteLine("I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
        }
    }
    class Snake : Animal
    {
        public int CrueltyCoefficient { get; set; }

        public Snake(string name, int age, int crueltyCoefficient)
        {
            this.Name = name;
            this.Age = age;
            this.CrueltyCoefficient = crueltyCoefficient;
        }
        public override void ProduceSound()
        {
            Console.WriteLine("I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home.");
        }
    }
    class Cat : Animal
    {
        public int Iq { get; set; }

        public Cat(string name, int age, int iq)
        {
            this.Name = name;
            this.Age = age;
            this.Iq = iq;
        }
        public override void ProduceSound()
        {
            Console.WriteLine("I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
        }
    }

}
