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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillContactCategoryCheckBoxList();
            FillCountryDropDown();
            if (Request.QueryString["ContactID"] != null)
            {
                lblTitle.Text = "Edit Contact";
                btnSubmit.Text = "Edit";
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
                FillStateForDropDown();
                FillCityForDropDown();
            }
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
                cblContactCategory.DataSource = objSDR;
                cblContactCategory.DataValueField = "ContactCategoryID";
                cblContactCategory.DataTextField = "ContactCategoryName";
                cblContactCategory.DataBind();
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

        SqlInt32 ContactID = SqlInt32.Null;
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
        SqlString strFilePath = SqlString.Null;

        bool flag = false;
        int i = 1;
        string temp = "";
        #endregion Local Variable
        #region Server side validaton
        /* Using Dictionary
        IDictionary<TextBox, Label> textBoxValidation = new Dictionary<TextBox, Label>()
        {
            {txtContact, lblContact },
            {txtContactNo, lblContactNo },
            {txtEmail, lblEmail},
            {txtAddress, lblAddress }
        };
        IDictionary<DropDownList, Label> dropDownListValidation = new Dictionary<DropDownList, Label>() 
        {
            {ddContactCategory, lblContactCategory },
            {ddCity, lblCity },
            {ddState, lblState },
            {ddCountry, lblCountry }
        };
        foreach(KeyValuePair<TextBox, Label> pair in textBoxValidation)
        {   
            if(pair.Key.Text == "")
            {
                flag = true;
                temp += i + ") " + pair.Value.Text + "</br>"; 
            }
            i++;
        }
        foreach (KeyValuePair<DropDownList, Label> pair in dropDownListValidation)
        {
            if (pair.Key.SelectedValue == "-1")
            {
                flag = true;
                temp += i + ") " + pair.Value.Text + "</br>";
            }
            i++;
        }
        if (flag)
        {
            lblMsg.Text = "</br> Please : </br>" + temp;
            return;
        }*/
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


            if (Request.QueryString["ContactID"] != null)
            {
                #region Update record
                objCmd.CommandText = "PR_Contact_UpdateByPKUserID";
                objCmd.Parameters.AddWithValue("@ContactID", Convert.ToInt32(Request.QueryString["ContactID"]));
                objCmd.ExecuteNonQuery();
                UploadImage(Convert.ToInt32(Request.QueryString["ContactID"]));
                DeleteContactCategory(Convert.ToInt32(Request.QueryString["ContactID"]));
                AddContactCategory(Convert.ToInt32(Request.QueryString["ContactID"]));
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx");
                #endregion Update record
            }
            else
            {
                #region Add record
                objCmd.CommandText = "PR_Contact_InsertUserID";
                objCmd.Parameters.AddWithValue("@FilePath", strFilePath);
                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                objCmd.ExecuteNonQuery();
                ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
                UploadImage(ContactID);
                AddContactCategory(ContactID);
                //lblMsg.Text = "Contact Added Successfully";
                ClearControls();
                #endregion Add record
            }

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
    #region Fill Controlls
    private void FillControls(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_Contact_SelectByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Create Command and Set Parameters

            #region Get data and set data
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContact.Text = objSDR["ContactName"].ToString();
                    }
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddCity.SelectedValue = objSDR["CityID"].ToString();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddState.SelectedValue = objSDR["StateID"].ToString();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddCountry.SelectedValue = objSDR["CountryID"].ToString();
                    }
                    if (!objSDR["ContactNo"].Equals(DBNull.Value))
                    {
                        txtContactNo.Text = objSDR["ContactNo"].ToString();
                    }
                    if (!objSDR["WhatsappNo"].Equals(DBNull.Value))
                    {
                        txtWhatsappNo.Text = objSDR["WhatsappNo"].ToString();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {
                        DateTime bd = Convert.ToDateTime(objSDR["BirthDate"]);
                        txtBirthDate.Text = bd.ToShortDateString();
                        //txtBirthDate.Text = bd.ToString("mm-dd-yyyy");
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString();
                    }
                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString();
                    }
                    if (!objSDR["FacebookID"].Equals(DBNull.Value))
                    {
                        txtFecebook.Text = objSDR["FacebookID"].ToString();
                    }
                    if (!objSDR["LinkedinID"].Equals(DBNull.Value))
                    {
                        txtLinkedin.Text = objSDR["LinkedinID"].ToString();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString();
                    }
                    break;
                }
            }
            else
            {
                lblMsg.Text = "Contact Not Found!";
            }
            #endregion Get data and set data

            FillContactCategoryCheckBoxs(Id);


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

    #region Fill State When Change Country 
    protected void ddState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddState.SelectedValue != "-1")
        {
            ddCity.Items.Clear();
            FillCityForDropDown();
        }
        else
        {
            ddCity.Items.Clear();
        }
    }
    #endregion Fill State When Change Country

    #region Fill City When Change State
    protected void ddCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddCountry.SelectedValue != "-1")
        {
            ddState.Items.Clear();
            FillStateForDropDown();
        }
        else
        {
            ddState.Items.Clear();
        }
    }
    #endregion Fill City When Change State

    #region Clear Controls
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
        cblContactCategory.ClearSelection();
    }
    #endregion Clear Controls

    #region Upload Image
    private void UploadImage(SqlInt32 Id)
    {
        SqlString strFilePath = SqlString.Null;

        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection
        try
        {


            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            strFilePath = "~/UserContent/" + Id + ".jpg";
            SqlCommand objCmd = new SqlCommand("PR_Contact_UpdateImagePathByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", Id);
            objCmd.Parameters.AddWithValue("@FilePath", strFilePath);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));

            objCmd.ExecuteNonQuery();

            if (!Directory.Exists(Server.MapPath("~/UserContent/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/UserContent/"));
            }
            fuFile.SaveAs(Server.MapPath("~/UserContent/" + Id + ".jpg"));

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
    #endregion Upload Image

    #region Add Contact Category
    private void AddContactCategory(SqlInt32 Id)
    {

        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection
        try
        {


            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            foreach (ListItem item in cblContactCategory.Items)
            {
                if (item.Selected)
                {
                    SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_InsertUserID", objConn);
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(item.Value));
                    if (Session["UserID"] != null)
                        objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    objCmd.Parameters.AddWithValue("@ContactID", Id);
                    objCmd.ExecuteNonQuery();
                }
            }
            lblMsg.Text = "Contact Added Successfully";
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
    #endregion Add Contact Category

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

            SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_DeleteByContactIDUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactId", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();
            lblMsg.Text = "Contact Deleted Successfully!";
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
    #endregion Delete Contact Category

    #region Fill Contact Category CheckBoxs
    private void FillContactCategoryCheckBoxs(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection
        try
        {


            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand("PR_ContactCategory_SelectOrNot", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.Parameters.AddWithValue("@ContactID", Id);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if(objSDR["SelectOrNot"].ToString() == "Selected")
                    {
                        cblContactCategory.Items.FindByValue(objSDR["ContactCategoryID"].ToString()).Selected = true;
                    }
                    
                }
            }
           

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
    #endregion Fill Contact Category CheckBoxs
}