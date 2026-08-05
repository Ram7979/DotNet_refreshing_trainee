using System;
using System.Collections.Generic;

public class Program{
    public static SortedDictionary<int, Bike> bikeDetails =new SortedDictionary<int, Bike>();
    public static void Main(string[] args){
        BikeUtility u = new BikeUtility();
        while(true){
            Console.WriteLine("1 Add Bike Details");
            Console.WriteLine("2 Group Bikes By Brand");
            Console.WriteLine("3 Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1){
                Console.Write("Enter the model: ");
                string model = Console.ReadLine();

                Console.Write("Enter the brand: ");
                string brand = Console.ReadLine();

                Console.Write("Enter the price per day: ");
                int price = Convert.ToInt32(Console.ReadLine());

                u.AddBikeDetails(model, brand, price);

                Console.WriteLine("Bike details added successfully");
                Console.WriteLine();
            }
            else if(choice == 2){
                SortedDictionary<string, List<Bike>> bikes =u.GroupBikesByBrand();

                foreach(var brand in bikes){
                    foreach (Bike bike in brand.Value){
                        Console.WriteLine(brand.Key + " " + bike.Model);
                    }
                }

                Console.WriteLine();
            }
            else if(choice == 3){
                break;
            }
            else{
                Console.WriteLine("Invalid Choice");
                Console.WriteLine();
            }
        }
    }
}