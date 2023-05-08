using System;
using System.Text;
using Helper;
using Parking.Delegates;
using Parking.EventArguments;
using Parking.library;

namespace Parking.Models
{
    public class ParkingStore<T>
    {
        private T[] data;

        public ParkingStore(int capacity, string name)
        {
            this.Capacity = capacity;
            this.Name = name;
            this.data = new T[0];
        }

        public T this[int i]
        {
            get
            {
                return data[i];
            }
        }

        public int Capacity { get; private set; }
        public int Occupancy
        {
            get
            {
                return data.Length;
            }
        }
        public int Spots
        {
            get
            {
                return Capacity - Occupancy;
            }
        }

        public string Name { get; private set; }

        public event CapacityOverflowHandler OnCapacityOverflow;
        public event OutOfRangeOverflowHandler OnOutOfRangeOverflow;
        public event OutOfParkingHandler OnOutOfParking;


        public T[] GetAll()
        {
            return data;
        }

        public void In(T value)
        {
            if (Capacity <= Occupancy)
            {
                var args = new CapacityOverflowArgs()
                {
                    Capacity = this.Capacity,
                    CurrentCount = this.Occupancy,
                    Message = "Boş yer qalmayıb!\n"
                };

                OnCapacityOverflow?.Invoke(this, args);
                return;
            }

            Array.Resize(ref data, data.Length + 1);
            data[^1] = value;
        }

        public void OutAt(int index)
        {
            if (index >= Occupancy)
            {
                var args = new OutOfRangeOverflowArgs()
                {
                    ValueIndex = index,
                    DataLength = data.Length,
                    Capacity = this.Capacity,
                    CurrentCount = this.Occupancy,
                    Message = "Düzgün index daxil edin!\n"
                };

                OnOutOfRangeOverflow?.Invoke(this ,args);
                return;
            }

            T[] newArr = new T[0];
            for (int i = 0; i < data.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }

                Array.Resize(ref newArr, newArr.Length + 1);
                newArr[^1] = data[i];
            }

            data = newArr;
        }

        public void Out(T value)
        {
            int index = Array.IndexOf(data, value);

            if (index == -1)
            {
                var args = new OutOfParkingArgs()
                {
                    Capacity = this.Capacity,
                    CurrentCount = this.Occupancy,
                    Vehicle = value as Vehicle,
                    Message = "Belə bir minik yoxdur!\n"
                };

                OnOutOfParking?.Invoke(this, args);
                return;
            }

            OutAt(index);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            if (ConsoleHeader.BlackValue() == 0)
            {
                ConsoleHeader.Header($"{this.Name} Otoparkı", '~', color: ConsoleColor.DarkGreen, headeColor: ConsoleColor.Blue);
            }
            else
            {
                ConsoleHelper.Header($"{this.Name} Otoparkı", '~', color: ConsoleColor.DarkGreen, headeColor: ConsoleColor.Blue);
            }

            str.Append($"\nCapacity: {this.Capacity}\n" +
                $"Occupancy: {this.Occupancy}\n" +
                $"Spots: {this.Spots}\n\n");

            int count = 1;
            foreach (var item in data)
            {
                str.Append($"{count:0000}. \n{item}\n");
                count++;
            }

            return str.ToString();
        }

    }
}
