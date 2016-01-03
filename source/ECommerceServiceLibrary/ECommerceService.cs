using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ECommerceServiceLibrary.LinkedDataService;

namespace ECommerceServiceLibrary
{
    public class ECommerceService : IECommerceService
    {
        private LinkedDataWcfServiceClient linkedDataProxy;

        private const double SAMPLE_PERCENT = 0.2; // 20%
        private const int NumberOfMonthesForPurchase = 6;

        // --------------------------------
        // My E-Commerce Attributes
        // (1) :  NumberOfPurchases
        // (2) :  LoggedInDuration
        // (3) :  NumberOfLogins
        // (4) :  Minutes Elapsed From Last Login
        // (5) :  Minutes Elapsed From Last Purchase 
        // --------------------------------

        public void Init()
        {
            try
            {
                linkedDataProxy = new LinkedDataWcfServiceClient("NetTcpBinding_LinkedDataWcfService");
                linkedDataProxy.LoadDefaultDatasourceFile();
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "Init";
                fault.Reason = "Error in creating new linkedDataProxy in ECommerceService .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public string[] FindRelatives(string productName)
        {
            try
            {
                string query =
                    "SELECT ?RelativeProducts WHERE { <http://www.myproducts.com/" + productName +
                    "> <http://www.myproducts.com/InCategoryOf> ?CategoryId . ?RelativeProducts <http://www.myproducts.com/InCategoryOf> ?CategoryId FILTER (?RelativeProducts!=<http://www.myproducts.com/" +
                    productName + ">)} ORDER BY ?RelativeProducts";

                return
                    linkedDataProxy.ExceuteQuery(query).items.Select(queryResult => queryResult.result.Substring(46)).
                        ToArray();
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "FindRelatives";
                fault.Reason = "Error in finding relatives in ECommerceService .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public string[] FindAllRelatives(string[] productNames, OrderMode mode)
        {
            try
            {
                string query =
                    "SELECT DISTINCT ?RelativeProducts WHERE {{ <http://www.myproducts.com/" + productNames[0] +
                    "> <http://www.myproducts.com/InCategoryOf> ?CategoryId . ?RelativeProducts <http://www.myproducts.com/InCategoryOf> ?CategoryId } ";

                string filters = "FILTER ((?RelativeProducts!=<http://www.myproducts.com/" +
                                 productNames[0] + ">) ";

                for (int i = 1; i < productNames.Length; i++)
                {
                    query += "UNION { <http://www.myproducts.com/" + productNames[i] +
                             "> <http://www.myproducts.com/InCategoryOf> ?CategoryId . ?RelativeProducts <http://www.myproducts.com/InCategoryOf> ?CategoryId } ";

                    filters += "&& (?RelativeProducts!=<http://www.myproducts.com/" +
                               productNames[i] + ">)";
                }
                query += filters + ")} ";

                if (mode == OrderMode.ProductName)
                {
                    query += "ORDER BY ?RelativeProducts";
                }

                return
                    linkedDataProxy.ExceuteQuery(query).items.Select(queryResult => queryResult.result.Substring(46)).
                        ToArray();
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "FindAllRelatives";
                fault.Reason = "Error in finding all relatives in ECommerceService .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public string FindCategoryName(string productName)
        {
            try
            {
                string query =
                    "SELECT ?categoryName WHERE { <http://www.myproducts.com/" + productName +
                    "> <http://www.myproducts.com/InCategoryOf> ?cat . ?cat <http://www.myproducts.com/CategoryCodeOf> ?categoryName }";

                if (linkedDataProxy.ExceuteQuery(query).items.Length != 0)
                {
                    return linkedDataProxy.ExceuteQuery(query).items[0].result.Substring(16);
                }
                return "";
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "FindCategoryName";
                fault.Reason = "Error in finding category name in ECommerceService .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public string[] ListAds()
        {
            try
            {
                ECDBEntities entity = new ECDBEntities();

                var prodNames = from ad in entity.AdsTbls
                                select ad.ProductName;

                return prodNames.ToArray();
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "ListAds";
                fault.Reason = "Error in selecting all ads from database .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public CustomerTbl[] GetPersonsDetail(int[] persons)
        {
            try
            {
                ECDBEntities entity = new ECDBEntities();

                var q = from c in entity.CustomerTbls
                        where persons.Contains(c.Cid)
                        select c;

                return q.ToArray();
            }            
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "GetPersonsDetail";
                fault.Reason = "Error in selecting from CustomerTbls from database .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public string[] SuggestProducts(int personId, OrderMode mode)
        {
            try
            {
                ECDBEntities entity = new ECDBEntities();
                var purchasedProducts = from purchase in entity.PurchaseTbls
                                        where purchase.Cid == personId
                                        select purchase.ProductName;

                string[] relatives = FindAllRelatives(purchasedProducts.ToArray(), mode);

                var nowAds = from ad in entity.AdsTbls
                             select ad.ProductName;

                var result = relatives.Intersect(nowAds);
                return result.ToArray();
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "SuggestProducts";
                fault.Reason = "Error in suggesting products or finding relatives .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public int[] SuggestPersons(string productName)
        {
            try
            {
                string[] relativeProducts = FindRelatives(productName);

                ECDBEntities entity = new ECDBEntities();
                var ids = (from purchase in entity.PurchaseTbls
                           where
                               relativeProducts.Contains(purchase.ProductName) &&
                               Math.Abs((double) EntityFunctions.DiffMonths(DateTime.Today, purchase.Date.Value)) <= NumberOfMonthesForPurchase
                           select purchase.Cid).Distinct();

                return ids.ToArray();
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "SuggestPersons";
                fault.Reason = "Error in suggesting persons for buyying product name :  " + productName + " .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public List<int>[] FindBestCustomers() // returns each customer in his/her cluster
        {
            try
            {
                List<int>[] results = new List<int>[3];
                // or 4 cluster because 4th cluster has some poor customers to recommend to purchase goods
                for (int i = 0; i < results.Length; i++)
                {
                    results[i] = new List<int>();
                }

                ECDBEntities entity = new ECDBEntities();
                int numberOfBests = (int) (SAMPLE_PERCENT*entity.CustomerTbls.Count());

                // ------------------------------------- FORMULAS -------------------------------------
                // Formula 1
                // (1) / (3)
                var idsFormula1 =
                    entity.CustomerTbls.OrderByDescending(
                        customer => (double) customer.NumberOfPurchases/(double) customer.NumberOfLogins).Select(
                            customer => customer.Cid).Take(numberOfBests);

                // Formula 2
                // 1 / (4) + (5) => max   or   (4) + (5) => min
                var idsFormula2 =
                    entity.CustomerTbls.OrderBy(
                        customer =>
                        (Math.Abs((int) EntityFunctions.DiffMinutes(DateTime.Now, customer.LastLoginDate.Value)) +
                         Math.Abs((int) EntityFunctions.DiffMinutes(DateTime.Now, customer.LastPurchaseDate.Value)))).
                        Select(
                            customer => customer.Cid).
                        Take(numberOfBests);

                // Formula 3
                // (4) / (5)  +  (1) / (2)
                var idsFormula3 = entity.CustomerTbls.OrderByDescending(
                    customer =>
                    Math.Abs((double) EntityFunctions.DiffMinutes(DateTime.Now, customer.LastLoginDate.Value))/
                    Math.Abs((double) EntityFunctions.DiffMinutes(DateTime.Now, customer.LastPurchaseDate.Value)) +
                    (double) customer.NumberOfPurchases/(double) customer.LoggedInDuration).Select(
                        customer => customer.Cid)
                    .Take(
                        numberOfBests);

                results[0].AddRange(idsFormula1.Intersect(idsFormula2).Intersect(idsFormula3));

                results[1].AddRange(
                    idsFormula1.Intersect(idsFormula2).Union(idsFormula1.Intersect(idsFormula3)).Union(
                        idsFormula2.Intersect(idsFormula3)).Except(results[0]));

                results[2].AddRange(
                    idsFormula1.Union(idsFormula2).Union(idsFormula3).Except(results[0]).Except(results[1]));


                // ------------------- Working With Database's Best Customers Table -------------------
                // Removing Last Data From Best Customers Table
                entity.ExecuteStoreCommand("DELETE BestCustomersTbls");

                // Adding Better Customers To Best Customers Table))
                for (int i = 0; i < results.Length; i++)
                {
                    foreach (var cid in results[i])
                    {
                        BestCustomersTbl bc = new BestCustomersTbl();
                        bc.ClusterId = i + 1;
                        bc.Cid = cid;
                        entity.AddToBestCustomersTbls(bc);
                    }
                }
                entity.SaveChanges();

                return results;
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "FindBestCustomers";
                fault.Reason = "Error in finding best customers occurred .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public List<int>[] SuggestCustomersInTheirCluster(string product)
        {
            try
            {
                List<int>[] results = new List<int>[4];
                int[] personsId = SuggestPersons(product);
                List<int>[] bestPersons = FindBestCustomers();
                int i = 0;
                for (; i < bestPersons.Length; i++)
                {
                    results[i] = new List<int>();
                    results[i].AddRange(bestPersons[i].Intersect(personsId));
                }
                results[i] = new List<int>();
                results[i].AddRange(personsId.Except(bestPersons[0]).Except(bestPersons[1]).Except(bestPersons[2]));
                return results;
            }
            catch (Exception ex)
            {
                MySoapFault fault = new MySoapFault();
                fault.Operation = "SuggestCustomersInTheirCluster";
                fault.Reason = "Error in suggesting customers in their clusters for product :  " + product + " .";
                fault.Details = ex.Message;
                fault.MoreDetails = ex.StackTrace;
                throw new FaultException<MySoapFault>(fault);
            }
        }

        public void AdvertiseNow()
        {
            throw new NotImplementedException();
        }


        // < just for testing >
        public int GiveMeCount()
        {
            var res = linkedDataProxy.ExceuteQuery("select ?a ?b ?c where {?a ?b ?c} LIMIT 5");
            return res.items.Count();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        // </ just for testing >
    }
}