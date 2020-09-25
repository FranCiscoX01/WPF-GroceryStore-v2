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
using System.Text.RegularExpressions;
//dataBase
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GrocerieStore_v2._0
{
    /// <summary>
    /// Lógica de interacción para NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        public NewProduct()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("addNewProduct", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@Product", SqlDbType.VarChar);
                param1.Value = AddNameProduct.Text;

                SqlParameter param2 = new SqlParameter("@Description", SqlDbType.VarChar);
                param2.Value = AddDescriptProduct.Text;

                var _price = AddPriceProduct.Text.Replace(".", ",");
                decimal add_price = Convert.ToDecimal(_price);
                SqlParameter param3 = new SqlParameter("@Price", SqlDbType.Decimal);
                param3.Value = add_price;

                SqlParameter param4 = new SqlParameter("@Quantity", SqlDbType.Int);
                param4.Value = Convert.ToInt32(AddQuantityProduct.Text);


                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    AddNameProduct.Text = "";
                    AddDescriptProduct.Text = "";
                    AddPriceProduct.Text = "";
                    AddQuantityProduct.Text = "";

                    MessageBox.Show("Product Added", "New Product", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    Close();

                } else
                {
                    MessageBox.Show("Error to Add Product", "Erro Add Product", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }

            connection.Close();
        }

        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]{0,2}$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void Quantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
