using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

//using GIBS.Modules.FlexMLS_TaxRates.Components;
//using GIBS.Modules.FlexMLS.Components;
using DotNetNuke.Common;
using GIBS.Modules.FlexMLS.Components;

namespace GIBS.Modules.FlexMLS_TaxRates
{
    public partial class ViewFlexMLS_TaxRates : PortalModuleBase, IActionable
    {

        public string _taxyear = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblH1Title.Text = "Cape Cod Real Estate Tax Rates";
                    _taxyear = DateTime.Now.Year.ToString();
                    LoadTaxRates();
                    LoadTowns();


                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        public void LoadTaxRates()
        {

            try
            {
             //   string year = DateTime.Now.Year.ToString();
                string town = "";

                if (Request.QueryString["town"] != null && Request.QueryString["town"] != "")
                {
                    town = Request.QueryString["town"].ToString();
                   // year = "";
                    _taxyear = "";
                    lblH1Title.Text = town + " Real Estate Tax Rate";
                    GetSeoValues(town.ToString(), "");

                }

                if (Request.QueryString["TaxYear"] != null && Request.QueryString["TaxYear"] != "")
                {
                    //town = Request.QueryString["town"].ToString();
                    // year = "";
                    _taxyear = Request.QueryString["TaxYear"].ToString();
                    lblH1Title.Text = _taxyear + " Cape Cod Real Estate Tax Rates";
                   // GetSeoValues(town.ToString());
                    GetSeoValues(town.ToString(), _taxyear.ToString());

                }

                List<FlexMLSInfo> items;
                FlexMLSController controller = new FlexMLSController();

                items = controller.TaxRates_GetList(town.ToString(), _taxyear.ToString());

                //bind the data
                GridView1.DataSource = items;
                GridView1.DataBind();



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        public void LoadTowns()
        {

            try
            {
                //   string year = DateTime.Now.Year.ToString();
                string town = "";


                List<FlexMLSInfo> items;
                FlexMLSController controller = new FlexMLSController();

                items = controller.TaxRates_GetList(town.ToString(), DateTime.Now.Year.ToString());

                //bind the data

                RepeaterTowns.DataSource = items;
                RepeaterTowns.DataBind();


            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        public void GetSeoValues(string _town, string _year)
        {

            try
            {
                if (_year.ToString().Length > 0)
                {
                    DotNetNuke.Framework.CDefault GIBSpage = (DotNetNuke.Framework.CDefault)this.Page;
                    GIBSpage.Title = _taxyear.ToString() + " " + _town.ToString() + " Cape Cod Tax Rates";
                    GIBSpage.KeyWords = _town.ToString() + ", " + _taxyear.ToString() + ", " + _town.ToString() + " Tax Rate, " + GIBSpage.KeyWords.ToString();
                    GIBSpage.Description = _taxyear.ToString() + " " + _town.ToString() + " tax rates. " + GIBSpage.Description.ToString();   // +" " + Settings["PageTitle"].ToString() + ". " + Settings["PageDescription"].ToString();
                    GIBSpage.Author = "Joseph M Aucoin, GIBS";
                }


                else
                {
                    DotNetNuke.Framework.CDefault GIBSpage = (DotNetNuke.Framework.CDefault)this.Page;
                    GIBSpage.Title =  _town.ToString() + " Real Estate Tax Rates";
                    GIBSpage.KeyWords = _town.ToString() + ", " + _taxyear.ToString() + ", " + _town.ToString() + " Tax Rate, " + GIBSpage.KeyWords.ToString();
                    GIBSpage.Description = _taxyear.ToString() + " " + _town.ToString() + " tax rates. " + GIBSpage.Description.ToString();   // +" " + Settings["PageTitle"].ToString() + ". " + Settings["PageDescription"].ToString();
                    GIBSpage.Author = "Joseph M Aucoin, GIBS";
                }



            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //StringBuilder _SearchCriteria = new StringBuilder();
                //_SearchCriteria.Capacity = 500;
                string townname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Town"));
                string taxyear = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TaxYear"));
                //string _pageName = DataBinder.Eval(e.Row.DataItem, "Town").ToString().Replace(" ", "_").ToString().Replace("&", "").ToString() + ".aspx";
                string _pageName = DataBinder.Eval(e.Row.DataItem, "Town").ToString().Replace(" ", "_").ToString().Replace("&", "").ToString() + "_Tax_Rates.aspx";

                HyperLink eLink = (HyperLink)e.Row.FindControl("Hyperlink2");


                string vLink = Globals.NavigateURL("View", "Town", townname.ToString());
                vLink = vLink.ToString().Replace("ctl/View/", "");
                vLink = vLink.ToString().Replace("Default.aspx", _pageName.ToString());
                eLink.Text = DataBinder.Eval(e.Row.DataItem, "Town").ToString() + " Real Estate Tax Rate";
                eLink.NavigateUrl = vLink.ToString();

                if (_taxyear.ToString() != DateTime.Now.Year.ToString() )
                {
                    //HyperlinkTaxYear
                    HyperLink HyperlinkTaxYear = (HyperLink)e.Row.FindControl("HyperlinkTaxYear");
                    string _pageName2 = DataBinder.Eval(e.Row.DataItem, "TaxYear").ToString() + "_Cape_Cod_Tax_Rates.aspx";
                    string vLink2 = Globals.NavigateURL("View", "TaxYear", taxyear.ToString());
                    vLink2 = vLink2.ToString().Replace("ctl/View/", "");
                    vLink2 = vLink2.ToString().Replace("Default.aspx", _pageName2.ToString());
                    HyperlinkTaxYear.NavigateUrl = vLink2.ToString();
                    
                }



            }

        }

        protected void RepeaterTowns_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hp = (HyperLink)e.Item.FindControl("HyperLink1");

                string townname = DataBinder.Eval(e.Item.DataItem, "Town").ToString();
                string _pageName = DataBinder.Eval(e.Item.DataItem, "Town").ToString().Replace(" ", "_").ToString().Replace("&", "").ToString() + "_Tax_Rates.aspx";

                string vLink = Globals.NavigateURL("View", "Town", townname.ToString());
                vLink = vLink.ToString().Replace("ctl/View/", "");
                vLink = vLink.ToString().Replace("Default.aspx", _pageName.ToString());
                hp.Text = DataBinder.Eval(e.Item.DataItem, "Town").ToString();
                hp.NavigateUrl = vLink.ToString();


            }

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // No requirement to implement code here
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Prevents the GridView from going into EDIT MODE (textboxes)
            e.Cancel = true;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Delete")
                {

                    //int ID = Convert.ToInt32(e.CommandArgument);


                    //FlexMLS_FavoritesController controller = new FlexMLS_FavoritesController();
                    //controller.FlexMLS_Favorites_Delete(ID);

                    //LoadGrid();

                }

                if (e.CommandName == "Edit")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);

                    //   FillIncomeExpenseEdit(ieID);


                }




            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        #region IActionable Members

        public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
        {
            get
            {
                //create a new action to add an item, this will be added to the controls
                //dropdown menu
                ModuleActionCollection actions = new ModuleActionCollection();
                //actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile),
                //    ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
                //     true, false);

                return actions;
            }
        }

        #endregion


        /// <summary>
        /// Handles the items being bound to the datalist control. In this method we merge the data with the
        /// template defined for this control to produce the result to display to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      
    }
}