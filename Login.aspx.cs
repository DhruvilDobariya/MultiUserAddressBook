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

public partial class AdminPanel_Login : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Page Load

    #region Submit form
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        #region Local variable
        SqlString strUsername = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        #endregion Local variable
        #region Server side validation
        if (txtUserName.Text.Trim() == "" && txtPassword.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Username Password";
            return;
        }
        else if (txtUserName.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Username";
            return;
        }
        else if (txtPassword.Text.Trim() == "")
        {
            lblMsg.Text = "Please Enter Password";
            return;
        }
        #endregion Server side validation
        #region Set local variable
        if (txtUserName.Text.Trim() != "")
            strUsername = txtUserName.Text.Trim();
        if (txtPassword.Text.Trim() != "")
            strPassword = txtPassword.Text.Trim();
        #endregion Set local variable
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_User_SelectByUsernamePassword", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@UserName", strUsername);
            objCmd.Parameters.AddWithValue("@Password", strPassword);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Create Command and Set Parameters

            #region Get data and validate user
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["UserID"].Equals(DBNull.Value))
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    break;
                }
                Response.Redirect("~/AdminPanel/Home");
            }
            else
            {
                lblMsg.Text = "Username or Password Invalid!";
            }
            #endregion Get data and validate user

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Submit form
}