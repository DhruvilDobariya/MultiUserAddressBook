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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillStateForDropDown();
            if (RouteData.Values["CityID"] != null)
            {
                lblTitle.Text = "Edit City";
                btnSubmit.Text = "Edit";
                FillControlls(Convert.ToInt32(RouteData.Values["CityID"]));
            }
        }
    }
    #endregion Page Load
    #region Fill State
    private void FillStateForDropDown()
    {
        CommonDropDownListMethods.FillStateDropDown(ddlState, Convert.ToInt32(Session["UserID"]),null);
    }
    #endregion Fill State
    #region Submit Form
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local variable
        SqlString strCityName = SqlString.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strPinCode = SqlString.Null;
        SqlString StrSTDCode = SqlString.Null;
        #endregion Local variable
        #region Server side validation
        if (txtCity.Text.Trim() == "" || ddlState.SelectedIndex == -1)
        {
            lblMsg.Text = "Please Enter City and Select State";
            return;
        }
        else if (txtCity.Text.Trim() == "")
        {
            lblMsg.Text = "Please Select State";
            return;
        }
        else if (ddlState.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select State";
            return;
        }
        #endregion Server side validation
        #region Set local variable
        if (txtCity.Text.Trim() != "")
            strCityName = txtCity.Text.Trim();
        if (ddlState.SelectedValue != "-1")
            strStateID = Convert.ToInt32(ddlState.SelectedValue);
        if (txtPin.Text.Trim() != "")
            strPinCode = txtPin.Text.Trim();
        if (txtPin.Text.Trim() != "")
            StrSTDCode = txtSTD.Text.Trim();
        #endregion Set local variable
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@PinCode", strPinCode);
            objCmd.Parameters.AddWithValue("@STDCode", StrSTDCode);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            #endregion Create Command and Set Parameters

            if (RouteData.Values["CityID"] != null)
            {
                #region Update record
                objCmd.CommandText = "PR_City_UpdateByPKUserID";
                objCmd.Parameters.AddWithValue("@CityID", Convert.ToString(RouteData.Values["CityID"]));
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/List");
                #endregion Update record
            }
            else
            {
                #region Add record
                objCmd.CommandText = "PR_City_InsertUserID";
                objCmd.ExecuteNonQuery();
                lblMsg.Text = "City Added Successfully";
                txtCity.Text = txtPin.Text = txtSTD.Text = "";
                ddlState.SelectedIndex = -1;
                #endregion Add record
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Violation of UNIQUE KEY constraint 'UK_City_CityName_UserID'. Cannot insert duplicate key in object 'dbo.City'."))
            {
                lblMsg.Text = "City alrady exist!";
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
    #endregion Submit Form
    #region Fill Controlls
    private void FillControlls(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_City_SelectByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CityID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Create Command and Set Parameters
            #region Get data and set data
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCity.Text = objSDR["CityName"].ToString();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTD.Text = objSDR["STDCode"].ToString();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPin.Text = objSDR["PinCode"].ToString();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlState.SelectedValue = objSDR["StateID"].ToString();
                    }
                    break;
                }
            }
            else
            {
                lblMsg.Text = "City Not Found!";
            }
            #endregion Get data and set data

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
    #endregion Fill Controlls
}