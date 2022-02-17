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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    #region PageLode
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillState();
        }
    }
    #endregion PageLode
    #region FillState
    private void FillState()
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
            objCmd.CommandText = "PR_State_SelectAllUserID";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            SqlDataReader objSDR = objCmd.ExecuteReader();
            gvState.DataSource = objSDR;
            gvState.DataBind();
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
    #endregion FillState 
    #region GridViewRowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString()));
                FillState();
            }
        }
    }
    #endregion GridViewRowCommand
    #region DeleteState
    private void DeleteState(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_State_DeleteByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@StateID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();
            lblMsg.Text = "State Deleted Successfully!";
            #endregion Create Command and Set Parameters

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            {
                lblMsg.Text = "This State contain some records, So please delete these record, If you want to delete this state.";
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
    #endregion DeleteState
}