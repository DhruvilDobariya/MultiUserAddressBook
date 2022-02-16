using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MultiUserAddressBook.AdminPanel.ContactCategoryWiseContact
{
    public partial class ContactCategoryWiseContact : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                FillContactCategoryCheckBoxList();
                FillCountryDropDown();
            }
        }
        #endregion Page Load
        #region Fill Contact Category CheckBoxList
        private void FillContactCategoryCheckBoxList()
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
                if (Session["UserID"] != null)
                    objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                SqlDataReader objSDR = objCmd.ExecuteReader();
                if (objSDR.HasRows)
                {
                    chklContactCategory.DataSource = objSDR;
                    chklContactCategory.DataValueField = "ContactCategoryID";
                    chklContactCategory.DataTextField = "ContactCategoryName";
                    chklContactCategory.DataBind();
                }
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
        #endregion Fill Contact Category CheckBoxList
        #region Fill City DropDown
        private void FillCityForDropDown()
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Set Connection

            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                
                #region Create Command and Bind Data
                SqlCommand objCmd = new SqlCommand("PR_City_SelectByStateIDUserID", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                if (ddState.SelectedValue != "-1")
                    objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(ddState.SelectedValue));
                if (Session["UserID"] != null)
                    if (Session["UserID"] != null)
                        objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                SqlDataReader objSDR = objCmd.ExecuteReader();
                if (objSDR.HasRows)
                {
                    ddCity.DataSource = objSDR;
                    ddCity.DataValueField = "CityID";
                    ddCity.DataTextField = "CityName";
                    ddCity.DataBind();
                }
                ddCity.Items.Insert(0, new ListItem("Select City", "-1"));
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
        #endregion Fill City DropDown
        #region Fill State DropDown
        private void FillStateForDropDown()
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Set Connection

            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Bind Data
                SqlCommand objCmd = new SqlCommand("PR_State_SelectByCountryIDUserID", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                if (ddCountry.SelectedValue != "-1")
                    objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(ddCountry.SelectedValue));
                if (Session["UserID"] != null)
                    objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                SqlDataReader objSDR = objCmd.ExecuteReader();
                if (objSDR.HasRows)
                {
                    ddState.DataSource = objSDR;
                    ddState.DataValueField = "StateID";
                    ddState.DataTextField = "StateName";
                    ddState.DataBind();
                }
                ddState.Items.Insert(0, new ListItem("Select State", "-1"));
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
        #endregion Fill State DropDown
        #region Fill Country DropDown
        private void FillCountryDropDown()
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Set Connection

            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Bind Data
                SqlCommand objCmd = new SqlCommand("PR_Country_SelectForDropDownListUserID", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                if (Session["UserID"] != null)
                    objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    ddCountry.DataSource = objSDR;
                    ddCountry.DataValueField = "CountryID";
                    ddCountry.DataTextField = "CountryName";
                    ddCountry.DataBind();
                }

                ddCountry.Items.Insert(0, new ListItem("Select Country", "-1"));
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
        #endregion Fill Country DropDown
        #region Submit Form
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region Local Variable
            SqlString strContact = SqlString.Null;
            SqlInt32 strCityID = SqlInt32.Null;
            SqlInt32 strStateID = SqlInt32.Null;
            SqlInt32 strCountryID = SqlInt32.Null;
            SqlString strContactNo = SqlString.Null;
            SqlString strWhatsappNo = SqlString.Null;
            SqlDateTime strBirthDate = SqlDateTime.Null;
            SqlString strEmil = SqlString.Null;
            SqlInt32 strAge = SqlInt32.Null;
            SqlString strBloodGroup = SqlString.Null;
            SqlString strLinkedin = SqlString.Null;
            SqlString strFacebook = SqlString.Null;
            SqlString strAddress = SqlString.Null;

            bool flag = false;
            int i = 1;
            string temp = "";
            #endregion Local Variable
            #region Server side validaton
            
            if (txtContact.Text.Trim() == "")
            {
                temp += "<li>" + lblContact.Text.Trim() + "</li>";
                flag = true;
            }
            if (ddCity.SelectedValue == "-1")
            {
                temp += "<li>" + lblCity.Text.Trim() + "</li>";
                flag = true;
            }
            if (ddState.SelectedValue == "-1")
            {
                temp += "<li>" + lblState.Text.Trim() + "</li>";
                flag = true;
            }
            if (ddCountry.SelectedValue == "-1")
            {
                temp += "<li>" + lblCountry.Text.Trim() + "</li>";
                flag = true;
            }
            if (txtContactNo.Text.Trim() == "")
            {
                temp += "<li>" + lblContactNo.Text.Trim() + "</li>";
                flag = true;
            }
            if (txtEmail.Text.Trim() == "")
            {
                temp += "<li>" + lblEmail.Text.Trim() + "</li>";
                flag = true;
            }
            if (txtAddress.Text.Trim() == "")
            {
                temp += "<li>" + lblAddress.Text.Trim() + "</li>";
                flag = true;
            }

            if (flag)
            {
                lblMsg.Text = "<ul> Please : " + temp + "</ul>";
                return;
            }

            #endregion Server side validaton
            #region Set local variable
            if (txtContact.Text.Trim() != "")
                strContact = txtContact.Text.Trim();
            if (ddCity.SelectedValue != "-1")
                strCityID = Convert.ToInt32(ddCity.SelectedValue);
            if (ddState.SelectedValue != "-1")
                strStateID = Convert.ToInt32(ddState.SelectedValue);
            if (ddCountry.SelectedValue != "-1")
                strCountryID = Convert.ToInt32(ddCountry.SelectedValue);
            if (txtContactNo.Text.Trim() != "")
                strContactNo = txtContactNo.Text.Trim();
            if (txtWhatsappNo.Text.Trim() != "")
                strWhatsappNo = txtWhatsappNo.Text.Trim();
            if (txtBirthDate.Text.Trim() != "")
                strBirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
            if (txtEmail.Text.Trim() != "")
                strEmil = txtEmail.Text.Trim();
            if (txtAge.Text.Trim() != "")
                strAge = Convert.ToInt32(txtAge.Text.Trim());
            if (txtBloodGroup.Text.Trim() != "")
                strBloodGroup = txtBloodGroup.Text.Trim();
            if (txtFecebook.Text.Trim() != "")
                strFacebook = txtFecebook.Text.Trim();
            if (txtLinkedin.Text.Trim() != "")
                strLinkedin = txtLinkedin.Text.Trim();
            if (txtAddress.Text.Trim() != "")
                strAddress = txtAddress.Text.Trim();
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
                objCmd.Parameters.AddWithValue("@ContactName", strContact);
                objCmd.Parameters.AddWithValue("@CityID", strCityID);
                objCmd.Parameters.AddWithValue("@StateID", strStateID);
                objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
                objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
                objCmd.Parameters.AddWithValue("@WhatsappNo", strWhatsappNo);
                objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
                objCmd.Parameters.AddWithValue("@Email", strEmil);
                objCmd.Parameters.AddWithValue("@Age", strAge);
                objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
                objCmd.Parameters.AddWithValue("@FacebookID", strFacebook);
                objCmd.Parameters.AddWithValue("@LinkedInID", strLinkedin);
                objCmd.Parameters.AddWithValue("@Address", strAddress);
                if (Session["UserID"] != null)
                    objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                #endregion Create Command and Set Parameters


                #region Add record
                objCmd.CommandText = "PR_ContactWithMultipleContactCategory_InsertUserID";
                string Id = objCmd.ExecuteScalar().ToString();
                InsertContactWiseContactCategory(Id);
                
                ClearControls();
                #endregion Add record

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message + ex;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Submit Form

        private void InsertContactWiseContactCategory(string ContactID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                
                foreach (ListItem item in chklContactCategory.Items)
                {
                    if (item.Selected)
                    {
                        SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_InsertUserID", objConn);
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(item.Value));
                        if (Session["UserID"] != null)
                        objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        objCmd.Parameters.AddWithValue("@ContactID", Convert.ToInt32(ContactID));
                        objCmd.ExecuteNonQuery();

                    }
                }

                #endregion Create Command and Set Parameters

                lblMsg.Text = "Contact Added Successfully";
                
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        protected void ddState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddCity.Items.Clear();
            FillCityForDropDown();
        }

        protected void ddCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddState.Items.Clear();
            FillStateForDropDown();
        }

        private void ClearControls()
        {
            txtContact.Text = "";
            txtContactNo.Text = "";
            txtWhatsappNo.Text = "";
            txtBirthDate.Text = "";
            txtEmail.Text =
            txtAge.Text = "";
            txtBloodGroup.Text = "";
            txtFecebook.Text = "";
            txtLinkedin.Text = txtAddress.Text = "";
            ddCity.SelectedValue = "-1";
            ddState.SelectedValue = "-1";
            ddCountry.SelectedValue = "-1";
        }
    }
}