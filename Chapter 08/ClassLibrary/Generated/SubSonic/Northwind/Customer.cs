using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;


//Generated on 6/10/2007 10:06:54 PM by brennan

namespace Chapter08.NorthwindDAL{
    /// <summary>
    /// Strongly-typed collection for the Customer class.
    /// </summary>
    [Serializable]
    public partial class CustomerCollection : ActiveList<Customer> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public CustomerCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public CustomerCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public CustomerCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return BetweenAnd(columnName, dateStart, dateEnd);
        }

        public CustomerCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public CustomerCollection Where(string columnName, object value) 
	    {
		    if(value != DBNull.Value && value != null)
		    {	
			    return Where(columnName, Comparison.Equals, value);
		    }

		    else
		    {
			    return Where(columnName, Comparison.Is, DBNull.Value);
		    }

        }

    	
        public CustomerCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public CustomerCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            BetweenAnd between = new BetweenAnd();
            between.ColumnName = columnName;
            between.StartDate = dateStart;
            between.EndDate = dateEnd;
            between.StartParameterName = "start" + columnName; 
            between.EndParameterName = "end" + columnName; 
            betweens.Add(between);
            return this;
        }

    	
        public CustomerCollection Load() 
        {
            Query qry = new Query(Customer.Schema);
            CheckLogicalDelete(qry);
            foreach (Where where in wheres) 
            {
                qry.AddWhere(where);
            }

             
            foreach (BetweenAnd between in betweens)
            {
                qry.AddBetweenAnd(between);
            }

            if (orderBy != null)
            {
                qry.OrderBy = orderBy;
            }

            IDataReader rdr = qry.ExecuteReader();
            this.Load(rdr);
            rdr.Close();
            return this;
        }

        
        public CustomerCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Customers table.
    /// </summary>
    [Serializable]
    public partial class Customer : ActiveRecord<Customer>
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }

	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }

                return BaseSchema;
            }

        }

    	
        private static void GetTableSchema() 
	    {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
				TableSchema.Table schema = new TableSchema.Table("Customers", TableType.Table, DataService.GetInstance("Northwind"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarCustomerID = new TableSchema.TableColumn(schema);
                colvarCustomerID.ColumnName = "CustomerID";
                colvarCustomerID.DataType = DbType.String;
                colvarCustomerID.MaxLength = 5;
                colvarCustomerID.AutoIncrement = false;
                colvarCustomerID.IsNullable = false;
                colvarCustomerID.IsPrimaryKey = true;
                colvarCustomerID.IsForeignKey = false;
                colvarCustomerID.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCustomerID);
                
                TableSchema.TableColumn colvarCompanyName = new TableSchema.TableColumn(schema);
                colvarCompanyName.ColumnName = "CompanyName";
                colvarCompanyName.DataType = DbType.String;
                colvarCompanyName.MaxLength = 40;
                colvarCompanyName.AutoIncrement = false;
                colvarCompanyName.IsNullable = false;
                colvarCompanyName.IsPrimaryKey = false;
                colvarCompanyName.IsForeignKey = false;
                colvarCompanyName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCompanyName);
                
                TableSchema.TableColumn colvarContactName = new TableSchema.TableColumn(schema);
                colvarContactName.ColumnName = "ContactName";
                colvarContactName.DataType = DbType.String;
                colvarContactName.MaxLength = 30;
                colvarContactName.AutoIncrement = false;
                colvarContactName.IsNullable = true;
                colvarContactName.IsPrimaryKey = false;
                colvarContactName.IsForeignKey = false;
                colvarContactName.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarContactName);
                
                TableSchema.TableColumn colvarContactTitle = new TableSchema.TableColumn(schema);
                colvarContactTitle.ColumnName = "ContactTitle";
                colvarContactTitle.DataType = DbType.String;
                colvarContactTitle.MaxLength = 30;
                colvarContactTitle.AutoIncrement = false;
                colvarContactTitle.IsNullable = true;
                colvarContactTitle.IsPrimaryKey = false;
                colvarContactTitle.IsForeignKey = false;
                colvarContactTitle.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarContactTitle);
                
                TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
                colvarAddress.ColumnName = "Address";
                colvarAddress.DataType = DbType.String;
                colvarAddress.MaxLength = 60;
                colvarAddress.AutoIncrement = false;
                colvarAddress.IsNullable = true;
                colvarAddress.IsPrimaryKey = false;
                colvarAddress.IsForeignKey = false;
                colvarAddress.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarAddress);
                
                TableSchema.TableColumn colvarCity = new TableSchema.TableColumn(schema);
                colvarCity.ColumnName = "City";
                colvarCity.DataType = DbType.String;
                colvarCity.MaxLength = 15;
                colvarCity.AutoIncrement = false;
                colvarCity.IsNullable = true;
                colvarCity.IsPrimaryKey = false;
                colvarCity.IsForeignKey = false;
                colvarCity.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCity);
                
                TableSchema.TableColumn colvarRegion = new TableSchema.TableColumn(schema);
                colvarRegion.ColumnName = "Region";
                colvarRegion.DataType = DbType.String;
                colvarRegion.MaxLength = 15;
                colvarRegion.AutoIncrement = false;
                colvarRegion.IsNullable = true;
                colvarRegion.IsPrimaryKey = false;
                colvarRegion.IsForeignKey = false;
                colvarRegion.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarRegion);
                
                TableSchema.TableColumn colvarPostalCode = new TableSchema.TableColumn(schema);
                colvarPostalCode.ColumnName = "PostalCode";
                colvarPostalCode.DataType = DbType.String;
                colvarPostalCode.MaxLength = 10;
                colvarPostalCode.AutoIncrement = false;
                colvarPostalCode.IsNullable = true;
                colvarPostalCode.IsPrimaryKey = false;
                colvarPostalCode.IsForeignKey = false;
                colvarPostalCode.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarPostalCode);
                
                TableSchema.TableColumn colvarCountry = new TableSchema.TableColumn(schema);
                colvarCountry.ColumnName = "Country";
                colvarCountry.DataType = DbType.String;
                colvarCountry.MaxLength = 15;
                colvarCountry.AutoIncrement = false;
                colvarCountry.IsNullable = true;
                colvarCountry.IsPrimaryKey = false;
                colvarCountry.IsForeignKey = false;
                colvarCountry.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarCountry);
                
                TableSchema.TableColumn colvarPhone = new TableSchema.TableColumn(schema);
                colvarPhone.ColumnName = "Phone";
                colvarPhone.DataType = DbType.String;
                colvarPhone.MaxLength = 24;
                colvarPhone.AutoIncrement = false;
                colvarPhone.IsNullable = true;
                colvarPhone.IsPrimaryKey = false;
                colvarPhone.IsForeignKey = false;
                colvarPhone.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarPhone);
                
                TableSchema.TableColumn colvarFax = new TableSchema.TableColumn(schema);
                colvarFax.ColumnName = "Fax";
                colvarFax.DataType = DbType.String;
                colvarFax.MaxLength = 24;
                colvarFax.AutoIncrement = false;
                colvarFax.IsNullable = true;
                colvarFax.IsPrimaryKey = false;
                colvarFax.IsForeignKey = false;
                colvarFax.IsReadOnly = false;
                
                
                schema.Columns.Add(colvarFax);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Northwind"].AddSchema("Customers",schema);
            }

        }

        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }

	    #endregion
	    
	    #region .ctors
	    public Customer()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Customer(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Customer(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("CustomerID")]
        public string CustomerID 
	    {
		    get { return GetColumnValue<string>("CustomerID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CustomerID", value);
            }

        }

	      
        [XmlAttribute("CompanyName")]
        public string CompanyName 
	    {
		    get { return GetColumnValue<string>("CompanyName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CompanyName", value);
            }

        }

	      
        [XmlAttribute("ContactName")]
        public string ContactName 
	    {
		    get { return GetColumnValue<string>("ContactName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ContactName", value);
            }

        }

	      
        [XmlAttribute("ContactTitle")]
        public string ContactTitle 
	    {
		    get { return GetColumnValue<string>("ContactTitle"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ContactTitle", value);
            }

        }

	      
        [XmlAttribute("Address")]
        public string Address 
	    {
		    get { return GetColumnValue<string>("Address"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Address", value);
            }

        }

	      
        [XmlAttribute("City")]
        public string City 
	    {
		    get { return GetColumnValue<string>("City"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("City", value);
            }

        }

	      
        [XmlAttribute("Region")]
        public string Region 
	    {
		    get { return GetColumnValue<string>("Region"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Region", value);
            }

        }

	      
        [XmlAttribute("PostalCode")]
        public string PostalCode 
	    {
		    get { return GetColumnValue<string>("PostalCode"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PostalCode", value);
            }

        }

	      
        [XmlAttribute("Country")]
        public string Country 
	    {
		    get { return GetColumnValue<string>("Country"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Country", value);
            }

        }

	      
        [XmlAttribute("Phone")]
        public string Phone 
	    {
		    get { return GetColumnValue<string>("Phone"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Phone", value);
            }

        }

	      
        [XmlAttribute("Fax")]
        public string Fax 
	    {
		    get { return GetColumnValue<string>("Fax"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Fax", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Chapter08.NorthwindDAL.CustomerCustomerDemoCollection CustomerCustomerDemoRecords()
		{
			return new Chapter08.NorthwindDAL.CustomerCustomerDemoCollection().Where(CustomerCustomerDemo.Columns.CustomerID, CustomerID).Load();
		}

		public Chapter08.NorthwindDAL.OrderCollection Orders()
		{
			return new Chapter08.NorthwindDAL.OrderCollection().Where(Order.Columns.CustomerID, CustomerID).Load();
		}

		#endregion
		
	 	
			
	    
	    //no foreign key tables defined (0)
	    
	    
	    
	    #region Many To Many Helpers
	    
	     
        public Chapter08.NorthwindDAL.CustomerDemographicCollection GetCustomerDemographicCollection() {
            return Customer.GetCustomerDemographicCollection(this.CustomerID);
        }

        public static Chapter08.NorthwindDAL.CustomerDemographicCollection GetCustomerDemographicCollection(string varCustomerID) {
            SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
                "SELECT * FROM CustomerDemographics INNER JOIN CustomerCustomerDemo ON "+
                "CustomerDemographics.CustomerTypeID=CustomerCustomerDemo.CustomerTypeID WHERE CustomerCustomerDemo.CustomerID=@CustomerID", Customer.Schema.Provider.Name);
            
            cmd.AddParameter("@CustomerID", varCustomerID);
            
            IDataReader rdr = SubSonic.DataService.GetReader(cmd);
            CustomerDemographicCollection coll = new CustomerDemographicCollection();
            coll.LoadAndCloseReader(rdr);
            return coll;
        }

        public static void SaveCustomerDemographicMap(string varCustomerID, CustomerDemographicCollection items) {
            
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
            QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerCustomerDemo WHERE CustomerID=@CustomerID", Customer.Schema.Provider.Name);
            cmdDel.AddParameter("@CustomerID", varCustomerID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (CustomerDemographic item in items)
            {
				CustomerCustomerDemo varCustomerCustomerDemo = new CustomerCustomerDemo();
				varCustomerCustomerDemo.SetColumnValue("CustomerID", varCustomerID);
				varCustomerCustomerDemo.SetColumnValue("CustomerTypeID", item.GetPrimaryKeyValue());
				varCustomerCustomerDemo.Save();
            }

        }

        public static void SaveCustomerDemographicMap(string varCustomerID, System.Web.UI.WebControls.ListItemCollection itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerCustomerDemo WHERE CustomerID=@CustomerID", Customer.Schema.Provider.Name);
            cmdDel.AddParameter("@CustomerID", varCustomerID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (System.Web.UI.WebControls.ListItem l in itemList) 
            {
                if (l.Selected) 
                {
					CustomerCustomerDemo varCustomerCustomerDemo = new CustomerCustomerDemo();
					varCustomerCustomerDemo.SetColumnValue("CustomerID", varCustomerID);
					varCustomerCustomerDemo.SetColumnValue("CustomerTypeID", l.Value);
					varCustomerCustomerDemo.Save();
                }

            }

        }

        public static void SaveCustomerDemographicMap(string varCustomerID , string[] itemList) 
        {
            QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
            //delete out the existing
             QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerCustomerDemo WHERE CustomerID=@CustomerID", Customer.Schema.Provider.Name);
            cmdDel.AddParameter("@CustomerID", varCustomerID);
            //add this in
            coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
            foreach (string item in itemList) 
            {
            	CustomerCustomerDemo varCustomerCustomerDemo = new CustomerCustomerDemo();
				varCustomerCustomerDemo.SetColumnValue("CustomerID", varCustomerID);
				varCustomerCustomerDemo.SetColumnValue("CustomerTypeID", item);
				varCustomerCustomerDemo.Save();
            }

        }

        
        public static void DeleteCustomerDemographicMap(string varCustomerID) 
        {
            QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerCustomerDemo WHERE CustomerID=@CustomerID", Customer.Schema.Provider.Name);
            cmdDel.AddParameter("@CustomerID", varCustomerID);
            DataService.ExecuteQuery(cmdDel);
		}

	    
	    #endregion
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varCustomerID,string varCompanyName,string varContactName,string varContactTitle,string varAddress,string varCity,string varRegion,string varPostalCode,string varCountry,string varPhone,string varFax)
	    {
		    Customer item = new Customer();
		    
            item.CustomerID = varCustomerID;
            
            item.CompanyName = varCompanyName;
            
            item.ContactName = varContactName;
            
            item.ContactTitle = varContactTitle;
            
            item.Address = varAddress;
            
            item.City = varCity;
            
            item.Region = varRegion;
            
            item.PostalCode = varPostalCode;
            
            item.Country = varCountry;
            
            item.Phone = varPhone;
            
            item.Fax = varFax;
            
	    
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(string varCustomerID,string varCompanyName,string varContactName,string varContactTitle,string varAddress,string varCity,string varRegion,string varPostalCode,string varCountry,string varPhone,string varFax)
	    {
		    Customer item = new Customer();
		    
                item.CustomerID = varCustomerID;
				
                item.CompanyName = varCompanyName;
				
                item.ContactName = varContactName;
				
                item.ContactTitle = varContactTitle;
				
                item.Address = varAddress;
				
                item.City = varCity;
				
                item.Region = varRegion;
				
                item.PostalCode = varPostalCode;
				
                item.Country = varCountry;
				
                item.Phone = varPhone;
				
                item.Fax = varFax;
				
		    item.IsNew = false;
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

	    #endregion
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string CustomerID = @"CustomerID";
            
            public static string CompanyName = @"CompanyName";
            
            public static string ContactName = @"ContactName";
            
            public static string ContactTitle = @"ContactTitle";
            
            public static string Address = @"Address";
            
            public static string City = @"City";
            
            public static string Region = @"Region";
            
            public static string PostalCode = @"PostalCode";
            
            public static string Country = @"Country";
            
            public static string Phone = @"Phone";
            
            public static string Fax = @"Fax";
            
	    }

	    #endregion
    }

}

