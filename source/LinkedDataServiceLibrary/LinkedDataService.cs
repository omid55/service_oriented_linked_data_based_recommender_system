using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using VDS.RDF.Writing;

namespace LinkedDataServiceLibrary
{
    public class LinkedDataService : ILinkedDataService
    {
        #region Fields

        private Graph myGraph;
        private string myName = "Ali";

        #endregion

        #region Methods

        public void Init()
        {
            myGraph = new Graph();
        }

        public void AddTripleWithUriSubject(string subject, string predicate, string obj)
        {
            UriNode subj = myGraph.CreateUriNode(new Uri(subject));
            UriNode pred = myGraph.CreateUriNode(new Uri(predicate));
            myGraph.Assert(new Triple(subj, pred, myGraph.CreateUriNode(new Uri(obj))));
        }

        public void AddTripleWithLiteralSubject(string subject, string predicate, string obj, string language = null)
        {
            UriNode subj = myGraph.CreateUriNode(new Uri(subject));
            UriNode pred = myGraph.CreateUriNode(new Uri(predicate));

            if (language == null)
            {
                myGraph.Assert(new Triple(subj, pred, myGraph.CreateLiteralNode(obj)));
            }
            else
            {
                myGraph.Assert(new Triple(subj, pred, myGraph.CreateLiteralNode(obj, language)));
            }
        }

        public void LoadFromFile(string filePath, DatasourceFileType fileType)
        {
            try
            {
                switch (fileType)
                {
                    case DatasourceFileType.Rdfxml: // RDF/XML
                        RdfXmlParser rdfXmlParser = new RdfXmlParser(RdfXmlParserMode.Streaming);
                        myGraph = new Graph();
                        rdfXmlParser.Load(myGraph, filePath);
                        break;

                    case DatasourceFileType.NTriples: // NTriples
                        NTriplesParser ntp = new NTriplesParser();
                        myGraph = new Graph();
                        ntp.Load(myGraph, filePath);
                        break;
                }
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "LoadFromFile";
                fault.Reason = "Error in loading datasource file into graph .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public void SaveToFile(string filePath, DatasourceFileType fileType)
        {
            try
            {
                switch (fileType)
                {
                    case DatasourceFileType.Rdfxml: // RDF/XML
                        FastRdfXmlWriter rxtw = new FastRdfXmlWriter();
                        rxtw.Save(myGraph, filePath);
                        break;

                    case DatasourceFileType.NTriples: // NTriples
                        NTriplesWriter wr = new NTriplesWriter();
                        wr.Save(myGraph, filePath);
                        break;
                }
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "SaveToFile";
                fault.Reason = "Error in saving datasource from graph to file .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public MyResults ExceuteQuery(string query)
        {
            try
            {
                SparqlResultSet res = (SparqlResultSet) myGraph.ExecuteQuery(query);
                MyResults results = new MyResults();
                results.query = query;
                results.items = new QueryResult[res.Results.Count];
                for (int i = 0; i < res.Results.Count; i++)
                {
                    results.items[i] = new QueryResult
                                           {
                                               variables = res.Results[i].Variables.ToArray(),
                                               result = res.Results[i].ToString()
                                           };
                }
                return results;
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "ExceuteQuery";
                fault.Reason = "Error in executing sparql query in linked data graph .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public void LoadDefaultDatasourceFile()
        {
            LoadFromFile(Properties.Settings.Default.DataSourceFilePath, DatasourceFileType.Rdfxml);
        }


        // < just for testing >
        public void SetMyName(string name)
        {
            myName = name;
        }

        public string SayHello()
        {
            return String.Format("Hello {0} !!!", myName);
        }
        // </ just for testing >

        #endregion
    }
}