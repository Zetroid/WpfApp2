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
using WpfApp;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        List<Books> books;
        DBConnect dBConnect = new DBConnect();
        double totalPrice = 0;
        int discount = 0;
        public Shop()
        {
            InitializeComponent();
            books = new List<Books>();
            books = dBConnect.bookEntities.Books.ToList();        
            BookList.ItemsSource = books;

            selectedBooks.Text = "Выбрано книг: 0";
            totalCost.Text = "Стоимость покупки: 0 руб.";
            discountTotal.Text = "0%";
        }

        private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Books book;
            selectedBooks.Text = "Выбрано книг: " + BookList.SelectedItems.Count;
            foreach(var item in BookList.SelectedItems)
            {
                book = item as Books;
                totalPrice += book.Cost; 
            }
            totalCost.Text = "Стоимость покупки: "+ totalPrice +" руб.";
            totalPrice = 0;

            if(BookList.SelectedItems.Count > 3 && BookList.SelectedItems.Count < 5)
            {
                discount = 5;
            }
            else if (BookList.SelectedItems.Count > 5 && BookList.SelectedItems.Count < 10)
            {
                discount = 10;
            }
            else if (BookList.SelectedItems.Count > 10)
            {
                discount = 15;
            }
            discountTotal.Text = discount + "%";

        }
    }
}
