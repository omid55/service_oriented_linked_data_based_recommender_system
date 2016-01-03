using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using Microsoft.Win32;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using VDS.RDF.Writing;

namespace ECommerceLinkedDataProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Graph myGraph;
        //private string fileName = "data.xml";


        public MainWindow()
        {
            InitializeComponent();

            myGraph = new Graph();

            initGraph();
        }

        public void addTripleWithUriSubject(string subject, string predicate, string obj)
        {
            UriNode subj = myGraph.CreateUriNode(new Uri(subject));
            UriNode pred = myGraph.CreateUriNode(new Uri(predicate));
            myGraph.Assert(new Triple(subj, pred, myGraph.CreateUriNode(new Uri(obj))));
        }

        public void addTripleWithLiteralSubject(string subject, string predicate, string obj)
        {
            UriNode subj = myGraph.CreateUriNode(new Uri(subject));
            UriNode pred = myGraph.CreateUriNode(new Uri(predicate));
            myGraph.Assert(new Triple(subj, pred, myGraph.CreateLiteralNode(obj)));
        }

        public void addTripleWithLiteralSubject(string subject, string predicate, string obj, string language)
        {
            UriNode subj = myGraph.CreateUriNode(new Uri(subject));
            UriNode pred = myGraph.CreateUriNode(new Uri(predicate));
            myGraph.Assert(new Triple(subj, pred, myGraph.CreateLiteralNode(obj, language)));
        }

        public void initGraph()
        {
            addTripleWithUriSubject("http://www.myproducts.com/Mobile", "http://www.myproducts.com/InCategoryOf",
                                    "http://www.myproducts.com/Category#1001");
            addTripleWithUriSubject("http://www.myproducts.com/Hands-free", "http://www.myproducts.com/InCategoryOf",
                                    "http://www.myproducts.com/Category#1001");
            addTripleWithUriSubject("http://www.myproducts.com/Car Kit", "http://www.myproducts.com/InCategoryOf",
                                    "http://www.myproducts.com/Category#1001");
            addTripleWithUriSubject("http://www.myproducts.com/Cell Phone Bag", "http://www.myproducts.com/InCategoryOf",
                                    "http://www.myproducts.com/Category#1001");
            addTripleWithUriSubject("http://www.myproducts.com/SIM Carde", "http://www.myproducts.com/InCategoryOf",
                                    "http://www.myproducts.com/Category#1001");

            addTripleWithUriSubject("http://www.myproducts.com/TV", "http://www.myproducts.com/InCategoryOf",
                                    "http://www.myproducts.com/Category#1002");
            addTripleWithUriSubject("http://www.myproducts.com/DVD Recorder", "http://www.myproducts.com/InCategoryOf",
                                    "http://www.myproducts.com/Category#1002");
            addTripleWithUriSubject("http://www.myproducts.com/Stand For Television",
                                    "http://www.myproducts.com/InCategoryOf", "http://www.myproducts.com/Category#1002");
            addTripleWithUriSubject("http://www.myproducts.com/Television Headphones",
                                    "http://www.myproducts.com/InCategoryOf", "http://www.myproducts.com/Category#1002");
            addTripleWithUriSubject("http://www.myproducts.com/Television Antenna",
                                    "http://www.myproducts.com/InCategoryOf", "http://www.myproducts.com/Category#1002");


            addTripleWithLiteralSubject("http://www.myproducts.com/Category#1001",
                                        "http://www.myproducts.com/CategoryCodeOf", "Mobile Devices");
            addTripleWithLiteralSubject("http://www.myproducts.com/Category#1002",
                                        "http://www.myproducts.com/CategoryCodeOf", "ادوات تلویزیون", "fa");
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String query = QueryTextBox.Text;
                SparqlResultSet results = (SparqlResultSet)myGraph.ExecuteQuery(query);
                foreach (var res in results)
                {
                    MessageBox.Show(res.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR3", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = Environment.CurrentDirectory;
                sfd.Filter = "RDF Files (*.rdf)|*.rdf|Turtle Files (*.ttl)|*.ttl|All Files (*.*)|*.*";
                if (sfd.ShowDialog().Value)
                {
                    string filePath = sfd.FileName;

                    switch (ModeComboBox.SelectedIndex)
                    {
                        case 0: // RDF/XML
                            FastRdfXmlWriter rxtw = new FastRdfXmlWriter();
                            rxtw.Save(myGraph, filePath);
                            break;

                        case 1: // NTriples
                            NTriplesWriter wr = new NTriplesWriter();
                            wr.Save(myGraph, filePath);
                            break;
                    }


                    MessageBox.Show("Your Current Graph Saved Successfully", "Save Graph", MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "ERROR", MessageBoxButton.OK);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Environment.CurrentDirectory;
                ofd.Filter = "RDF Files (*.rdf)|*.rdf|Turtle Files (*.ttl)|*.ttl|All Files (*.*)|*.*";
                if (ofd.ShowDialog().Value)
                {
                    string filePath = ofd.FileName;

                    switch (ModeComboBox.SelectedIndex)
                    {
                        case 0: // RDF/XML
                            RdfXmlParser rdfXmlParser = new RdfXmlParser(RdfXmlParserMode.Streaming);
                            myGraph=new Graph();
                            rdfXmlParser.Load(myGraph, filePath);
                            break;

                        case 1: // NTriples
                            NTriplesParser ntp = new NTriplesParser();
                            myGraph = new Graph();
                            ntp.Load(myGraph, filePath);
                            break;
                    }

                    MessageBox.Show("Graph Loaded From File Successfully", "Connected", MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "ERROR", MessageBoxButton.OK);
            }
        }



        private void FindRelativesButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = ProductNameTextBox.Text;

            string query =
                "SELECT ?RelativeProducts WHERE { <http://www.myproducts.com/" + productName +
                "> <http://www.myproducts.com/InCategoryOf> ?CategoryId . ?RelativeProducts <http://www.myproducts.com/InCategoryOf> ?CategoryId FILTER (?RelativeProducts!=<http://www.myproducts.com/" +
                productName + ">)} ORDER BY ?RelativeProducts";

            SparqlResultSet results = (SparqlResultSet)myGraph.ExecuteQuery(query);
            DataTable dt = new DataTable();
            dt.Columns.Add("RelativeProducts");
            foreach (var arr in results.ToArray())
            {
                dt.Rows.Add(arr.ToString().Substring(46));
            }
            dataGrid1.ItemsSource = dt.DefaultView;

            /*foreach (var res in results)
            {
                MessageBox.Show(res.ToString());
            }*/
        }

        private void FindCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = ProductNameTextBox.Text;

            string query =
                "SELECT ?categoryName WHERE { <http://www.myproducts.com/" + productName +
                "> <http://www.myproducts.com/InCategoryOf> ?cat . ?cat <http://www.myproducts.com/CategoryCodeOf> ?categoryName }";

            SparqlResultSet results = (SparqlResultSet)myGraph.ExecuteQuery(query);
            DataTable dt = new DataTable();
            dt.Columns.Add("CategoryName");
            foreach (var arr in results.ToArray())
            {
                dt.Rows.Add(arr.ToString().Substring(16));
            }
            dataGrid1.ItemsSource = dt.DefaultView;
        }
    }
}