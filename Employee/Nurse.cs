using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class Nurse : Employee   
    {
        public int Grade { get; set; }
        public string Specialism { get; set; }

        //Constructor

        public Nurse(string name, string address, string phone, int grade, string specialism)
            : base(name, address, phone)
        {
            Grade = grade;
            Specialism = specialism;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Specialism {0} - Grade {1}", Specialism, Grade);

        }

        public override decimal GetMonthlySalary()
        {
            return Salary / 12m;
        }
    }
}
