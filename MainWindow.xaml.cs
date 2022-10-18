using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Assignment_2
{   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<ContactPerson> contacts;

        public MainWindow()
        {
            InitializeComponent();
            contacts = new ObservableCollection<ContactPerson>();
            lv_Contacts.ItemsSource = contacts;
        }

        // ANVÄNDAREN SKRIVER IN EN NY KONTAKT HÄR OCH KNAPPEN GÖR ATT KONTAKTEN LÄGGS TILL
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var contact = contacts.FirstOrDefault(x => x.Email == tb_Email.Text);
            if (contact == null)
            {
                contacts.Add(new ContactPerson
                {
                    FirstName = tb_FirstName.Text,
                    LastName = tb_LastName.Text,
                    Email = tb_Email.Text,
                    StreetName = tb_StreetName.Text,
                    PostalCode = tb_PostalCode.Text,
                    City = tb_City.Text
                });
            }

            // OM ANVÄNDAREN SKRIVER IN SAMMA E-POSTADRESS
            else
            {
                MessageBox.Show("Det finns redan en kontakt med samma e-postadress.");
            }

            ClearFields();
        }

        // ALLA FÄLTEN BLIR TOMMA
        private void ClearFields()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_StreetName.Text = "";
            tb_PostalCode.Text = "";
            tb_City.Text = "";
        }

        // DENNA KNAPP TAR BORT EN KNAPP FRÅN KONTAKTLISTAN
        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var contact = (ContactPerson)button!.DataContext;
            contacts.Remove(contact);
            ClearFields();

        }

        // HÄR KAN ANVÄNDAREN SE DETALJERAD INFORMATION OM KONTAKTEN
        private void lv_Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var obj = sender as ListView;
                var item = (ContactPerson)obj!.SelectedItem;
                if (item != null)
                {
                    tb_FirstName.Text = item.FirstName;
                    tb_LastName.Text = item.LastName;
                    tb_Email.Text = item.Email;
                    tb_StreetName.Text = item.StreetName;
                    tb_PostalCode.Text = item.PostalCode;
                    tb_City.Text = item.City;
                }

            }
            catch { }


        }
    }

}