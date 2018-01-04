using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    class Display
    {
        private float size;
        private int colorsCount;

        public Display(float size, int colorsCount)
        {
            this.Size = size;
            this.ColorsCount = colorsCount;
        }

        public float Size
        {
            get => this.size;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Ivalid display size format!");
                }

                this.size = value;
            }
        }

        public int ColorsCount
        {
            get => this.colorsCount;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Invalid display number of colors format!");
                }

                this.colorsCount = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Display size: {this.Size} inch");
            sb.Append($"Display colors count: {this.ColorsCount}");

            return sb.ToString();
        }
    }
}
