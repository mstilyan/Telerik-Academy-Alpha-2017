using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    class GSM
    {
        private float? price;
        private int? ownerId;

        static GSM()
        {
            IPhone4S = new GSM("iPhone 4S", "Apple", 600, 
                battery : new Battery("A1586", BatteryType.Li_Ion), 
                display: new Display(3.5f , 2056));
        }

        public GSM(string model, string manufacturer, float? price = null, 
            int? ownerId = null, Battery battery = null, Display display = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.OwnerId = ownerId;
            this.Battery = battery;
            this.Display = display;
            this.CallHistory = new LinkedList<Call>();
        }

        public LinkedList<Call> CallHistory { get; }

        public string Model { get; set; }

        public static GSM IPhone4S { get; }

        public string Manufacturer { get; set; }

        public float? Price
        {
            get => this.price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price not in the correct format!");
                }
                this.price = value;               
            }
        }

        public int? OwnerId
        {
            get => this.ownerId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ivalid owner id format!");
                }
                this.ownerId = value;
            }
            
        }

        public Battery Battery { get; set; }

        public Display Display { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"GSM model: {this.Model}");
            sb.Append($"GSM manufacturer: {this.Manufacturer}");

            if (this.Price != null)
            {
                sb.AppendLine();
                sb.Append($"GSM price: {this.Price:F2}$");
            }
            if (this.OwnerId != null)
            {
                sb.AppendLine();
                sb.Append($"Owner ID: {this.OwnerId}");
            }
            if (this.Battery != null)
            {
                sb.AppendLine();
                sb.Append($"{this.Battery}");
            }
            if (this.Display != null)
            {
                sb.AppendLine();
                sb.Append($"{this.Display}");
            }

            if (this.CallHistory.Count != 0)
            {
                sb.AppendLine();
                sb.Append("Call history:");

                foreach (var call in CallHistory)
                {
                    sb.AppendLine();
                    sb.Append(call);
                }
            }

            return sb.ToString();
        }

        public void ClearHistory()
        {
            CallHistory.Clear();
        }

        public double CalculateTotalPrice(float pricePerMin)
        {
            double totalPrice = 0;
            foreach (var call in CallHistory)
            {
                totalPrice += call.Duration / 60f * pricePerMin;
            }

            return totalPrice;
        }
    }
}
