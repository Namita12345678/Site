using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace site
{
    public partial class ManageCountry : System.Web.UI.Page
    {
        Service s = new Service();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindData();
                
            }


        }
        void bindData()
        {
            List<Tbl_Country> CL = s.Country.Get().Where(c=>c.Isactive == true).OrderByDescending(c => c.CountryId).ToList();
            rptr.DataSource = CL;
            rptr.DataBind();
        } 

        //This code is for nav bar where in each page when we click country state or city it should redirect to the that page.
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
            Tbl_Country CL = new Tbl_Country();
            if (!chkisdisplay.Checked)
            {
                CL.Isdisplay = false;
            }
            else
            {
                CL.Isdisplay = true;
            }
            CL.CountryName = txtname.Text;
            CL.CountryCode = txtcode.Text;
            CL.Isactive = true;
          
            if (lblid.Text != null && lblid.Text != "")
            {
                CL.CountryId = Convert.ToInt32(lblid.Text);
                Tbl_Country CLS = s.Country.Update(CL);
                MsgThenRedirectTo("Data Updated Successfully", "ManageCountry");
            }
            else
            {
                Tbl_Country CLS = s.Country.Add(CL);
                MsgThenRedirectTo("Data Inserted Successfully", "ManageCountry");
            }
        }

        protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Tbl_Country al = s.Country.Get(Convert.ToInt32(e.CommandArgument));
                txtname.Text = al.CountryName;
                txtcode.Text = al.CountryCode;
                lblid.Text = al.CountryId.ToString();
              
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
                Tbl_Country objA = new Tbl_Country();
                objA.CountryId = Convert.ToInt32(e.CommandArgument);
                Tbl_Country objC = s.Country.Get(objA.CountryId);
                objC.Isactive = false;
            
                s.Country.Update(objC);
                MsgThenRedirectTo("Data Deleted Successfully", "ManageCountry");
                bindData();
            }
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

