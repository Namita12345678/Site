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
    public partial class ManageCity : System.Web.UI.Page
    {
        //Utils u = new Utils();
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
            List<CitySubModel> CL = s.City.getCityActiveSubModel().OrderByDescending(c => c.St.StateId).ToList();
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




            Tbl_City CL = new Tbl_City();
            if (!chkisdisplay.Checked)
            {
                CL.Isdisplay = false;
            }
            else
            {
                CL.Isdisplay = true;
            }

            CL.StateId = Convert.ToInt32(drpstate.SelectedValue);
            CL.CityName = txtcityname.Text;
            CL.Isactive = true;

            if (lblid.Text != null && lblid.Text != "")
            {
                CL.CityId = Convert.ToInt32(lblid.Text);
                Tbl_City CLS = s.City.Update(CL);
                MsgThenRedirectTo("Data Updated Successfully", "ManageCity");
            }
            else
            {

                Tbl_City CLS = s.City.Add(CL);
               MsgThenRedirectTo("Data Inserted Successfully", "ManageCity");
            }
        }



        protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Tbl_City al = s.City.Get(Convert.ToInt32(e.CommandArgument));
                txtcityname.Text = al.CityName;
                bindCountry();

                Tbl_State Sl = s.State.Get().Where(q => q.Isactive == true && q.Isdisplay == true && q.StateId == al.StateId).SingleOrDefault();
                if (Sl != null)
                {
                    drpcountry.SelectedValue = Sl.CountryId.ToString();
                    bindState(Convert.ToInt32(Sl.CountryId));
                }

                drpstate.SelectedValue = al.StateId.ToString();

                lblid.Text = al.CityId.ToString();
                //lnlPanel.Text = "- Hide Add City";
                //DivAdd.Visible = true;
                if (al.Isdisplay != true)
                {
                    chkisdisplay.Checked = false;
                }
                else
                {
                    chkisdisplay.Checked = true;
                }
                chkisdisplay.Checked = (bool)al.Isdisplay;
            }
            if (e.CommandName == "Delete")
            {
                Tbl_City objA = new Tbl_City();
                objA.CityId = Convert.ToInt32(e.CommandArgument);
                Tbl_City objC = s.City.Get(objA.CityId);
                objC.Isactive = false;
                s.City.Delete(objC);
                MsgThenRedirectTo("Data Deleted Successfully", "ManageCity");
                //bindData();
            }
        }

        protected void Drpcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindState(Convert.ToInt32(drpcountry.SelectedValue));
        }


        void bindState(int countryid)
        {
            drpstate.Items.Clear();
            List<Tbl_State> LstState = s.State.Get().Where(q => q.Isactive == true && q.Isdisplay == true &&  q.CountryId == countryid).OrderByDescending(c => c.StateName).ToList();
            if (LstState.Count > 0)
            {
                drpstate.DataSource = LstState;
                drpstate.DataTextField = "StateName";
                drpstate.DataValueField = "StateId";
                drpstate.DataBind();
                drpstate.Items.Insert(0, new ListItem("-- Select State --", "0"));
            }
            else
            {
                drpstate.Items.Insert(0, new ListItem("-- Select State --", "0"));
            }
        }

       void MsgThenRedirectTo(string message, string pageName)
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