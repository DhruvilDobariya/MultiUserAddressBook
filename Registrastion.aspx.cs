using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiUserAddressBook
{
    public partial class Registrastion : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion Page Load
        #region Submit form
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region Local variable
            SqlString strDisplayName = SqlString.Null;
            SqlString strMobileNo = SqlString.Null;
            SqlString strAddress = SqlString.Null;
            SqlString strUserName = SqlString.Null;
            SqlString strPassword = SqlString.Null;
            #endregion Local variable
            #region Server side validation
            if(txtEmail.Text.Trim() == "" && txtName.Text.Trim() == "" && txtPassword.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Email, Name and Password";
                return;
            }
            else if (txtEmail.Text.Trim() == "" && txtName.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Email and Name";
                return;
            }
            else if (txtName.Text.Trim() == "" && txtPassword.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Name and Password";
                return;
            }
            else if (txtEmail.Text.Trim() == ""  && txtPassword.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Email and Password";
                return;
            }
            else if (txtEmail.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Email";
                return;
            }
            else if (txtName.Text.Trim() == "")
            {
                lblMsg.Text = "Please Enter Name";
                return;
            }
            else if (txtPassword.Text.Trim() == "")
            {
                lblMsg.Text = "Please Password";
                return;
            }
            #endregion Server side validation

            #region Set local variable
            if (txtEmail.Text.Trim() != "")
                strUserName = txtEmail.Text.Trim();
            if (txtName.Text.Trim() != "")
                strDisplayName = txtName.Text.Trim();
            if (txtPassword.Text.Trim() != "")
                strPassword = txtPassword.Text.Trim();
            if (txtAddress.Text.Trim() != "")
                strAddress = txtAddress.Text.Trim();
            if (txtMobileNo.Text.Trim() != "")
                strMobileNo = txtMobileNo.Text.Trim();
            #endregion Set local variable

            #region Set Connection
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Set Connection

            try
            {
                if(objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand("PR_User_Insert",objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@UserName", strUserName);
                objCmd.Parameters.AddWithValue("@Password", strPassword);
                objCmd.Parameters.AddWithValue("@DisplayName", strDisplayName);
                objCmd.Parameters.AddWithValue("@Address", strAddress);
                objCmd.Parameters.AddWithValue("@MobileNo", strMobileNo);
                objCmd.ExecuteNonQuery();
                #endregion Create Command and Set Parameters

                
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

                Response.Redirect("~/Login.aspx");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Cannot insert duplicate key row in object 'dbo.User' with unique index 'IX_User'"))
                {
                    lblMsg.Text = "This Username already exist";
                }
                else
                {
                    lblMsg.Text = ex.Message;
                }
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }

        }
        #endregion Submit form
    }
}