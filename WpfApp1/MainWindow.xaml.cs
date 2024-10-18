using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.DB;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> employeesList = new List<Employee>();
        List<Employee> FiltredList = new List<Employee>();

        public Dictionary<string, int> Sortings {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee{ EmployeeID = 0, FirstName="Emil", Name = "Kirill", Salary = 50000});
            employees.Add(new Employee { EmployeeID = 1, FirstName = "Baryshev", Name = "Nikita", Salary = 20000 });
            employees.Add(new Employee { EmployeeID = 2, FirstName = "Krut", Name = "Maksim", Salary = 60000 });
            employees.Add(new Employee { EmployeeID = 3, FirstName = "Karpov", Name = "Danil", Salary = 100000 });
            employeesList = employees.ToList();

            Sortings = new Dictionary<string, int>
            {
                {"Без сортировки", 1 },
                {"Фамилия по возрастанию", 2 },
                {"Фамилия по убыванию", 3 },
                {"Зарплата по возрастанию", 4 },
                {"Запрлата по убыванию", 5 },

            };



            Employeers.ItemsSource = employees;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        public void ApplyFilters()
        {
            var searchingText = tbSearch.Text.ToLower();
            int sorting = 0;
            if (cbSorting.SelectedItem != null)
            {
                sorting = Sortings[cbSorting.SelectedItem as string];
            }

            FiltredList = employeesList.ToList();

            if(searchingText != "")
            {
                FiltredList = employeesList.FindAll(Employee => Employee.FirstName.ToLower().Contains(searchingText));
                

            }


                switch (sorting)
                {
                    case 1:
                        FiltredList = FiltredList.OrderBy(employe => employe.FirstName).ToList(); 
                        break;
                    case 2:
                        FiltredList = FiltredList.OrderBy(employe => employe.FirstName).ToList();
                        break;
                    case 5:
                        FiltredList = FiltredList.OrderByDescending(employe => employe.Salary).ToList();
                        break;

                }

            
            Employeers.ItemsSource = FiltredList;
        }

        private void cbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }
    }
}
