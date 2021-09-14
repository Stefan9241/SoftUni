using System;

namespace CompositePattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("Phone", 256);
            phone.CalculatePrice();
            Console.WriteLine();

            CompositeGift rootBox = new CompositeGift("RootBox", 0);
            SingleGift toy = new SingleGift("Toy", 587);
            SingleGift truck = new SingleGift("Truck", 289);

            rootBox.Add(toy);
            rootBox.Add(truck);

            CompositeGift childBox = new CompositeGift("ChildBox", 0);
            SingleGift soldier = new SingleGift("Soldier", 200);

            childBox.Add(soldier);

            rootBox.Add(childBox);

            Console.WriteLine($"The total price of the composite present is {rootBox.CalculatePrice()}");
        }
    }
}
