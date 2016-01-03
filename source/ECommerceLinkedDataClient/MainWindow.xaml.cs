using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ECommerceLinkedDataClient.ECommerceService;

namespace ECommerceLinkedDataClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ECommerceServiceClient proxy;


        public MainWindow()
        {
            InitializeComponent();

            try
            {
                proxy = new ECommerceServiceClient("NetTcpBinding_IECommerceService");
                proxy.Init();

                AdsComboBox.ItemsSource = proxy.ListAds();
                AdsComboBox.SelectedIndex = 0;

                //string str1 = proxy.SayHello();
                //proxy.SetMyName("Omid");
                //string str2 = proxy.SayHello();

                //proxy.LoadDefaultDatasourceFile();
            }
            catch (FaultException<MySoapFault> dataEx)
            {
                MessageBox.Show(
                    String.Format("{0}\n\nFollowing error was occurred in function {1} :\n{2}\n\n{3}",
                                  dataEx.Detail.Reason, dataEx.Detail.Operation, dataEx.Detail.Details,
                                  dataEx.Detail.MoreDetails), "ERROR", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unkown Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //int result = proxy.GiveMeCount();
                //MessageBox.Show(result.ToString());

                //string[] prods = new string[] { "Mobile", "Mobile-operator", "Milk" };
                ////var res1 = proxy.FindAllRelatives(prods, OrderMode.ProductName);
                //var res2 = proxy.FindAllRelatives(prods, OrderMode.SameCategory);
                //string catName = proxy.FindCategoryName("Milk");

                //var res = proxy.ExceuteQuery("select ?a ?b ?c where {?a ?b ?c} LIMIT 5");
                //foreach (var item in res.items)
                //{
                //    MessageBox.Show(item.result);
                //}

                string[] suggestProducts = proxy.SuggestProducts(Int32.Parse(PersonTextBox.Text), OrderMode.ProductName);
                foreach (var suggestProduct in suggestProducts)
                {
                    MessageBox.Show(suggestProduct);
                }
            }
            catch (FaultException<MySoapFault> dataEx)
            {
                MessageBox.Show(
                    String.Format("{0}\n\nFollowing error was occurred in function {1} :\n{2}\n\n{3}",
                                  dataEx.Detail.Reason, dataEx.Detail.Operation, dataEx.Detail.Details,
                                  dataEx.Detail.MoreDetails), "ERROR", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unkown Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] suggestPersons = proxy.SuggestPersons(ProductTextBox.Text);
                foreach (var suggestPersonId in suggestPersons)
                {
                    MessageBox.Show(suggestPersonId.ToString());
                }
            }
            catch (FaultException<MySoapFault> dataEx)
            {
                MessageBox.Show(
                    String.Format("{0}\n\nFollowing error was occurred in function {1} :\n{2}\n\n{3}",
                                  dataEx.Detail.Reason, dataEx.Detail.Operation, dataEx.Detail.Details,
                                  dataEx.Detail.MoreDetails), "ERROR", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unkown Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AdsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string productName = (string)AdsComboBox.SelectedItem;
                int[][] suggestPersons = proxy.SuggestCustomersInTheirCluster(productName);

                DataTable dt = new DataTable();
                dt.Columns.Add("Cluster ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Family");
                dt.Columns.Add("Age");
                dt.Columns.Add("Email");

                List<object> res = new List<object>();
                for (int i = 0; i < suggestPersons.Length; i++)
                {
                    CustomerTbl[] c = proxy.GetPersonsDetail(suggestPersons[i]);
                    for (int j = 0; j < c.Length; j++)
                    {
                        dt.Rows.Add(i + 1, c[j].Cname, c[j].Cfamily, c[j].Age,c[j].Email);
                    }
                }
                ResultDataGrid.ItemsSource = dt.DefaultView;
            }
            catch (FaultException<MySoapFault> dataEx)
            {
                MessageBox.Show(
                    String.Format("{0}\n\nFollowing error was occurred in function {1} :\n{2}\n\n{3}",
                                  dataEx.Detail.Reason, dataEx.Detail.Operation, dataEx.Detail.Details,
                                  dataEx.Detail.MoreDetails), "ERROR", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unkown Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
