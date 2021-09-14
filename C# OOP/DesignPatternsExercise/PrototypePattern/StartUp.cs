using System;

namespace PrototypePattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuse,Tomate");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter,Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuse,Onion,Tomato");

            sandwichMenu["LoadedBLT"] = new Sandwich("Wheat", "", "", "");
            sandwichMenu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey,Ham,Salam", "Provolone", "Lettuce,Onion");
            sandwichMenu["Vegeterian"] = new Sandwich("Wheat", "", "", "Lettuce,Onion,Toamto,Olives,Spinach");

            Sandwich s1 = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich s2 = sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;
            Sandwich s3 = sandwichMenu["Vegeterian"].Clone() as Sandwich;
        }
    }
}
