using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//dataBase
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace GrocerieStore_v2._0
{
    /// <summary>
    /// Lógica de interacción para EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public EditProduct()
        {
            InitializeComponent();
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

        private void Update_Product_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("ProductEdit", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter id = new SqlParameter("@ID", SqlDbType.VarChar);
                id.Value = EditIDProduct.Text;

                SqlParameter param1 = new SqlParameter("@Product", SqlDbType.VarChar);
                param1.Value = EditNameProduct.Text;

                SqlParameter param2 = new SqlParameter("@Description", SqlDbType.VarChar);
                param2.Value = EditDescriptProduct.Text;

                var _price = EditPriceProduct.Text.Replace(".", ",");
                decimal add_price = Convert.ToDecimal(_price);
                SqlParameter param3 = new SqlParameter("@Price", SqlDbType.Decimal);
                param3.Value = add_price;

                SqlParameter param4 = new SqlParameter("@Quantity", SqlDbType.Int);
                param4.Value = Convert.ToInt32(EditQuantityProduct.Text);

                cmd.Parameters.Add(id);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);

                Console.WriteLine(cmd.ExecuteNonQuery());

                if (cmd.ExecuteNonQuery() > 0)
                {
                    EditIDProduct.Text = "";
                    EditNameProduct.Text = "";
                    EditNameProduct.Text = "";
                    EditPriceProduct.Text = "";
                    EditQuantityProduct.Text = "";

                    MessageBox.Show("Product Updated", "Update Product", MessageBoxButton.OK, MessageBoxImage.Information);

                    Close();
                }
                else
                {
                    MessageBox.Show("Error to Update Product", "Erro Update Product", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }

            connection.Close();
        }
    }
}
