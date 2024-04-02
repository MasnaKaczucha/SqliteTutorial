using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SqliteTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database _db;
        public Database Db 
        { 
            get 
            { 
                if(_db == null)
                {
                    _db = new Database("Avengers.db3");
                }
                return _db; 
            } 
        }

        public ObservableCollection<Avenger> Items { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Items = new ObservableCollection<Avenger>(Db.GetItemsAsync().Result);
            ListView1.ItemsSource = Items;
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Avenger item = new Avenger()
            {
                Name = t1.Text,
                RealName = t2.Text
            };
            Db.SaveItemAsync(item);
            Items.Add(item);
            t1.Text = "";
            t2.Text = "";


        }
    }
}
