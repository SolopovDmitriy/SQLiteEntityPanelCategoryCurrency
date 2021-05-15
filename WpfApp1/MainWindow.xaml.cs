using Microsoft.EntityFrameworkCore;
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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SQLiteDBContext engine;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;       
        }

        private IQueryable<Product> Products // my code -------------------------------------
        {
            get
            {
                return engine.Products.Include(d => d.Category);// например Category - одежда, products - noski
            }
        }



        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                engine = new SQLiteDBContext(); //база данных context
               /* IQueryable<Product> products = engine.Products.Include(d => d.Category);*/ //метод   Include связывает две таблицы products и categories                            
                ListBox_ProductWithCategory.ItemsSource = Products; // записываем в самое нижнее поле ListBox Row 5 engine.Products.Include(d => d.Category);
                ComboBox_CategoriesToDelete.ItemsSource = engine.Categories.ToList(); //записываем в самое нижнее поле Delete engine.Products.Include(d => d.Category);
                ComboBox_CategoriesForProductSave.ItemsSource = engine.Categories.ToList(); 
                ComboBox_ProductDelete.ItemsSource = Products;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }



            #region
            //try
            //{
            //    engine = new SQLiteDBContext();
            //    IQueryable<Product> products = engine.Products.Include(d => d.Category);
            //    Product p = products.FirstOrDefault();
            //    MessageBox.Show(p.Category.Name);
            //    //CategoriesListBox.ItemsSource = engine.Products.ToList();
            //    //CategoriesListBox.ItemsSource = engine.Categories.ToList(); 
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    throw;
            //}         

            /*foreach (var item in sQLiteDBEngine.Categories.ToList())
            {
                Console.WriteLine(item.Id  + " "  + item.Name) ;
            }*/

            //engine.Categories.Add(new Category { Name="Пробухал"});
            //engine.SaveChanges();
            #endregion

        }

        private void Button_CategorySave_Click(object sender, RoutedEventArgs e)
        {
            engine.Categories.Add(new Category { Name= TextBox_NewCategory.Text});
            engine.SaveChanges();//Async
            TextBox_NewCategory.Clear();// очищает контент TextBox_NewCategory
            ComboBox_CategoriesToDelete.ItemsSource = engine.Categories.ToList();
        }

        private void Button_CategoryDelete_Click(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = ComboBox_CategoriesToDelete.SelectedItem as Category;
            engine.Categories.Remove(selectedCategory);
            engine.SaveChanges();
            ComboBox_CategoriesToDelete.ItemsSource = engine.Categories.ToList();
        }

        private void Button_ProductSave_Click(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = ComboBox_CategoriesForProductSave.SelectedItem as Category;
            int price;
            bool isSuccessfull = Int32.TryParse(TextBox_NewProductPrice.Text, out price);
            if (!isSuccessfull)
            {
                MessageBox.Show("price is not a number");
                return;
            }

            engine.Products.Add(new Product { 
                Name = TextBox_NewProductName.Text,
                Price = price,
                CategoryId = selectedCategory.Id });
            engine.SaveChanges();
            TextBox_NewProductName.Clear();
            TextBox_NewProductPrice.Clear();
            ComboBox_ProductDelete.ItemsSource = Products; //записываем в самое нижнее поле Delete engine.Products.Include(d => d.Category);
            ListBox_ProductWithCategory.ItemsSource = Products; //записываем в самое нижнее поле ListBox Row 5 engine.Products.Include(d => d.Category);
        }

        private void Button_ProductDelete_Click(object sender, RoutedEventArgs e)
        {
            //Product p1 = new Product { Name = "Milk" };
            //object p2 = new Product { Name = "Bread" };
            //Product p2_copy = p2 as Product;
            //string n = p2_copy.Name;
            Product selectedProduct = ComboBox_ProductDelete.SelectedItem as Product;
          
            engine.Products.Remove(selectedProduct);// engine - база данных - SQLiteDBContext : DbContext; Products - таблица в базе данных - DbSet<Product>
            engine.SaveChanges();
            ComboBox_ProductDelete.ItemsSource = Products; //из базы данных engine берем таблицу Products и сохраням ее в виде списка
            // ComboBox_ProductDelete получает этот список, ItemsSource - данные ComboBox_ProductDelete
        }
    }
}
