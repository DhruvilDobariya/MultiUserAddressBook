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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region PageLode
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (RouteData.Values["CountryID"] != null)
            {
                btnSubmit.Text = "Edit";
                lblTitle.Text = "Edit Country";
                FillControlls(Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["CountryID"].ToString())));
            }
        }
    }
    #endregion PageLode
    #region SubmimForm
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region Local variable
        SqlString CountryName = SqlString.Null;
        SqlString CountryCode = SqlString.Null; ;
        #endregion Local variable
        #region Server side validation
        if (txtCountry.Text.Trim() == "" && txtCode.Text.Trim() == "")
        {
            lblMsg.Text = "Please enter Country Name and Country Code";
            return;
        }
        else if (txtCountry.Text.Trim() == "")
        {
            lblMsg.Text = "Please enter Country Name";
            return;
        }
        else if (txtCode.Text.Trim() == "")
        {
            lblMsg.Text = "Please enter Country Code";
            return;
        }

        if (txtCountry.Text.Trim() != "")
            CountryName = txtCountry.Text.Trim();
        if (txtCode.Text.Trim() != "")
            CountryCode = txtCode.Text.Trim();
        #endregion Server side validation
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@CountryName", CountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", CountryCode);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            #endregion Create Command and Set Parameters

            if (EncryptionDecryption.Decode(RouteData.Values["CountryID"].ToString()) != null)
            {
                #region Update record
                objCmd.CommandText = "PR_Country_UpdateByPKUserID";
                objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["CountryID"].ToString())));
                objCmd.ExecuteNonQuery();
                Session["Success"] = "Country updated successfully";
                Response.Redirect("~/AdminPanel/Country/List");
                #endregion Update record
            }
            else
            {
                #region Add record
                objCmd.CommandText = "PR_Country_InsertUserID";
                objCmd.ExecuteNonQuery();
                Session["Success"] = "Country added successfully";
                txtCountry.Text = "";
                txtCode.Text = "";
                txtCountry.Focus();
                #endregion Add record
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Violation of UNIQUE KEY constraint 'UK_Country_CountryName_UserID'. Cannot insert duplicate key in object 'dbo.Country'."))
            {
                Session["Error"] = "Country alrady exist!";
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
    #endregion SubmitForm
    #region FillControlls
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
            SqlCommand objCmd = new SqlCommand("PR_Country_SelectByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Create Command and Set Parameters
            #region Get data and set data
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountry.Text = objSDR["CountryName"].ToString();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCode.Text = objSDR["CountryCode"].ToString();
                    }
                    break;
                }
            }
            else
            {
                lblMsg.Text = "Country Not Found!";
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
    #endregion FillControlls
}