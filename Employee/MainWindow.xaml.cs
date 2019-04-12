using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace Ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Employee> hospitalStaffList = new ObservableCollection<Employee>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGetEmployees_Click(object sender, RoutedEventArgs e)
        {
            //Employee emp1 = new Employee("Tom","123 Meadow Lane", "071 123456");
            //Employee emp2 = new Employee("Sally", "5a Seaview", "086 123456");
            //Employee emp3 = new Employee("Jo", "Ash Lane", "087 123456");

            //Create Nurse objects

            Nurse nurse1 = new Nurse("Mary", "Hospital Rd", "091 777 6666", 1, "Paediatrics");
            Nurse nurse2 = new Nurse("Sue", "Hospital Road", "086 666 7777", 2, "Casualty");


            //Crate Doctor Objects
            Doctor doc1 = new Doctor("George", "Doc St", "091 333 4444", PositionType.Junior);
            Doctor doc2 = new Doctor("Alison", "John Street", "085 123 4444", PositionType.Senior);

            //Add Employees to List
            //hospitalStaffList.Add(emp1);
            //hospitalStaffList.Add(emp2);
            //hospitalStaffList.Add(emp3);

            hospitalStaffList.Add(nurse1);
            hospitalStaffList.Add(nurse2);

            hospitalStaffList.Add(doc1);
            hospitalStaffList.Add(doc2);

            lbxEmployees.ItemsSource = hospitalStaffList;
        }

        private void WriteToFile(ObservableCollection<Employee> staff)
        {
            string[] employees = new string[staff.Count];

            Employee e;

            for (int i = 0; i < staff.Count; i++)
            {
                {
                    e = staff.ElementAt(i);
                    employees[i] = e.FileFormat();
                }

                File.WriteAllLines(@"c:\temp\Employees.txt", employees);
            }
        }

        private void BtnSaveEmployees_OnClick(object sender, RoutedEventArgs e)
        {
            WriteToFile(hospitalStaffList);
        }

        //determine the types of objects in list
        private void BtnGetType_OnClick(object sender, RoutedEventArgs e)
        {
            int employees = 0, doctors = 0, nurses = 0;

            foreach (var emp in hospitalStaffList)
            {   //using is
                //if (emp is Nurse)
                //    nurses++;
                //else if (emp is Doctor)
                //    doctors++;
                //else if (emp is Employee)
                //    employees++;


                //using as
                //if (emp as Nurse != null)
                //    nurses++;
                //else if (emp as Doctor != null)
                //    doctors++;
                //else if (emp as Employee != null)
                //    employees++;


                //using Type
                Type type = emp.GetType();

                if (type.Name == "Employee")
                    employees++;
                else if (type.Name == "Nurse")
                    nurses++;
                else if (type.Name == "Doctor")
                    doctors++;

            }
            string message = string.Format($"Employees:{employees} Doctors:{doctors} Nurses:{nurses}");

            MessageBox.Show(message);
        }

        private void BtnGetPay_OnClick(object sender, RoutedEventArgs e)
        {
            //determine what selected
            Employee selectedEmployee = lbxEmployees.SelectedItems as Employee;

            if (selectedEmployee != null)
            {
                //calculate pay using get monthly
                decimal pay = selectedEmployee.GetMonthlySalary();

                //get type
                Type type = selectedEmployee.GetType(); //included namespace in name
                string typeName = type.Name; // just gives the class name

                //show mwssage
                MessageBox.Show(string.Format($"Monthly pay of Selected {typeName} is {pay:C}"));
            }
            else
            {
                MessageBox.Show("Nothing is Selected");
            }

        }
    }
}
