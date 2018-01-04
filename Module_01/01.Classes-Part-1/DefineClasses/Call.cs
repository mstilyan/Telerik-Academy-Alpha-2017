using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DefineClasses
{
    class Call
    {
        private string phoneNumber;

        public Call(DateTime date, uint duration, string phoneNumber)
        {
            this.Date = date;
            this.Duration = duration;
            this.PhoneNumber = phoneNumber;
        }

        public DateTime Date { get; set; }
        public uint Duration { get; set; }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (!Regex.IsMatch(value, @"^\+359[0-9]{9}$"))
                {
                    throw new ArgumentException("Phone number not in the correct format!");
                }

                phoneNumber = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Dailed phone number: {this.PhoneNumber}");
            sb.AppendLine($"At: {this.Date.ToString("G", CultureInfo.InvariantCulture)}");
            sb.Append($"Duration: {this.Duration} sec");

            return sb.ToString();
        }
    }
}
