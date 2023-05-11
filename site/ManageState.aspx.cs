using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Model;

namespace site
{
    public partial class ManageState : System.Web.UI.Page
    {
        Service s = new Service();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
                bindCountry();



            }

        }
        void bindData()
        {
            List<StateSubModel> CL = s.State.getStateActiveSubModel().OrderByDescending(c => c.St.StateId).ToList();
            rptr.DataSource = CL;
            rptr.DataBind();
        }

        void bindCountry()
        {
            List<Tbl_Country> COL = s.Country.Get().Where(q => q.Isactive == true && q.Isdisplay == true).OrderByDescending(c => c.CountryName).ToList();
            if (COL.Count > 0)
            {
                drpcountry.DataSource = COL;
                drpcountry.DataTextField = "CountryName";
                drpcountry.DataValueField = "CountryId";
                drpcountry.DataBind();
                drpcountry.Items.Insert(0, new ListItem("-- Select Country --", "0"));
            }
            else
            {
                drpcountry.Items.Insert(0, new ListItem("-- Select Country --", "0"));
            }
        }
        protected void btn_Click1(object sender, EventArgs e)
        {

            Response.Redirect("ManageCountry.aspx");

        }

        protected void btn_Click2(object sender, EventArgs e)
        {
            Response.Redirect("ManageState.aspx");


        }

        protected void btn_Click3(object sender, EventArgs e)
        {
            Response.Redirect("ManageCity.aspx");

        }

        protected void btnsubmit_Click(object sender, EventArgs e)


        {

            Tbl_State CL = new Tbl_State();
            if (!chkisdisplay.Checked)
            {
                CL.Isdisplay = false;
            }
            else
            {
                CL.Isdisplay = true;
            }
            CL.CountryId = Convert.ToInt32(drpcountry.SelectedValue);
            CL.StateName = txtstatename.Text;
            CL.Isactive = true;
            
            if (lblid.Text != null && lblid.Text != "")
            {
                CL.StateId = Convert.ToInt32(lblid.Text);
                Tbl_State CLS = s.State.Update(CL);
                MsgThenRedirectTo("Data Updated Successfully", "ManageState");
            }
            else
            {
                Tbl_State CLS = s.State.Add(CL);
                MsgThenRedirectTo("Data Inserted Successfully", "ManageState");
            }
        }
    
        

        protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Tbl_State al = s.State.Get(Convert.ToInt32(e.CommandArgument));
                txtstatename.Text = al.StateName;
                drpcountry.SelectedValue = al.CountryId.ToString();
                lblid.Text = al.StateId.ToString();
            
                if (al.Isdisplay != true)
                {
                    chkisdisplay.Checked = false;
                }
                else
                {
                    chkisdisplay.Checked = true;
                }
            }
            if (e.CommandName == "Delete")
            {
                Tbl_State objA = new Tbl_State();
                objA.StateId = Convert.ToInt32(e.CommandArgument);
             
                objA.Isactive = false;
                //objS.IsUpdatedOn = DateTime.Now;
                s.State.Update(objA);
                MsgThenRedirectTo("Data Deleted Successfully", "ManageState");
                bindData();
            }
        }




        protected void DrpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void MsgBox(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "Message", "alert('" + message + "')", true);
            }
        }

        public void MsgThenRedirectTo(string message, string pageName)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(),
                    "MessageThenRedirect", "alert('" + message +
                    "');window.location='" + pageName + ".aspx';", true);
            }


        }
    }
}