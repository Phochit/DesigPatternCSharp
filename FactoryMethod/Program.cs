using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    // Product
    abstract class Ingredient
    {
    }

    // Concrete Product
    class Batter : Ingredient
    {
    }

    // Concrete Product
    class Pea : Ingredient
    {
    }

    // Concrete Product
    class Sesame : Ingredient
    {
    }

    // Concrete Product
    class Jaggery : Ingredient
    {
    }

    // Concrete Product
    class Coconut : Ingredient
    {
    }

    // Concrete Product
    class Oil : Ingredient
    {
    }

    // Creator
    abstract class Pancake
    {
        private List<Ingredient> ings = new List<Ingredient>();

        public List<Ingredient> Ings
        {
            get { return ings; }
        }

        public abstract void CreateIngredients();

        public Pancake()
        {
            CreateIngredients();
        }
    }

    // Concrete Creator
    class Red_Pancake : Pancake
    {
        public override void CreateIngredients()
        {
            Ings.Add(new Batter());
            Ings.Add(new Jaggery());
            Ings.Add(new Coconut());
            Ings.Add(new Oil());
        }
    }

    // Concrete Creator
    class White_Pancake : Pancake
    {

        public override void CreateIngredients()
        {

            Ings.Add(new Batter());
            Ings.Add(new Pea());
            Ings.Add(new Sesame());
            Ings.Add(new Oil());
        }
    }
    internal class Program
    {
       
        static void Main(string[] args)
        {
            var redPan=new Red_Pancake();
            foreach(var res in  redPan.Ings)
                Console.WriteLine(res);
        }
    }
}
