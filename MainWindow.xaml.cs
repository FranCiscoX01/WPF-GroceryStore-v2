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

//dataBase
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

//new product


namespace GrocerieStore_v2._0
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            getProduct();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //get products datagrid
        public void getProduct()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [grocerie_store]";
            cmd.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable("grocerie_store");

            adapter.Fill(table);

            ProductsDataGrid.ItemsSource = table.DefaultView;

            connection.Close();
        }

        private void NewProduct_Click(object sender, RoutedEventArgs e)
        {
            NewProduct add_product = new NewProduct();
            add_product.Show();
        }

        private void Edit_Product_Click(object sender, RoutedEventArgs e)
        {
            EditProduct edit = new EditProduct();
            DataRowView datos = ProductsDataGrid.SelectedItem as DataRowView;
            if (datos != null)
            {
                edit.EditIDProduct.Text = datos["id"].ToString();
                edit.EditNameProduct.Text = datos["product"].ToString();
                edit.EditDescriptProduct.Text = datos["descript"].ToString();
                edit.EditPriceProduct.Text = datos["price"].ToString().Replace(",", ".");
                edit.EditQuantityProduct.Text = datos["quantity"].ToString();
                edit.Show();
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            getProduct();
        }

        private void Delete_Product_Click(object sender, RoutedEventArgs e)
        {
            DataRowView datos = ProductsDataGrid.SelectedItem as DataRowView;

            MessageBoxResult result = MessageBox.Show("Are you sure to delete row?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("ProductDelete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter("@ID", SqlDbType.Int);
                    param1.Value = Convert.ToInt32(datos["id"].ToString());


                    cmd.Parameters.Add(param1);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    getProduct();
                }

                connection.Close();
                
            }

            
        }
    }
}
