﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("ECommerceDBModel", "FK_BestCustomersTbls_CustomerTbls", "CustomerTbls", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(ECommerceServiceLibrary.CustomerTbl), "BestCustomersTbls", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ECommerceServiceLibrary.BestCustomersTbl), true)]
[assembly: EdmRelationshipAttribute("ECommerceDBModel", "FK_PurchaseTbls_CustomerTbls", "CustomerTbls", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(ECommerceServiceLibrary.CustomerTbl), "PurchaseTbls", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ECommerceServiceLibrary.PurchaseTbl), true)]

#endregion

namespace ECommerceServiceLibrary
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class ECDBEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new ECDBEntities object using the connection string found in the 'ECDBEntities' section of the application configuration file.
        /// </summary>
        public ECDBEntities() : base("name=ECDBEntities", "ECDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ECDBEntities object.
        /// </summary>
        public ECDBEntities(string connectionString) : base(connectionString, "ECDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ECDBEntities object.
        /// </summary>
        public ECDBEntities(EntityConnection connection) : base(connection, "ECDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<AdsTbl> AdsTbls
        {
            get
            {
                if ((_AdsTbls == null))
                {
                    _AdsTbls = base.CreateObjectSet<AdsTbl>("AdsTbls");
                }
                return _AdsTbls;
            }
        }
        private ObjectSet<AdsTbl> _AdsTbls;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<BestCustomersTbl> BestCustomersTbls
        {
            get
            {
                if ((_BestCustomersTbls == null))
                {
                    _BestCustomersTbls = base.CreateObjectSet<BestCustomersTbl>("BestCustomersTbls");
                }
                return _BestCustomersTbls;
            }
        }
        private ObjectSet<BestCustomersTbl> _BestCustomersTbls;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<CustomerTbl> CustomerTbls
        {
            get
            {
                if ((_CustomerTbls == null))
                {
                    _CustomerTbls = base.CreateObjectSet<CustomerTbl>("CustomerTbls");
                }
                return _CustomerTbls;
            }
        }
        private ObjectSet<CustomerTbl> _CustomerTbls;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PurchaseTbl> PurchaseTbls
        {
            get
            {
                if ((_PurchaseTbls == null))
                {
                    _PurchaseTbls = base.CreateObjectSet<PurchaseTbl>("PurchaseTbls");
                }
                return _PurchaseTbls;
            }
        }
        private ObjectSet<PurchaseTbl> _PurchaseTbls;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<sysdiagram> sysdiagrams
        {
            get
            {
                if ((_sysdiagrams == null))
                {
                    _sysdiagrams = base.CreateObjectSet<sysdiagram>("sysdiagrams");
                }
                return _sysdiagrams;
            }
        }
        private ObjectSet<sysdiagram> _sysdiagrams;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the AdsTbls EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAdsTbls(AdsTbl adsTbl)
        {
            base.AddObject("AdsTbls", adsTbl);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the BestCustomersTbls EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBestCustomersTbls(BestCustomersTbl bestCustomersTbl)
        {
            base.AddObject("BestCustomersTbls", bestCustomersTbl);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the CustomerTbls EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCustomerTbls(CustomerTbl customerTbl)
        {
            base.AddObject("CustomerTbls", customerTbl);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PurchaseTbls EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPurchaseTbls(PurchaseTbl purchaseTbl)
        {
            base.AddObject("PurchaseTbls", purchaseTbl);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the sysdiagrams EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTosysdiagrams(sysdiagram sysdiagram)
        {
            base.AddObject("sysdiagrams", sysdiagram);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ECommerceDBModel", Name="AdsTbl")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class AdsTbl : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new AdsTbl object.
        /// </summary>
        /// <param name="aId">Initial value of the AId property.</param>
        /// <param name="productName">Initial value of the ProductName property.</param>
        public static AdsTbl CreateAdsTbl(global::System.Int32 aId, global::System.String productName)
        {
            AdsTbl adsTbl = new AdsTbl();
            adsTbl.AId = aId;
            adsTbl.ProductName = productName;
            return adsTbl;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 AId
        {
            get
            {
                return _AId;
            }
            set
            {
                if (_AId != value)
                {
                    OnAIdChanging(value);
                    ReportPropertyChanging("AId");
                    _AId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("AId");
                    OnAIdChanged();
                }
            }
        }
        private global::System.Int32 _AId;
        partial void OnAIdChanging(global::System.Int32 value);
        partial void OnAIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                OnProductNameChanging(value);
                ReportPropertyChanging("ProductName");
                _ProductName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ProductName");
                OnProductNameChanged();
            }
        }
        private global::System.String _ProductName;
        partial void OnProductNameChanging(global::System.String value);
        partial void OnProductNameChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ECommerceDBModel", Name="BestCustomersTbl")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class BestCustomersTbl : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new BestCustomersTbl object.
        /// </summary>
        /// <param name="cid">Initial value of the Cid property.</param>
        /// <param name="clusterId">Initial value of the ClusterId property.</param>
        public static BestCustomersTbl CreateBestCustomersTbl(global::System.Int32 cid, global::System.Int32 clusterId)
        {
            BestCustomersTbl bestCustomersTbl = new BestCustomersTbl();
            bestCustomersTbl.Cid = cid;
            bestCustomersTbl.ClusterId = clusterId;
            return bestCustomersTbl;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Cid
        {
            get
            {
                return _Cid;
            }
            set
            {
                if (_Cid != value)
                {
                    OnCidChanging(value);
                    ReportPropertyChanging("Cid");
                    _Cid = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Cid");
                    OnCidChanged();
                }
            }
        }
        private global::System.Int32 _Cid;
        partial void OnCidChanging(global::System.Int32 value);
        partial void OnCidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ClusterId
        {
            get
            {
                return _ClusterId;
            }
            set
            {
                if (_ClusterId != value)
                {
                    OnClusterIdChanging(value);
                    ReportPropertyChanging("ClusterId");
                    _ClusterId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ClusterId");
                    OnClusterIdChanged();
                }
            }
        }
        private global::System.Int32 _ClusterId;
        partial void OnClusterIdChanging(global::System.Int32 value);
        partial void OnClusterIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ECommerceDBModel", "FK_BestCustomersTbls_CustomerTbls", "CustomerTbls")]
        public CustomerTbl CustomerTbl
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CustomerTbl>("ECommerceDBModel.FK_BestCustomersTbls_CustomerTbls", "CustomerTbls").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CustomerTbl>("ECommerceDBModel.FK_BestCustomersTbls_CustomerTbls", "CustomerTbls").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<CustomerTbl> CustomerTblReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CustomerTbl>("ECommerceDBModel.FK_BestCustomersTbls_CustomerTbls", "CustomerTbls");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<CustomerTbl>("ECommerceDBModel.FK_BestCustomersTbls_CustomerTbls", "CustomerTbls", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ECommerceDBModel", Name="CustomerTbl")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CustomerTbl : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CustomerTbl object.
        /// </summary>
        /// <param name="cid">Initial value of the Cid property.</param>
        /// <param name="cfamily">Initial value of the Cfamily property.</param>
        /// <param name="email">Initial value of the Email property.</param>
        public static CustomerTbl CreateCustomerTbl(global::System.Int32 cid, global::System.String cfamily, global::System.String email)
        {
            CustomerTbl customerTbl = new CustomerTbl();
            customerTbl.Cid = cid;
            customerTbl.Cfamily = cfamily;
            customerTbl.Email = email;
            return customerTbl;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Cid
        {
            get
            {
                return _Cid;
            }
            set
            {
                if (_Cid != value)
                {
                    OnCidChanging(value);
                    ReportPropertyChanging("Cid");
                    _Cid = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Cid");
                    OnCidChanged();
                }
            }
        }
        private global::System.Int32 _Cid;
        partial void OnCidChanging(global::System.Int32 value);
        partial void OnCidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Cname
        {
            get
            {
                return _Cname;
            }
            set
            {
                OnCnameChanging(value);
                ReportPropertyChanging("Cname");
                _Cname = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Cname");
                OnCnameChanged();
            }
        }
        private global::System.String _Cname;
        partial void OnCnameChanging(global::System.String value);
        partial void OnCnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Cfamily
        {
            get
            {
                return _Cfamily;
            }
            set
            {
                OnCfamilyChanging(value);
                ReportPropertyChanging("Cfamily");
                _Cfamily = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Cfamily");
                OnCfamilyChanged();
            }
        }
        private global::System.String _Cfamily;
        partial void OnCfamilyChanging(global::System.String value);
        partial void OnCfamilyChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> Age
        {
            get
            {
                return _Age;
            }
            set
            {
                OnAgeChanging(value);
                ReportPropertyChanging("Age");
                _Age = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Age");
                OnAgeChanged();
            }
        }
        private Nullable<global::System.Decimal> _Age;
        partial void OnAgeChanging(Nullable<global::System.Decimal> value);
        partial void OnAgeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> NumberOfPurchases
        {
            get
            {
                return _NumberOfPurchases;
            }
            set
            {
                OnNumberOfPurchasesChanging(value);
                ReportPropertyChanging("NumberOfPurchases");
                _NumberOfPurchases = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NumberOfPurchases");
                OnNumberOfPurchasesChanged();
            }
        }
        private Nullable<global::System.Int32> _NumberOfPurchases;
        partial void OnNumberOfPurchasesChanging(Nullable<global::System.Int32> value);
        partial void OnNumberOfPurchasesChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> LoggedInDuration
        {
            get
            {
                return _LoggedInDuration;
            }
            set
            {
                OnLoggedInDurationChanging(value);
                ReportPropertyChanging("LoggedInDuration");
                _LoggedInDuration = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LoggedInDuration");
                OnLoggedInDurationChanged();
            }
        }
        private Nullable<global::System.Int32> _LoggedInDuration;
        partial void OnLoggedInDurationChanging(Nullable<global::System.Int32> value);
        partial void OnLoggedInDurationChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> NumberOfLogins
        {
            get
            {
                return _NumberOfLogins;
            }
            set
            {
                OnNumberOfLoginsChanging(value);
                ReportPropertyChanging("NumberOfLogins");
                _NumberOfLogins = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NumberOfLogins");
                OnNumberOfLoginsChanged();
            }
        }
        private Nullable<global::System.Int32> _NumberOfLogins;
        partial void OnNumberOfLoginsChanging(Nullable<global::System.Int32> value);
        partial void OnNumberOfLoginsChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastLoginDate
        {
            get
            {
                return _LastLoginDate;
            }
            set
            {
                OnLastLoginDateChanging(value);
                ReportPropertyChanging("LastLoginDate");
                _LastLoginDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLoginDate");
                OnLastLoginDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastLoginDate;
        partial void OnLastLoginDateChanging(Nullable<global::System.DateTime> value);
        partial void OnLastLoginDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastPurchaseDate
        {
            get
            {
                return _LastPurchaseDate;
            }
            set
            {
                OnLastPurchaseDateChanging(value);
                ReportPropertyChanging("LastPurchaseDate");
                _LastPurchaseDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastPurchaseDate");
                OnLastPurchaseDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastPurchaseDate;
        partial void OnLastPurchaseDateChanging(Nullable<global::System.DateTime> value);
        partial void OnLastPurchaseDateChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ECommerceDBModel", "FK_BestCustomersTbls_CustomerTbls", "BestCustomersTbls")]
        public EntityCollection<BestCustomersTbl> BestCustomersTbls
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<BestCustomersTbl>("ECommerceDBModel.FK_BestCustomersTbls_CustomerTbls", "BestCustomersTbls");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<BestCustomersTbl>("ECommerceDBModel.FK_BestCustomersTbls_CustomerTbls", "BestCustomersTbls", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ECommerceDBModel", "FK_PurchaseTbls_CustomerTbls", "PurchaseTbls")]
        public EntityCollection<PurchaseTbl> PurchaseTbls
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<PurchaseTbl>("ECommerceDBModel.FK_PurchaseTbls_CustomerTbls", "PurchaseTbls");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<PurchaseTbl>("ECommerceDBModel.FK_PurchaseTbls_CustomerTbls", "PurchaseTbls", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ECommerceDBModel", Name="PurchaseTbl")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class PurchaseTbl : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new PurchaseTbl object.
        /// </summary>
        /// <param name="purchaseId">Initial value of the PurchaseId property.</param>
        /// <param name="cid">Initial value of the Cid property.</param>
        /// <param name="productName">Initial value of the ProductName property.</param>
        public static PurchaseTbl CreatePurchaseTbl(global::System.Int32 purchaseId, global::System.Int32 cid, global::System.String productName)
        {
            PurchaseTbl purchaseTbl = new PurchaseTbl();
            purchaseTbl.PurchaseId = purchaseId;
            purchaseTbl.Cid = cid;
            purchaseTbl.ProductName = productName;
            return purchaseTbl;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PurchaseId
        {
            get
            {
                return _PurchaseId;
            }
            set
            {
                if (_PurchaseId != value)
                {
                    OnPurchaseIdChanging(value);
                    ReportPropertyChanging("PurchaseId");
                    _PurchaseId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PurchaseId");
                    OnPurchaseIdChanged();
                }
            }
        }
        private global::System.Int32 _PurchaseId;
        partial void OnPurchaseIdChanging(global::System.Int32 value);
        partial void OnPurchaseIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Cid
        {
            get
            {
                return _Cid;
            }
            set
            {
                OnCidChanging(value);
                ReportPropertyChanging("Cid");
                _Cid = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Cid");
                OnCidChanged();
            }
        }
        private global::System.Int32 _Cid;
        partial void OnCidChanging(global::System.Int32 value);
        partial void OnCidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                OnProductNameChanging(value);
                ReportPropertyChanging("ProductName");
                _ProductName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ProductName");
                OnProductNameChanged();
            }
        }
        private global::System.String _ProductName;
        partial void OnProductNameChanging(global::System.String value);
        partial void OnProductNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Date
        {
            get
            {
                return _Date;
            }
            set
            {
                OnDateChanging(value);
                ReportPropertyChanging("Date");
                _Date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Date");
                OnDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _Date;
        partial void OnDateChanging(Nullable<global::System.DateTime> value);
        partial void OnDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                OnQuantityChanging(value);
                ReportPropertyChanging("Quantity");
                _Quantity = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Quantity");
                OnQuantityChanged();
            }
        }
        private Nullable<global::System.Decimal> _Quantity;
        partial void OnQuantityChanging(Nullable<global::System.Decimal> value);
        partial void OnQuantityChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ECommerceDBModel", "FK_PurchaseTbls_CustomerTbls", "CustomerTbls")]
        public CustomerTbl CustomerTbl
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CustomerTbl>("ECommerceDBModel.FK_PurchaseTbls_CustomerTbls", "CustomerTbls").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CustomerTbl>("ECommerceDBModel.FK_PurchaseTbls_CustomerTbls", "CustomerTbls").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<CustomerTbl> CustomerTblReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<CustomerTbl>("ECommerceDBModel.FK_PurchaseTbls_CustomerTbls", "CustomerTbls");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<CustomerTbl>("ECommerceDBModel.FK_PurchaseTbls_CustomerTbls", "CustomerTbls", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ECommerceDBModel", Name="sysdiagram")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class sysdiagram : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new sysdiagram object.
        /// </summary>
        /// <param name="name">Initial value of the name property.</param>
        /// <param name="principal_id">Initial value of the principal_id property.</param>
        /// <param name="diagram_id">Initial value of the diagram_id property.</param>
        public static sysdiagram Createsysdiagram(global::System.String name, global::System.Int32 principal_id, global::System.Int32 diagram_id)
        {
            sysdiagram sysdiagram = new sysdiagram();
            sysdiagram.name = name;
            sysdiagram.principal_id = principal_id;
            sysdiagram.diagram_id = diagram_id;
            return sysdiagram;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 principal_id
        {
            get
            {
                return _principal_id;
            }
            set
            {
                Onprincipal_idChanging(value);
                ReportPropertyChanging("principal_id");
                _principal_id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("principal_id");
                Onprincipal_idChanged();
            }
        }
        private global::System.Int32 _principal_id;
        partial void Onprincipal_idChanging(global::System.Int32 value);
        partial void Onprincipal_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 diagram_id
        {
            get
            {
                return _diagram_id;
            }
            set
            {
                if (_diagram_id != value)
                {
                    Ondiagram_idChanging(value);
                    ReportPropertyChanging("diagram_id");
                    _diagram_id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("diagram_id");
                    Ondiagram_idChanged();
                }
            }
        }
        private global::System.Int32 _diagram_id;
        partial void Ondiagram_idChanging(global::System.Int32 value);
        partial void Ondiagram_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> version
        {
            get
            {
                return _version;
            }
            set
            {
                OnversionChanging(value);
                ReportPropertyChanging("version");
                _version = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("version");
                OnversionChanged();
            }
        }
        private Nullable<global::System.Int32> _version;
        partial void OnversionChanging(Nullable<global::System.Int32> value);
        partial void OnversionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] definition
        {
            get
            {
                return StructuralObject.GetValidValue(_definition);
            }
            set
            {
                OndefinitionChanging(value);
                ReportPropertyChanging("definition");
                _definition = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("definition");
                OndefinitionChanged();
            }
        }
        private global::System.Byte[] _definition;
        partial void OndefinitionChanging(global::System.Byte[] value);
        partial void OndefinitionChanged();

        #endregion
    
    }

    #endregion
    
}
