using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_POE_Part1_ST10159078_TebogoHlope

{
    // Class to store details of each ingredient
    class Ingredient
    {
        public string IngredientName { get; set; }
        public float IngredientQuantity { get; set; }
        public string Unit { get; set; }
    }

    // Class to store details of each recipe
    class Recipe
    {
        private int numIngredients;
        private Ingredient[] ingredients;
        private int numSteps;
        private string[] steps;

        public Recipe()
        {
            numIngredients = 0;
            ingredients = new Ingredient[10];
            numSteps = 0;
            steps = new string[10];
        }

        public void AddIngredient(string IngredientName, float IngredientQuantity, string unit)
        {
            if (numIngredients < ingredients.Length)
            {
                ingredients[numIngredients++] = new Ingredient { IngredientName = IngredientName, IngredientQuantity = IngredientQuantity, Unit = unit };
            }
            else 
            {
                Console.WriteLine("Maximum number of ingredients reached!");
            }
        }

        public void AddStep(string step)
        {
            if (numSteps < steps.Length)
          
            {
                steps[numSteps++] = step;
            }
            else
            {
                Console.WriteLine("Maximum number of steps reached!");
            }
        }

        public void PrintRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredients.Take(numIngredients))
            {
                Console.WriteLine("{0} - {1} {2}", ingredient.IngredientName, ingredient.IngredientQuantity, ingredient.Unit);
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, steps[i]);
            }
        }

        public void ScaleRecipe(float factor)
        {
            foreach (Ingredient ingredient in ingredients.Take(numIngredients))
            {
                ingredient.IngredientQuantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in ingredients.Take(numIngredients))
            {
                ingredient.IngredientQuantity /= 2;
            }
        }

        public void ClearRecipe()
        {
            numIngredients = 0;
            numSteps = 0;
        }
    }


    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("1. Add ingredient\n" + "2. Add step\n" + "3. Print recipe\n");
                   Console.WriteLine("4. Scale recipe\n" + "5. Reset the quantities\n" + "6. Clear recipe" + "7. exit \n");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter ingredient name:");
                        string ingredientName = Console.ReadLine();

                        Console.WriteLine("Enter ingredient quantity:");
                        float ingredientQuantity = float.Parse(Console.ReadLine());

                        Console.WriteLine("Enter ingredient unit(L, KG, G, Ml, etc):");
                        string ingredientUnit = Console.ReadLine();

                        recipe.AddIngredient(ingredientName, ingredientQuantity, ingredientUnit);
                        break;

                    case 2:
                        Console.WriteLine("Enter step:");
                        string step = Console.ReadLine();

                        recipe.AddStep(step);
                        break;

                    case 3:
                        recipe.PrintRecipe();
                        break;

                    case 4:
                        Console.WriteLine("Enter scaling factor (0.5, 2, 3):");
                        float factor = float.Parse(Console.ReadLine());

                        recipe.ScaleRecipe(factor);
                        break;

                    case 5:
                        recipe.ResetQuantities();
                        break;

                    case 6:
                        recipe.ClearRecipe();
                        break;

                    case 7:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}