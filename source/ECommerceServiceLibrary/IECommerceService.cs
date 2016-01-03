using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ECommerceServiceLibrary
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    [ServiceKnownType(typeof(OrderMode))]
    public interface IECommerceService
    {
        [OperationContract]
        [FaultContract(typeof(MySoapFault))]
        void Init();

        [OperationContract]
        [FaultContract(typeof(MySoapFault))]
        string[] FindRelatives(string productName);

        [OperationContract]
        [FaultContract(typeof(MySoapFault))]
        string[] FindAllRelatives(string[] productNames, OrderMode mode);

        [OperationContract]
        [FaultContract(typeof(MySoapFault))]
        string FindCategoryName(string productName);

        [OperationContract]
        [FaultContract(typeof(MySoapFault))]
        string[] ListAds();

        [OperationContract]
        [FaultContract(typeof(MySoapFault))]
        CustomerTbl[] GetPersonsDetail(int[] persons);

        [OperationContract]
        [FaultContract(typeof(MySoapFault))]
        string[] SuggestProducts(int personId, OrderMode mode);   // suggest products for a person with this personId

        [OperationContract]
        [FaultContract(typeof(MySoapFault))]
        int[] SuggestPersons(string productName);   // suggest this product to which persons that they gonna buy it (all customers)

        [OperationContract]
        [FaultContract(typeof(MySoapFault))]
        List<int>[] FindBestCustomers();   // returns each customer in his/her cluster

        [OperationContract]
        [FaultContract(typeof(MySoapFault))]
        List<int>[] SuggestCustomersInTheirCluster(string product);   // suggest customers in clusters that would be very usefull for advertisements

        [OperationContract]
        void AdvertiseNow();

        // < just for testing >
        [OperationContract]
        int GiveMeCount();

        [OperationContract]
        string GetData(int value);
        // </ just for testing >
    }


    [DataContract]
    public enum OrderMode
    {
        [EnumMember]
        ProductName,
        [EnumMember]
        SameCategory
    }

    [DataContract]
    public class MySoapFault
    {
        [DataMember]
        public string Operation;

        [DataMember]
        public string Reason;

        [DataMember]
        public string Details;

        [DataMember]
        public string MoreDetails;
    }
}
