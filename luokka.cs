using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luokkaharjoituksia
{
    class Hooman
    {
        // Define properties of Hooman
        public string name = "Pat Pattern";
        public int age = 30;
        public string gender = "other";

        // Default constructor without argument 
        // No need to define, will be crated automatically
        public Hooman()
        {

        }

        // Consturctor with one argument
        public Hooman(string name)
        {
            this.name = name;
        }

        // Constructor with two arguments
        public Hooman(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // Constructor with three arguments
        public Hooman(string name, int age, string gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }
        
        public void SayOpinion()
        {
            Console.WriteLine("Voi lemmikit ne on elämän suloa");
        }
    }

    class DogOwner : Hooman
    {
        public new void SayOpinion()
        {
            Console.WriteLine("Koira on uskollinen ja luotettava kumppani, ihmisen paras ystävä");
        }
    }

    class Pet
    {
        public string name = "Beasty";

        public Pet() { }

        public Pet(string name)
        {
            this.name = name;
        }

        public virtual void Eats()
        {
            Console.WriteLine(this.name + " eats food.");
        }
    }

    class Hare : Pet  
    {   
        public Hare() { }

        public Hare(string name)
        {
            this.name = name;
        }
        public override void Eats()
        {
            Console.WriteLine(this.name + " eats carrots");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create (instantiate) a hooman object from Hooman class
            Hooman owner = new Hooman("Sandro Wüthrich", 45, "mies");

            // Call say Opinion method
            owner.SayOpinion();

            string who = owner.name;

            Console.WriteLine("totesi " + who);

            DogOwner dogOwner = new DogOwner();
            dogOwner.SayOpinion();

            Pet myPet = new Pet("Perry");
            myPet.Eats();

            Hare peeky = new Hare("Bulby");
            peeky.Eats();

            
            Console.ReadLine();
        }
    }

    
    
}