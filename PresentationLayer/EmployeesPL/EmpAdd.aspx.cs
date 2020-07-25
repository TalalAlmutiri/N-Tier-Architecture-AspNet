using BussinessLogicLayer;
using DataAccessLayer;
using SharedClassess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer.EmployeesPL
{
    public partial class EmpAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlCountries.DataSource = CountryDAL.GetAllCountry();
                    ddlCountries.DataBind();
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = "error";
                AppLogger.WriteLog(ex.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // You can add validation rules here or in the EmployeeBLL class
                if (EmployeeBLL.Add(txtFirstName.Value,txtLastName.Value, Convert.ToInt32(txtAge.Value),Convert.ToInt32(ddlCountries.SelectedValue)))
                {
                    lbMsg.Text = "The new employee was inserted successfully";
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = "error";
                AppLogger.WriteLog(ex.ToString());
            }
        }
    }
}