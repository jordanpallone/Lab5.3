using System;
using System.Collections.Generic;

namespace Lab5._3
{
    class Car
    {
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public decimal price { get; set; }

        public Car() //no argu constructor?
        {

        }

        public Car(int pYear, string pMake, string pModel, decimal pPrice)
        {
            make = pMake;
            model = pModel;
            year = pYear;
            price = pPrice;
        }

        public override string ToString()
        {
            return $"{year} \t{make} \t{model} \t\t\t${price}";
        }
    }

    class UsedCar : Car
    {
        public double miles;

        public UsedCar(int pYear, string pMake, string pModel, double pMiles, decimal pPrice)
        {
            make = pMake;
            model = pModel;
            year = pYear;
            price = pPrice;
            miles = pMiles;
        }

        public override string ToString()
        {
            return $"{year} \t{make} \t{model} \t{miles} miles \t${price}";
        }
    }



    class Program
    {
        static void Add(List<Car> list)
        {
            Console.WriteLine("Enter the information about the car you'd like to sell.");
            Console.WriteLine("Year: ");
            int uYear = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Make: ");
            string uMake = Console.ReadLine();
            Console.WriteLine("Model: ");
            string uModel = Console.ReadLine();
            Console.WriteLine("Mileage: ");
            double uMile = Double.Parse(Console.ReadLine());
            Console.WriteLine("Asking price: ");
            decimal uPrice = Decimal.Parse(Console.ReadLine());

            list.Add(new UsedCar(uYear, uMake, uModel, uMile, uPrice));
            Console.WriteLine("Thank you, your car is under review. Someone will be in contact with you shortly.\n");
        }

        static void Remove(List<Car> list, int x)
        {
            Console.WriteLine(list[x]);
            Console.Write("\nWould you like to buy this car? (y/n) ");
            string userBuy = Console.ReadLine();
            if (userBuy == "y")
            {
                list.Remove(list[x]);
                Console.WriteLine("Excellent! Our finance department will be in touch shortly.\n");
            }
            
        }

        static void Main(string[] args)
        {

            List<Car> cars = new List<Car>();
            cars.Add(new Car(2021, "Jeep", "Wrangler", 28575));
            cars.Add(new Car(2021, "Jeep", "Cherokee", 26760));
            cars.Add(new Car(2021, "Jeep", "Compass", 24095));
            cars.Add(new UsedCar(2014, "Jeep", "Compass", 87535, 14590));
            cars.Add(new UsedCar(2017, "Jeep", "Renegade", 75750, 15990));
            cars.Add(new UsedCar(2015, "Jeep", "Patriot", 75191, 14990));

            Console.WriteLine("Welcome to Grant Chirpus' New and Used Jeep Emporium!");
            bool cont = true;

            while (cont)
            {

                for (int i = 0; i < cars.Count; i++)
                {
                    Console.WriteLine($"[{i}] {cars[i]}");
                }
                Console.WriteLine("[6] Add a car\n[7] Quit\n");


                Console.Write("Which car would you like to see? (Select the cooresponding number. '6' to sell a car or '7' to exit) ");
                int choiceNum = Int32.Parse(Console.ReadLine());

                if (choiceNum <= 5 && choiceNum >= 0)
                {
                    Remove(cars, choiceNum);
                }
                else if (choiceNum == 6)
                {
                    Add(cars);
                }
                else if (choiceNum == 7)
                {
                    Console.WriteLine("Goodbye!");
                    cont = false;
                }
                else
                {
                    Console.WriteLine("That's an invalid selection.");
                }
            }




        }
    }
}
