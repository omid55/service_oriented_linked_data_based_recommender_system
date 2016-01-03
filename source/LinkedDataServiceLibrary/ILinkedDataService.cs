using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VDS.RDF;
using VDS.RDF.Query;

namespace LinkedDataServiceLibrary
{
    [ServiceContract(Name = "LinkedDataWcfService", Namespace = "http://MyLinkedDataCodes.com/wcf",
        SessionMode = SessionMode.Required)]
    public interface ILinkedDataService
    {
        [OperationContract]
        void Init();

        [OperationContract]
        void AddTripleWithUriSubject(string subject, string predicate, string obj);

        [OperationContract]
        void AddTripleWithLiteralSubject(string subject, string predicate, string obj, string language);

        [OperationContract]
        [FaultContract(typeof (MySoapFault))]
        void LoadFromFile(string filePath, DatasourceFileType fileType);

        [OperationContract]
        [FaultContract(typeof (MySoapFault))]
        void SaveToFile(string filePath, DatasourceFileType fileType);

        [OperationContract]
        [FaultContract(typeof (MySoapFault))]
        MyResults ExceuteQuery(string query);

        [OperationContract(IsOneWay = true)]
        void LoadDefaultDatasourceFile();


        // < just for testing >
        [OperationContract]
        void SetMyName(string name);

        [OperationContract]
        string SayHello();
        // </ just for testing >
    }


    [DataContract]
    public enum DatasourceFileType
    {
        [EnumMember]
        Rdfxml,
        [EnumMember]
        NTriples
    }


    [DataContract]
    public class MySoapFault
    {
        [DataMember] public string Operation;

        [DataMember] public string Reason;

        [DataMember] public string Details;

        [DataMember] public string MoreDetails;
    }


    [DataContract]
    public class QueryResult
    {
        [DataMember]
        public string[] variables { get; set; }

        [DataMember]
        public string result { get; set; }
    }


    [DataContract]
    public class MyResults
    {
        [DataMember]
        public QueryResult[] items { get; set; }

        [DataMember]
        public string query { get; set; }
    }
}