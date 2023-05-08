using System;
using Helper;
using Parking.library;
using Parking.Models;

namespace Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.SetDefaults();

            if (ConsoleHeader.BlackValue() == 0)
            {
                ConsoleHeader.Header("Parking App", '*', color: ConsoleColor.DarkGray, headeColor: ConsoleColor.DarkYellow);
            }
            else
            {
                ConsoleHelper.Header("Parking App", '*', color: ConsoleColor.DarkGray, headeColor: ConsoleColor.DarkYellow);
            }

            ParkingStore<Car> parkingStore = new ParkingStore<Car>(5, "28 May");
            parkingStore.OnCapacityOverflow += ParkingStore_OnCapacityOverflow;
            parkingStore.OnOutOfRangeOverflow += ParkingStore_OnOutOfRangeOverflow;
            parkingStore.OnOutOfParking += ParkingStore_OnOutOfParking;

            parkingStore.In(new Car("bmw", "90-ab-202"));
            parkingStore.In(new Car("bmw", "90-zz-212"));
            parkingStore.In(new Car("ford", "10-bf-543"));
            parkingStore.In(new Car("tesla", "64-vf-657"));
            parkingStore.In(new Car("ferrari", "43-gf-323"));
            parkingStore.In(new Car("bmw", "90-zz-212"));

            foreach (var item in parkingStore.GetAll())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(parkingStore);


            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(new string('`', Console.WindowWidth));
            if (ConsoleHeader.BlackValue() == 0)
            {
                Console.ForegroundColor = (ConsoleColor)(15);
            }
            else
            {
                Console.ForegroundColor = (ConsoleColor)(-1);
            }

            Console.WriteLine();

            Car car = new Car("Tesla", "66-ff-333");

            parkingStore.Out(car);

            parkingStore.OutAt(65);

            Console.WriteLine(car);

            Console.ReadKey();
        }

        private static void ParkingStore_OnOutOfParking(object sender, EventArguments.OutOfParkingArgs e)
        {
            ParkingStore<Car> parking = sender as ParkingStore<Car>;

            if (parking == null)
            {
                throw new Exception();
            }

            Console.WriteLine($"{parking.Name} otoparkına {e.Vehicle.No} nömrəli nəqliyyat vasitəsi daxil olmayıb!\n");
        }

        private static void ParkingStore_OnOutOfRangeOverflow(object sender, EventArguments.OutOfRangeOverflowArgs e)
        {

            ParkingStore<Car> parking = sender as ParkingStore<Car>;

            if (parking == null)
            {
                throw new Exception();
            }

            Console.WriteLine($"{parking.Name} otoparkında indeks aralığı: 0-{e.Capacity - 1}-d{DataHelper.IntAZSuffix(e.Capacity - 1)}r.\n" +
                $"Yazdığınız {e.ValueIndex} indeksi  aralıqdan kənardır!\n");

        }

        private static void ParkingStore_OnCapacityOverflow(object sender, EventArguments.CapacityOverflowArgs e)
        {
            ParkingStore<Car> parking = sender as ParkingStore<Car>;

            if (parking == null)
            {
                throw new Exception();
            }

            Console.WriteLine($"\nÜmumi yer sayı {e.Capacity}-d{DataHelper.IntAZSuffix(e.Capacity)}r. " +
                $"\n{e.Message}");
        }
    }
}
