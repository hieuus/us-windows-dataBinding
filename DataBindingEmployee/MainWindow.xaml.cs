using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace DataBindingEmployee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        class Employee : INotifyPropertyChanged
        {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Tel { get; set; }
            public string AvatarPath { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
        }

        BindingList<Employee> _employees = new BindingList<Employee>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _employees = new BindingList<Employee>()
            {
                new Employee() {FullName="Nguyen Van Hieu", Email="nvhieu.us@outlook.com",
                    Address="12 Nguyen Chi Thanh, Q5", Tel="0931902050", AvatarPath="Images/avatar00.jpg"},
                new Employee() {FullName="Nguyen Viet My", Email="nthang@gmail.com",
                    Address="22 Nguyen Nguyen Van Cu, Q1", Tel="0378902040", AvatarPath="Images/avatar01.jpg"},
                new Employee() {FullName="Nguyen Phuong Nhi", Email="npnhi.us@outlook.com",
                    Address="34 Truong Sa, Q1", Tel="092319429", AvatarPath="Images/avatar02.jpg"},
                new Employee() {FullName="Nguyen Thuy Tien", Email="nttien.us@outlook.com",
                    Address="45 Tan Quy, Go Vap", Tel="091349232", AvatarPath="Images/avatar03.jpg"},
                new Employee() {FullName="Do Thi Ha", Email="dtha.us@outlook.com",
                    Address="45 Tan Quy, Go Vap", Tel="091349232", AvatarPath="Images/avatar04.jpg"},
                new Employee() {FullName="Huynh Tran Thanh", Email="htthanh.us@outlook.com",
                    Address="45 Tan Quy, Go Vap", Tel="091349232", AvatarPath="Images/avatar05.jpg"},
                new Employee() {FullName="Nguyen Thanh Tung", Email="nttung.us@outlook.com",
                    Address="45 Tan Quy, Go Vap", Tel="091349232", AvatarPath="Images/avatar06.jpg"},
                new Employee() {FullName="Le Kha Nhu", Email="nttien.us@outlook.com",
                    Address="45 Tan Quy, Go Vap", Tel="091349232", AvatarPath="Images/avatar07.jpg"},
                new Employee() {FullName="Tran Thu Ha", Email="nttien.us@outlook.com",
                    Address="45 Tan Quy, Go Vap", Tel="091349232", AvatarPath="Images/avatar08.jpg"},
                new Employee() {FullName="Hoang Tien Dat", Email="nttien.us@outlook.com",
                    Address="45 Tan Quy, Go Vap", Tel="091349232", AvatarPath="Images/avatar09.jpg"},
                new Employee() {FullName="Tran Anh Tu", Email="nttien.us@outlook.com",
                    Address="45 Tan Quy, Go Vap", Tel="091349232", AvatarPath="Images/avatar10.jpg"},
            };

            employeeList.ItemsSource = _employees;

            var bitmap = new BitmapImage(new Uri(@"Images/avatar-default.png", UriKind.Relative));
            imgbrush_avatarPath.ImageSource = bitmap;

            string fullName = "Employee's Name";
            run_fullName.Text = fullName;

            lb_headerFullName.Content = fullName;

            string email = "name@domain.com";
            txt_email.Text = email;

            string address = "22 Nguyen Van Cu, Q5";
            txt_add.Text = address;

            string tel = "0912345678";
            txt_tel.Text = tel;

        }

        int selectedIndex = -1;
        private void chooseEmployee(object sender, MouseButtonEventArgs e)
        {
            int index = employeeList.SelectedIndex;
            selectedIndex = index;
        }

        private void btn_MoreInfo(object sender, RoutedEventArgs e)
        {
            int index = employeeList.SelectedIndex;
            selectedIndex = index;

            if (selectedIndex != -1)
            {
                var bitmap = new BitmapImage(new Uri(_employees[selectedIndex].AvatarPath, UriKind.Relative));
                imgbrush_avatarPath.ImageSource = bitmap;

                string fullName = _employees[selectedIndex].FullName;
                run_fullName.Text = fullName;

                lb_headerFullName.Content = fullName;

                string email = _employees[selectedIndex].Email;
                txt_email.Text = email;

                string address = _employees[selectedIndex].Address;
                txt_add.Text = address;

                string tel = _employees[selectedIndex].Tel;
                txt_tel.Text = tel;
            }

        }

        private void btn_Remove(object sender, RoutedEventArgs e)
        {
            int index = employeeList.SelectedIndex;
            _employees.RemoveAt(index);
        }

        private void btn_Add(object sender, RoutedEventArgs e)
        {

        }
    }
}
