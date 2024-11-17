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
using System.Windows.Shapes;

namespace mohamedwalidw6
{ // updating for pulling
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        Databasecontext databasecontext = new Databasecontext();
        public Employee()
        {
            InitializeComponent();
            loaddata();
        }
        public void loaddata(){
            //load datagrid
            int ID = MainWindow.employeeidlogin;
            Firsttable.ItemsSource = databasecontext.Tasks.Where(s => (s.status == "Pending" || s.status == "In Progress") && s.employeeid == ID).ToList();
            Secondtable.ItemsSource = databasecontext.Tasks.Where(k => k.status == "Completed" && k.employeeid == ID).ToList();
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(taskidtext.Text);
            ComboBoxItem selected = (ComboBoxItem)statuscombo.SelectedItem;
            var response = databasecontext.Tasks.FirstOrDefault(k => k.taskid == ID);
            if (response == null)
            {
                MessageBox.Show("Task Not Found");
            }
            else
            {
                response.status = selected.Content.ToString();
                databasecontext.SaveChanges();
                MessageBox.Show("Task Saved Successfully");
                loaddata();
            }
        }
    }
}
