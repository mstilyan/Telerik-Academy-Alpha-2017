using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    class Battery
    {
        private string model;

        public Battery(string model, BatteryType batteryType)
        {
            this.Model = model;
            this.BatteryType = batteryType;

            SetBatteryDuration();

        }

        public BatteryType BatteryType { get; }

        public string Model
        {
            get => this.model;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Ivalid battery model foramt!");
                }

                this.model = value;
            }
        }

        public TimeSpan HoursTalk { get; private set; }

        public TimeSpan HoursIdle { get; private set; }

        private void SetBatteryDuration()
        {
            if (this.BatteryType == BatteryType.Li_Ion)
            {
                this.HoursIdle = new TimeSpan(48, 0, 0);
                this.HoursTalk = new TimeSpan(12, 0, 0);
            }
            else if (this.BatteryType == BatteryType.NiMH)
            {
                this.HoursIdle = new TimeSpan(72, 0, 0);
                this.HoursTalk = new TimeSpan(24, 0, 0);
            }
            else if (this.BatteryType == BatteryType.NiCd)
            {
                this.HoursIdle = new TimeSpan(96, 0, 0);
                this.HoursTalk = new TimeSpan(36, 0, 0);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Battery model: {this.Model}");
            sb.AppendLine($"Battery type: {this.BatteryType}");
            sb.AppendLine($"Hours left idle: {this.HoursIdle:c}");
            sb.Append($"Hours left talk: {this.HoursTalk:c}");

            return sb.ToString();
        }
    }
}
