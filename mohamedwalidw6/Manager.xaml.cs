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
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        Databasecontext databasecontext = new Databasecontext();
        public Manager()
        {
            InitializeComponent();
            loaddata();
        }
        public void loaddata(){
            employeetable.ItemsSource = databasecontext.Tasks.ToList();
        }

        private void Addtask(object sender, RoutedEventArgs e)
        {
            Task task = new Task();
            task.title = titletext.Text;
            task.description = descriptiontext.Text;
            ComboBoxItem selected = (ComboBoxItem)combostatus.SelectedItem;
            task.status = selected.Content.ToString();
            task.employeeid = int.Parse(employeeidtext.Text);
            var response = databasecontext.Users.FirstOrDefault(l => l.userid == task.employeeid);
            if(response == null){
                MessageBox.Show("Employee Not Found");
            }
            else{
            databasecontext.Tasks.Add(task);
            databasecontext.SaveChanges();
            MessageBox.Show("Task Added Successfully");
            loaddata();
            }
          
        }

        private void Deletetask(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(taskidtext.Text);
            var response = databasecontext.Tasks.FirstOrDefault(k => k.taskid == ID);
            if(response == null){
                MessageBox.Show("Task Not Found");
            }
            else{
                databasecontext.Tasks.Remove(response);
                databasecontext.SaveChanges();
                MessageBox.Show("Task Deleted Successfully");
                loaddata();
            }
        }

        private void Edittask(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(taskidtext.Text);
            ComboBoxItem selected = (ComboBoxItem)combostatus.SelectedItem;
            var response = databasecontext.Tasks.FirstOrDefault(k => k.taskid == ID);
            if (response == null) {
                MessageBox.Show("Task Not Found");
            }
            else{
                response.title = titletext.Text;
                response.description = descriptiontext.Text;
                response.status = selected.Content.ToString();
                databasecontext.SaveChanges();
                MessageBox.Show("Task Updated Successfully");
                loaddata();
            }
        }
    }
}
