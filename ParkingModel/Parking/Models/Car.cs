using System;
namespace Parking.Models
{
    public class Car: Vehicle
    {
        static int counter = 0;
        public Car(string mark, string no)
            :base(no)
        {
            if (mark.Length < 3)
            {
                throw new Exception("Marka adı minimum 3 hərf olmalıdır!\n");
            }
            this.Mark = mark;

            string id = (++counter).ToString();

            id = id.Length switch
            {
                1 => mark[0] + "000" + id,
                2 => mark[0] + "00" + id,
                3 => mark[0] + "0" + id,
                _ => mark[0] + id,
            };

            this.Id = id.ToUpper();
        }

        public string Id { get; private set; }

        public string Mark { get; private set; }

        public override string ToString()
        {
            return $"Id: \t{this.Id}\n" +
                $"Mark: \t{this.Mark}\n" +
                $"NO: \t{this.No}\n";
        }
    }
}
