using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public enum PositionType { Junior, Senior, Student }

    public class Doctor : Employee
    {
        public PositionType Position { get; set; }

        public Doctor(string name, string address, string phoneNumber, PositionType position)
            : base(name, address, phoneNumber)
        {
            Position = position;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Position {0}\n", Position);
        }

        public override string FileFormat()
        {
            return string.Format("{0},{1},{2},{3}", Name, Address, PhoneNumber, Position);
        }

        public override decimal GetMonthlySalary()
        {
            return (Salary / 12m) + 1000m;
        }
    }
}
