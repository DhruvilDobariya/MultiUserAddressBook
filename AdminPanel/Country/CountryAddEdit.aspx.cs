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


namespace MultiUserAddressBook.AdminPanel.Country
{
    public partial class CountryAddEdit : System.Web.UI.Page
    {
        #region PageLode
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CountryID"] != null)
                {
                    btnSubmit.Text = "Edit";
                    lblTitle.Text = "Edit Country";
                    FillControlls(Convert.ToInt32(Request.QueryString["CountryID"]));
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
                #endregion Create Command and Set Parameters

                if (Request.QueryString["CountryID"] != null)
                {
                    #region Update record
                    objCmd.CommandText = "PR_Country_UpdateByPK";
                    objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(Request.QueryString["CountryID"]));
                    objCmd.ExecuteNonQuery();
                    Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
                    #endregion Update record
                }
                else
                {
                    #region Add record
                    objCmd.CommandText = "PR_Country_Insert";
                    objCmd.ExecuteNonQuery();
                    lblMsg.Text = "Country Added Successfully";
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
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint 'IX_Country'. Cannot insert duplicate key in object 'dbo.Country'."))
                {
                    lblMsg.Text = "Country alrady exist!";
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
                SqlCommand objCmd = new SqlCommand("PR_Country_SelectByPK", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@CountryID", Id);
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
}