using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownListMethods
/// </summary>
public static class CommonDropDownListMethods
{
    public static string Message;
    
    #region Country DropDown
    public static void FillCountryDropDown(DropDownList ddl, SqlInt32 UserId)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_Country_SelectForDropDownListUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            if (UserId.ToString() != null)
                objCmd.Parameters.AddWithValue("@UserID", UserId);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Create Command and Set Parameters

            if (objSDR.HasRows)
            {
                ddl.DataSource = objSDR;
                ddl.DataValueField = "CountryID";
                ddl.DataTextField = "CountryName";
                ddl.DataBind();
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

            ddl.Items.Insert(0, new ListItem("Select Country", "-1"));
        }
        catch (Exception ex)
        {
            Message = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion Country DropDown

    #region State DropDown
    public static void FillStateDropDown(DropDownList ddl, SqlInt32 UserId, SqlInt32? CountryId)
    {
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

            if (CountryId != null)
            {
                
                objCmd.CommandText = "PR_State_SelectByCountryIDUserID";
                if (CountryId != null)
                    objCmd.Parameters.AddWithValue("@CountryID", CountryId);
            }
            else
            {
                objCmd.CommandText = "PR_State_SelectForDropDownListUserID";
            }

            if (UserId.ToString() != null)
                objCmd.Parameters.AddWithValue("@UserID", UserId);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Create Command and Set Parameters

            if (objSDR.HasRows)
            {
                ddl.DataSource = objSDR;
                ddl.DataValueField = "StateID";
                ddl.DataTextField = "StateName";
                ddl.DataBind();
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

            ddl.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        catch (Exception ex)
        {
            Message = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion State DropDown

    #region City DropDown
    public static void FillCityDropDown(DropDownList ddl, SqlInt32 UserId, SqlInt32? StateId)
    {
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

            if (StateId != null)
            {
                objCmd.CommandText = "PR_City_SelectByStateIDUserID";
                if (StateId != null)
                    objCmd.Parameters.AddWithValue("@StateID", StateId);
            }
            else
            {
                objCmd.CommandText = "PR_City_SelectForDropDownListUserID";
            }

            if (UserId.ToString() != null)
                objCmd.Parameters.AddWithValue("@UserID", UserId);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Create Command and Set Parameters

            if (objSDR.HasRows)
            {
                ddl.DataSource = objSDR;
                ddl.DataValueField = "CityID";
                ddl.DataTextField = "CityName";
                ddl.DataBind();
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        catch (Exception ex)
        {
            Message = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion City DropDown 

    #region Contact Category CheckBox
    public static void FillContactCategoryCheckBox(CheckBoxList chk, SqlInt32 UserId)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Bind Data
            SqlCommand objCmd = new SqlCommand("PR_ContactCategory_SelectForDropDownListUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            if (UserId.ToString() != null)
                objCmd.Parameters.AddWithValue("@UserID", UserId);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                chk.DataSource = objSDR;
                chk.DataValueField = "ContactCategoryID";
                chk.DataTextField = "ContactCategoryName";
                chk.DataBind();
            }
            #endregion Create Command and Bind Data

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            Message = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion Contact Category CheckBox
}