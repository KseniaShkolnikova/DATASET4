using System;
using System.Collections.Generic;
using System.Data;
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
using DataSet2.PRAKT4DataSetTableAdapters;

namespace DataSet2
{
    /// <summary>
    /// Логика взаимодействия для Sushi_store.xaml
    /// </summary>
    public partial class Sushi_store : Page
    {
        private SUSHI_STORETableAdapter context = new SUSHI_STORETableAdapter();
        private SUSHITableAdapter kk = new SUSHITableAdapter();
        public Sushi_store()
        {
            
            InitializeComponent();
            ingridik.ItemsSource = context.GetData();
            combobox.ItemsSource = kk.GetData();
            combobox.DisplayMemberPath = "NANE_SUSHI";
        }

        private void button_serh_Click(object sender, RoutedEventArgs e)
        {
            ingridik.ItemsSource = context.serch(serch.Text);
            serch.Text = null;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combobox.SelectedItem != null)
            {
                var id = (int)(combobox.SelectedItem as DataRowView).Row[0];
                ingridik.ItemsSource = context.filtr(id);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ingridik.ItemsSource = context.GetData();
            combobox.Text = null;
        }

    }
}
