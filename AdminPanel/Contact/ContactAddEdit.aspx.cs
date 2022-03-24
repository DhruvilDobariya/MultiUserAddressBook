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
            if (RouteData.Values["ContactID"] != null)
            {
                lblTitle.Text = "Edit Contact";
                btnSubmit.Text = "Edit";
                FillControls(Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["ContactID"].ToString())));
                FillStateForDropDown();
                FillCityForDropDown();
            }
        }
    }
    #endregion Page Load
    #region Fill Contact Category CheckBoxList
    private void FillContactCategoryCheckBoxList()
    {
        CommonDropDownListMethods.FillContactCategoryCheckBox(chkContactCategory, Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill Contact Category CheckBoxList
    #region Fill City DropDown
    private void FillCityForDropDown()
    {
        CommonDropDownListMethods.FillCityDropDown(ddlCity, Convert.ToInt32(Session["UserID"]), Convert.ToInt32(ddlState.SelectedValue));
    }
    #endregion Fill City DropDown
    #region Fill State DropDown
    private void FillStateForDropDown()
    {
        CommonDropDownListMethods.FillStateDropDown(ddlState, Convert.ToInt32(Session["UserID"]), Convert.ToInt32(ddlCountry.SelectedValue));
    }
    #endregion Fill State DropDown
    #region Fill Country DropDown
    private void FillCountryDropDown()
    {
        CommonDropDownListMethods.FillCountryDropDown(ddlCountry, Convert.ToInt32(Session["UserID"]));
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
        if (ddlCity.SelectedValue == "-1")
        {
            temp += "<li>" + lblCity.Text.Trim() + "</li>";
            flag = true;
        }
        if (ddlState.SelectedValue == "-1")
        {
            temp += "<li>" + lblState.Text.Trim() + "</li>";
            flag = true;
        }
        if (ddlCountry.SelectedValue == "-1")
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
        if (chkContactCategory.SelectedValue == "")
        {
            temp += "<li>Select at least Contact Category</li>";
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

        if (ddlCity.SelectedValue != "-1")
            strCityID = Convert.ToInt32(ddlCity.SelectedValue);

        if (ddlState.SelectedValue != "-1")
            strStateID = Convert.ToInt32(ddlState.SelectedValue);

        if (ddlCountry.SelectedValue != "-1")
            strCountryID = Convert.ToInt32(ddlCountry.SelectedValue);

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


            if (EncryptionDecryption.Decode(RouteData.Values["ContactID"].ToString()) != null)
            {
                #region Update record
                objCmd.CommandText = "PR_Contact_UpdateByPKUserID";
                objCmd.Parameters.AddWithValue("@ContactID", Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["ContactID"].ToString())));
                objCmd.ExecuteNonQuery();
                string FileType = Path.GetExtension(fuFile.FileName).ToLower();
                if (fuFile.HasFile)
                {
                    if (FileType == ".jpge" || FileType == ".jpg" || FileType == ".png" || FileType == ".gif")
                    {
                        UploadImage(Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["ContactID"].ToString())), "Image");
                    }
                    else
                    {
                        Session["Error"] = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                        return;
                    }
                }
                DeleteContactCategory(Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["ContactID"].ToString())));
                AddContactCategory(Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["ContactID"].ToString())));
                Session["Success"] = "Contact updated successfully";
                Response.Redirect("~/AdminPanel/Contact/List");
                #endregion Update record
            }
            else
            {
                #region Add record
                objCmd.CommandText = "PR_Contact_InsertUserID";
                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                objCmd.ExecuteNonQuery();
                ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
                string FileType = Path.GetExtension(fuFile.FileName).ToLower();
                if (fuFile.HasFile)
                {
                    if (FileType == ".jpge" || FileType == ".jpg" || FileType == ".png" || FileType == ".gif")
                    {
                        UploadImage(ContactID, "Image");
                    }
                    else
                    {
                        Session["Error"] = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                        return;
                    }
                }
                AddContactCategory(ContactID);
                Session["Success"] = "Contact added successfully";
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
                        ddlCity.SelectedValue = objSDR["CityID"].ToString();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlState.SelectedValue = objSDR["StateID"].ToString();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountry.SelectedValue = objSDR["CountryID"].ToString();
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
                        //txtBirthDate.Text = bd.ToShortDateString();
                        txtBirthDate.Text = bd.ToString("yyyy-MM-dd");
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
                    if (!objSDR["FilePath"].Equals(DBNull.Value))
                    {
                        imgImage.ImageUrl = objSDR["FilePath"].ToString();
                        imgImage.Visible = true;
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
        if (ddlState.SelectedValue != "-1")
        {
            ddlCity.Items.Clear();
            FillCityForDropDown();
        }
        else
        {
            ddlCity.Items.Clear();
        }
    }
    #endregion Fill State When Change Country

    #region Fill City When Change State
    protected void ddCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedValue != "-1")
        {
            ddlState.Items.Clear();
            FillStateForDropDown();
        }
        else
        {
            ddlState.Items.Clear();
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
        ddlCity.SelectedValue = "-1";
        ddlState.SelectedValue = "-1";
        ddlCountry.SelectedValue = "-1";
        chkContactCategory.ClearSelection();
    }
    #endregion Clear Controls

    #region Upload Image
    private void UploadImage(SqlInt32 Id, string FileExtention)
    {
        SqlString strFilePath = SqlString.Null;

        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
        #endregion Set Connection
        try
        {


            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Image Upload
            strFilePath = "~/UserContent/" + Id + ".jpg";
            if (!Directory.Exists(Server.MapPath("~/UserContent/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/UserContent/"));
            }
            fuFile.SaveAs(Server.MapPath("~/UserContent/" + Id + ".jpg"));
            long length = new FileInfo(Server.MapPath(strFilePath.ToString())).Length;
            #endregion Image Upload

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_Contact_UpdateImagePathByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", Id);
            objCmd.Parameters.AddWithValue("@FilePath", strFilePath);
            objCmd.Parameters.AddWithValue("@FileType", Convert.ToString(FileExtention));
            objCmd.Parameters.AddWithValue("@FileSize", Convert.ToString(length));
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));

            objCmd.ExecuteNonQuery();
            #endregion Create Command and Set Parameters

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

            foreach (ListItem item in chkContactCategory.Items)
            {
                if (item.Selected)
                {
                    #region Create Command and Set Parameter
                    SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_InsertUserID", objConn);
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(item.Value));
                    if (Session["UserID"] != null)
                        objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    objCmd.Parameters.AddWithValue("@ContactID", Id);
                    objCmd.ExecuteNonQuery();
                    #endregion Create Command and Set Parameter
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

            #region Create Command and Set Parameter
            SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_DeleteByContactIDUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactId", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();
            #endregion Create Command and Set Parameter

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
                        chkContactCategory.Items.FindByValue(objSDR["ContactCategoryID"].ToString()).Selected = true;
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