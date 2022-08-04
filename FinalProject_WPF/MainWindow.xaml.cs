using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;
using System.Windows.Controls;

namespace FinalProject_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductDBEntities productDB = new ProductDBEntities(); 
        private SqlConnection sqlConnection = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
            from product in productDB.MeatProduct
            //where product.Id >= 0
            //orderby product.Id
            select new { product.Id, product.name, product.product_type, product.price, product.description, product.quantity, product.type_of_meat, product.fat_content };
            dataGrid1.ItemsSource = query.ToList();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductDB"].ConnectionString);
            sqlConnection.Open();
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command1 = new SqlCommand($"INSERT INTO [MeatProduct] (name, price, description, quantity, type_of_meat, product_type) VALUES (@name, @price, @description, @quantity, @type_of_meat, @product_type)", sqlConnection);
            command1.Parameters.AddWithValue("name", TextBox_1.Text);
            command1.Parameters.AddWithValue("price", TextBox_2.Text);
            command1.Parameters.AddWithValue("description", TextBox_3.Text);
            command1.Parameters.AddWithValue("quantity", TextBox_4.Text);
            command1.Parameters.AddWithValue("type_of_meat", TextBox_5.Text);
            command1.Parameters.AddWithValue("product_type", TextBox_6.Text);
            MessageBox.Show(command1.ExecuteNonQuery().ToString());
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command2 = new SqlCommand($"INSERT INTO [MeatProduct] (name, price, description, quantity, fat_content, product_type) VALUES (@name, @price, @description, @quantity, @fat_content, @product_type)", sqlConnection);
            command2.Parameters.AddWithValue("name",TextBox_7.Text);
            command2.Parameters.AddWithValue("price", TextBox_8.Text);
            command2.Parameters.AddWithValue("description", TextBox_9.Text);
            command2.Parameters.AddWithValue("quantity", TextBox_10.Text);
            command2.Parameters.AddWithValue("fat_content", TextBox_11.Text);
            command2.Parameters.AddWithValue("product_type", TextBox_12.Text);
            MessageBox.Show(command2.ExecuteNonQuery().ToString());
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            var query =
            from product in productDB.MeatProduct
            select new { product.Id, product.name, product.product_type, product.price, product.description, product.quantity, product.type_of_meat, product.fat_content };
            dataGrid1.ItemsSource = query.ToList();
        }
    }
}
