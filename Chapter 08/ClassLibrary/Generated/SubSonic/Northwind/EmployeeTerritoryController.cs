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


//Generated on 6/10/2007 10:07:08 PM by brennan

namespace Chapter08.NorthwindDAL
{
    /// <summary>
    /// Controller class for EmployeeTerritories
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class EmployeeTerritoryController
    {
        // Preload our schema..
        EmployeeTerritory thisSchemaLoad = new EmployeeTerritory();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public EmployeeTerritoryCollection FetchAll()
        {
            EmployeeTerritoryCollection coll = new EmployeeTerritoryCollection();
            Query qry = new Query(EmployeeTerritory.Schema);
            coll.Load(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmployeeTerritoryCollection FetchByID(object EmployeeID)
        {
            EmployeeTerritoryCollection coll = new EmployeeTerritoryCollection().Where("EmployeeID", EmployeeID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmployeeTerritoryCollection FetchByQuery(Query qry)
        {
            EmployeeTerritoryCollection coll = new EmployeeTerritoryCollection();
            coll.Load(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object EmployeeID)
        {
            return (EmployeeTerritory.Delete(EmployeeID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object EmployeeID)
        {
            return (EmployeeTerritory.Destroy(EmployeeID) == 1);
        }

       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int EmployeeID,string TerritoryID)
	    {
		    EmployeeTerritory item = new EmployeeTerritory();
		    
            item.EmployeeID = EmployeeID;
            
            item.TerritoryID = TerritoryID;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int EmployeeID,string TerritoryID)
	    {
		    EmployeeTerritory item = new EmployeeTerritory();
		    
				item.EmployeeID = EmployeeID;
				
				item.TerritoryID = TerritoryID;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}
