using System;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Security.Permissions;
using System.Data.Common;
using System.Data;
using System.Web.Caching;

/// <summary>
/// Shamelessly stolen from Jeff Prosise's excellent article on SiteMapProviders
/// I liked it, but needed to do this the SubSonic way...
/// </summary>
[SqlClientPermission(SecurityAction.Demand, Unrestricted = true)]
public class SubSonicSiteMapProvider : StaticSiteMapProvider {

    private Dictionary<int, SiteMapNode> _nodes = new Dictionary<int, SiteMapNode>(16);
    private readonly object _lock = new object();
    private SiteMapNode _root;

    public override void Initialize(string name, NameValueCollection config) {
        // Verify that config isn't null
        if (config == null)
            throw new ArgumentNullException("config");

        // Assign the provider a default name if it doesn't have one
        if (String.IsNullOrEmpty(name))
            name = "SubSonicSiteMapProvider";

        // Add a default "description" attribute to config if the
        // attribute doesn�t exist or is empty
        if (string.IsNullOrEmpty(config["description"])) {
            config.Remove("description");
            config.Add("description", "SubSonic site map provider");
        }

        // Call the base class's Initialize method
        base.Initialize(name, config);


    }
    
    public override SiteMapNode BuildSiteMap() {
        lock (_lock) {
            // Return immediately if this method has been called before
            if (_root != null)
                return _root;

            CMS.PageCollection links = new CMS.PageCollection().Load();
            
            //top level node
            _root = new SiteMapNode(this, "0", "~/default.aspx", "Home", "Return to main page", null, null, null, null);
            AddNode(_root, null);

            //you can change this as needed
            string rewrittenDirectory = "~/view/";


            foreach (CMS.Page link in links) {
                string[] rolelist = null;
                if (!String.IsNullOrEmpty(link.Roles))
                    rolelist = link.Roles.Split(new char[] { ',', ';' }, 512);

                if (link.ParentID == null) {
                    SiteMapNode node = new SiteMapNode(this, link.PageID.ToString(), rewrittenDirectory + link.PageUrl, link.MenuTitle, link.Summary, rolelist, null, null, null);
                    AddNode(node, _root);

                }
            }

            //add in the child nodes
            foreach (CMS.Page link in links) {
                string[] rolelist = null;
                if (!String.IsNullOrEmpty(link.Roles))
                    rolelist = link.Roles.Split(new char[] { ',', ';' }, 512);
                if (link.ParentID != null) {
                    // Create a SiteMapNode
                    SiteMapNode node = new SiteMapNode(this, link.PageID.ToString(), rewrittenDirectory + link.PageUrl, link.MenuTitle, link.Summary, rolelist, null, null, null);
                    SiteMapNode parentNode = null;
                    //loop the nodes to find the parent
                    foreach (CMS.Page link2 in links) {
                        if (link2.PageID == link.ParentID) {
                            parentNode = new SiteMapNode(this, link2.PageID.ToString(), rewrittenDirectory + link2.PageUrl, link2.MenuTitle, link2.Summary, rolelist, null, null, null);
                            break;
                        }
                    }
                    AddNode(node, parentNode);
                }
            }


            return _root;
        }
    }

    protected override SiteMapNode GetRootNodeCore() {
        lock (_lock) {
            BuildSiteMap();
            return _root;
        }
    }

    public void Reload() {
        lock (_lock) {
            // Refresh the site map
            Clear();
            _nodes.Clear();
            _root = null;
        }
    }

}