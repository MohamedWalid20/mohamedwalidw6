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

namespace mohamedwalidw6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Databasecontext databasecontext = new Databasecontext();
        public static int employeeidlogin;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string name = usernametext.Text;
            string password = passwordtext.Password;
            var response = databasecontext.Users.FirstOrDefault(k => k.username == name && k.password == password);
            if(response == null){
                MessageBox.Show("Invalid Username Or Password");
            }
            else if(response.role == "Manager"){
                Manager manager = new Manager();
                manager.Show();
                this.Close();
            }
            else{
                employeeidlogin = response.userid ;
                Employee employee = new Employee();
                employee.Show();
                this.Close();
            }
        }
    }
}
