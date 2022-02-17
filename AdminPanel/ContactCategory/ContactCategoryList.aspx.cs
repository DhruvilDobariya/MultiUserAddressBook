using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Configuration;

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
{
    #region Page Lode
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillContactCategory();
        }
    }
    #endregion Page Lode
    #region Fill Contact Category
    private void FillContactCategory()
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
            objCmd.CommandText = "PR_ContactCategory_SelectAllUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvContactCategory.DataSource = objSDR;
            gvContactCategory.DataBind();
            #endregion Create Command and Bind Data

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
    #endregion Fill Contact Category
    #region GridView RowCommand
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString()));
                FillContactCategory();
            }
        }
    }
    #endregion GridView RowCommand
    #region Delete Contact Category
    private void DeleteContactCategory(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_ContactCategory_DeleteByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactCategoryId", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();
            lblMsg.Text = "Contact Category Deleted Successfully!";
            #endregion Create Command and Set Parameters

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            {
                lblMsg.Text = "This Contact Category contain some records, So please delete these record, If you want to delete this Contact Category.";
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
    #endregion Delete Contact Category
}