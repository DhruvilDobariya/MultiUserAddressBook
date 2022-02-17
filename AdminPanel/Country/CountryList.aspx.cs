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

public partial class AdminPanel_Country_Read : System.Web.UI.Page
{
    #region PageLode
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCountry();
        }
    }
    #endregion PageLode
    #region FillCountry
    private void FillCountry()
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Bind Data
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectAllUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvCountry.DataSource = objSDR;
            gvCountry.DataBind();
            #endregion Create Command and Bind Data

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillCountry
    #region GridViewRowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != "")
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString()));
                FillCountry();
            }
        }
    }
    #endregion GridViewRowCommand
    #region DeleteCountry
    private void DeleteCountry(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_Country_DeleteByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();
            #endregion Create Command and Set Parameters

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

            lblMsg.Text = "Country Deleted Successfully!";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            {
                lblMsg.Text = "This Country contain some records, So please delete these record, If you want to delete this country.";
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
    #endregion DeleteCountry
}