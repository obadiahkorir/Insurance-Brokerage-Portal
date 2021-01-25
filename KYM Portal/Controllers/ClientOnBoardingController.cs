using KYM_Portal.Models;
using KYM_Portal.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KYM_Portal.Controllers
{
    public class ClientOnBoardingController : Controller
    {
        Common common = new Common();
        // GET: ClientOnBoarding
        public ActionResult Index()
        {
            if(Session["empNo"] == null)
            {
                TempData["error"] = "Your session has expired";
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        public ActionResult NewGlobalClientApplications( string id)
        {
            if (Session["empNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var query = common.nav.CustomerCategory.ToList();
            var list = new SelectList(query, "Code", "Description");

            ViewBag.List = list;

            var list2 = new SelectList(new[]
        {
                new { ID = "0", Name = "Micro-Insurance" },
                new { ID = "1", Name = "General" },
                new { ID = "2", Name = "Life" },
            },
        "ID", "Name", 0);

            ViewBag.List2 = list2;

            var list3 = new SelectList(new[]
             {
                new { ID = "0", Name = "ID" },
                new { ID = "1", Name = "Passport" },
            },
      "ID", "Name", 0);

            ViewBag.List3 = list3;

            var list4 = new SelectList(new[]
            {
                new { ID = "0", Name = "Male" },
                new { ID = "1", Name = "Female" },
            },
          "ID", "Name", 0);

            ViewBag.List4 = list4;

            var list5 = new SelectList(new[]
            {
                new { ID = "0", Name = "Major" },
                new { ID = "1", Name = "Captain" },
                new { ID = "2", Name = "Sir" },
                new { ID = "3", Name = "Madam" },
                new { ID = "4", Name = "Doctor" },
                new { ID = "5", Name = "Prof" },
                new { ID = "6", Name = "Pastor" },
                new { ID = "7", Name = "Hon" },
            },
          "ID", "Name", 0);

            ViewBag.List5 = list5;

            var list6 = new SelectList(new[]
            {
                new { ID = "0", Name = "Married" },
                new { ID = "1", Name = "Single" },
            },
         "ID", "Name", 0);

            ViewBag.List6 = list6;
            var list9 = new SelectList(new[]
            {
                new { ID = "0", Name = "Individual" },
                new { ID = "1", Name = "Corporate" },
            },
         "ID", "Name", 0);
         ViewBag.List10 = list9;

            var list11 = new SelectList(new[]
            {
                new { ID = "0", Name = "New" },
                new { ID = "1", Name = "Existing" },
            },
            "ID", "Name", 0);
            ViewBag.List11 = list11;

            var list12 = new SelectList(new[]
           {
                new { ID = "0", Name = "KTDA check Off" },
                new { ID = "1", Name = "KTDA Bonus" },
                new { ID = "2", Name = "Mpesa" },
                new { ID = "3", Name = "Other" },
                new { ID = "4", Name = "Corporate Checkoff" },

            },
           "ID", "Name", 0);
            ViewBag.List12 = list12;

            var list13 = new SelectList(new[]
         {
                new { ID = "0", Name = "Self" },
                new { ID = "1", Name = "Agent" },

            },
         "ID", "Name", 0);
            ViewBag.List13 = list13;

            var list15 = new SelectList(new[]
           {
                new { ID = "0", Name = "Month" },
                new { ID = "1", Name = "Two Months" },
                new { ID = "2", Name = "Quarter" },
                new { ID = "3", Name = "Half Year" },
                new { ID = "4", Name = "Year" },
                new { ID = "5", Name = "None" },

            },
        "ID", "Name", 0);
            ViewBag.List15 = list15;

            var list17 = new SelectList(new[]
          {
                new { ID = "0", Name = "KTDA Subsidiary" },
                new { ID = "1", Name = "Factory Staff" },
                new { ID = "2", Name = "Factory Director" },
                new { ID = "3", Name = "Board Member" },
                new { ID = "4", Name = "KTDA Farmer" },
                new { ID = "5", Name = "Farmer Dependant" },
                new { ID = "6", Name = "NON Tea-Individual" },
                new { ID = "7", Name = "NON Tea-Corporate" },

            },
       "ID", "Name", 0);
            ViewBag.List17 = list17;

            var list20 = new SelectList(new[]
         {
                new { ID = "0", Name = "Spouse" },
                new { ID = "1", Name = "Father" },
                new { ID = "2", Name = "Mother" },
                new { ID = "3", Name = "Daughter" },
                new { ID = "4", Name = "Son" },
                new { ID = "5", Name = "Brother" },
                new { ID = "6", Name = "Sister" },
                new { ID = "7", Name = "Trust Fund" },
                new { ID = "8", Name = "Aunt" },
                new { ID = "9", Name = "Uncle" },
                new { ID = "10", Name = "Grand Mother" },
                new { ID = "11", Name = "Grand Father" },
                new { ID = "12", Name = "Guardian" },
                new { ID = "13", Name = "Sponsor" },
                new { ID = "14", Name = "Nephew" },
                new { ID = "15", Name = "Niece" },

            },
      "ID", "Name", 0);
            ViewBag.List20 = list20;

            var list21 = new SelectList(new[]
       {
                new { ID = "0", Name = "Adult" },
                new { ID = "1", Name = "Child" },

            },
       "ID", "Name", 0);
            ViewBag.List21 = list21;


            var salesPeople = common.nav.Salespeople_Purchasers.ToList();
            SelectList salesList = new SelectList(salesPeople, "Code", "Name");
            ViewBag.List16 = salesList;




            ClientOnBoard client = new ClientOnBoard();

            List<PostCodes> clist = new List<PostCodes>();
            var countries = common.nav.Countries;

            foreach (var item in countries)
            {
                PostCodes code = new PostCodes();
                code.Code = item.Code;
                code.City = item.Code + " : " + item.Name;
                clist.Add(code);
            }

            SelectList lst = new SelectList(clist, "Code", "City");
            ViewBag.List7 = lst;

            //ViewBag.List3
            List<PostCodes> plist = new List<PostCodes>();
            var postCodes = common.nav.postcodes;

            foreach (var item in postCodes)
            {
                PostCodes codes = new PostCodes();
                codes.Code = item.Code;
                codes.City = item.Code + " " + item.City;
                plist.Add(codes);
            }
            SelectList postList = new SelectList(plist, "Code", "City");
            ViewBag.List8 = postList;
            List<PostCodes> ctyCodes = new List<PostCodes>();

            var countyCode = common.nav.DimensionValueList.Where(x=>x.Dimension_Code== "COUNTIES");
            foreach (var item in countyCode)
            {
                PostCodes codes = new PostCodes();
                codes.Code = item.Code;
                codes.City = item.Code + " " + item.Name;
                ctyCodes.Add(codes);
            }
            SelectList ctyList = new SelectList(ctyCodes, "Code", "City");
            ViewBag.List9 = ctyList;

            var reqNo = "";

            if(id !=null)
            {
                reqNo = id;
                Session["appNo"] = reqNo;
            }
            else  if(Session["appNo"] != null)
            {
                reqNo = Session["appNo"].ToString();
            }

            
            List<ClientOnBoardList> clientList = new List<ClientOnBoardList>();
            try
            {
                var result = common.nav.ClientApplicationQuery.Where(x => x.No == reqNo && x.Requestor == Convert.ToString(Session["empNo"])).ToList();
                foreach (var item in result)
                {
                    ClientOnBoardList board = new ClientOnBoardList();
                    client.customer_type = board.customer_type = item.Customer_Type;
                    client.cust_category = board.cust_category = item.Customer_Category;
                    client.business_type = board.business_type = item.Business_Type;
                    client.Id_Type = board.Id_Type = item.ID_Type;
                    client.id_passport = board.id_passport = item.ID_No_Passport_No;
                    client.pinNo = board.pinNo = item.PIN_No;
                    client.title = board.title = item.Title;
                    client.firstName = board.firstName = item.First_Name;
                    client.middleName = board.middleName = item.Middle_Name;
                    client.lastName = board.lastName = item.Last_Name;
                    client.countryOfResidence = board.countryOfResidence = item.Country_Region_Code;
                    client.nationality = board.nationality = item.Nationality;
                    client.DOB = board.DOB = Convert.ToDateTime(item.Date_of_Birth).ToShortDateString();
                    client.gender = board.gender = item.Gender;
                    client.countyCode = board.countyCode = item.County_Code;
                    client.county = board.county = item.County;
                    client.maritalStatus = board.maritalStatus = item.Marital_Status;
                    client.hudumaNo = board.hudumaNo = item.Huduma_No;
                    client.mpesaNo = board.mpesaNo = item.Mpesa_No;
                    client.tel_mobileNo = board.tel_mobileNo = item.Tel_Mobile_No;
                    client.tel_mobileNo2 = board.tel_mobileNo2 = item.Tel_Mobile_No_2;
                    client.email = board.email = item.E_Mail;
                    client.postCode = board.postCode = item.Post_Code;
                    client.address = board.address = item.Address;
                    client.city = board.city = item.City;
                    client.facebook = board.facebook = item.Facebook;
                    client.twitter = board.twitter = item.Twitter;
                    client.linkedIn = board.linkedIn = item.LinkedIn;
                    client.googlePlus = board.googlePlus = item.Google;
                    client.policyType = board.policyType = item.Policy_Type;
                    client.product = board.product = item.Product;
                    client.insurer = board.insurer = item.Insurer;
                    client.payment_code = board.payment_code = item.Payment_Code;
                    client.servicePeriod = board.servicePeriod = item.Service_Period;
                    client.financier = board.financier = item.Financier;
                    client.financier_names = board.financier_names = item.Financier_Names;
                    client.invoicePeriod = board.invoicePeriod = item.Invoice_Period;
                    client.memberTYpe = board.memberTYpe = item.Member_Type;
                    client.agent_detail = board.agent_detail = item.Agent_Detail;
                    client.DHB = board.DHB = item.DHB;
                    client.DHB_Premium = board.DHB_Premium = item.DHB_Premium.ToString();
                    client.agent_salespersoncode = board.agent_salespersoncode = item.Agent_Salespersons_Code;
                    client.suspend = board.suspend = Convert.ToBoolean( item.Suspend);
                    client.suspend_to_date = board.suspend_to_date = Convert.ToDateTime( item.Suspend_to_Date);
                    client.applicant_type = board.applicant_type = item.Type_of_Applicant;

                    if (client.agent_detail == "Self")
                    {
                        client.agent_detail = "0";
                    }
                    else
                    {
                        client.agent_detail = "1";

                    }

                    if (client.memberTYpe == "New")
                    {
                        client.memberTYpe = "0";
                    }
                    else
                    {
                        client.memberTYpe = "1";

                    }
                    

                    if (client.invoicePeriod == "Month")
                    {
                        client.invoicePeriod = "0";
                    }
                    else if (client.invoicePeriod == "Two Months")
                    {
                             client.invoicePeriod = "1";
                    }
                    else if (client.invoicePeriod == "Quarter")
                    {
                        client.invoicePeriod = "2";
                    }
                    else if (client.invoicePeriod == "Half Year")
                    {
                        client.invoicePeriod = "3";
                    }
                    else if (client.invoicePeriod == "Year")
                    {
                        client.invoicePeriod = "4";
                    }
                    else if (client.invoicePeriod == "None")
                    {
                        client.invoicePeriod = "5";
                    }



                    if (client.applicant_type == "KTDA Subsidiary")
                    {
                        client.applicant_type = "0";

                    }else if(client.applicant_type == "Factory Staff")
                    {
                        client.applicant_type = "1";
                    }
                    else if (client.applicant_type == "Factory Director")
                    {
                        client.applicant_type = "2";
                    }
                    else if (client.applicant_type == "Board Member")
                    {
                        client.applicant_type = "3";
                    }
                    else if (client.applicant_type == "KTDA Farmer")
                    {
                        client.applicant_type = "4";
                    }
                    else if (client.applicant_type == "Farmer Dependant")
                    {
                        client.applicant_type = "5";
                    }
                    else if (client.applicant_type == "NON Tea-Individual")
                    {
                        client.applicant_type = "6";
                    }
                    else if (client.applicant_type == "NON Tea-Corporate")
                    {
                        client.applicant_type = "7";
                    }


                    if (board.customer_type == "Individual")
                    {
                        client.customer_type = "0";
                    }
                    else
                    {
                        client.customer_type = "1";
                    }

                    if (board.maritalStatus == "Married")
                    {
                        client.maritalStatus = "0";
                    }
                    else
                    {
                        client.maritalStatus = "1";
                    }

                    if (client.title == "Major")
                    {
                        client.title = "0";
                    }
                    else if (client.title == "Captain")
                    {
                        client.title = "1";
                    }
                    else if (client.title == "Sir")
                    {
                        client.title = "2";
                    }
                    else if (client.title == "Madam")
                    {
                        client.title = "3";
                    }
                    else if (client.title == "Doctor")
                    {
                        client.title = "4";
                    }
                    else if (client.title == "Prof")
                    {
                        client.title = "5";
                    }
                    else if (client.title == "Pastor")
                    {
                        client.title = "6";
                    }
                    else
                    {
                        client.title = "7";
                    }


                    if (board.gender == "Male")
                    {
                        client.gender = "0";
                    }
                    else
                    {
                        client.Id_Type = "1";
                    }

                    if (board.Id_Type == "ID")
                    {
                        client.Id_Type = "0";
                    }
                    else
                    {
                        board.Id_Type = "1";
                    }

                    if (board.business_type == "Micro-Insurance")
                    {
                        client.business_type = "0";
                    }
                    else if (board.business_type == "General")
                    {
                        client.business_type = "1";
                    }
                    else
                    {
                        client.business_type = "2";
                    }

                    if (board.cust_category == "KTDA")
                    {
                        client.cust_category = "0";
                    }
                    else
                    {
                        client.cust_category = "1";
                    }
                    
                    clientList.Add(board);
                    client.list = clientList;
                }

                var dhbquery = common.nav.MedicalSchedules.Where(x => x.Product_Code == client.product).ToList();
                SelectList dhbList = new SelectList(dhbquery, "Benefit_Limit", "Benefit_Limit");
                ViewBag.List22 = dhbList;


                List<Dependant> dependantList = new List<Dependant>();
                var dQuery = common.nav.DependantQuery.Where(x => x.Client_App_No == reqNo).ToList();
                foreach(var item in dQuery)
                {
                    Dependant dependant = new Dependant();
                    dependant.id = item.Line_No;
                    dependant.docNo = item.Client_App_No;
                    dependant.dependantcode = item.Dependant_Code;
                    dependant.name = item.Name;
                    dependant.relationship = item.Relationship;
                    dependant.DOB = Convert.ToDateTime( item.Date_Of_Birth).ToShortDateString();
                    dependant.idNumber = item.ID_No;
                    dependant.age = item.Age.ToString();
                    dependant.dependantType = item.Depandant_Type;
                    dependant.dhcb = item.DHB;
                    dependant.premium = item.Premium.ToString();
                    dependantList.Add(dependant);
                }
                client.dependants = dependantList;

                List<Beneficiary> beneficiaryList = new List<Beneficiary>();
                var benQuery = common.nav.BeneficiariesQuery.Where(x => x.Client_App_No == reqNo).ToList();
                foreach(var item in benQuery)
                {
                    Beneficiary beneficiary = new Beneficiary();
                    beneficiary.id = item.Line_No;
                    beneficiary.beneficiary = item.Beneficiary;
                    beneficiary.name = item.Name;
                    beneficiary.relationship = item.Relationship;
                    beneficiary.DOB = Convert.ToDateTime(item.Date_Of_Birth).ToShortDateString();
                    beneficiary.idNumber = item.ID_No;
                    beneficiary.age = item.Age.ToString();
                    beneficiary.allocation = item.Allocation.ToString();
                    beneficiaryList.Add(beneficiary);

                }
                client.beneficiaries = beneficiaryList;


            var productList = common.nav.ProductList.Where(x => x.Policy_Type == client.policyType && x.Insurance_Item_type == "Insurance").ToList();
                List<Product> prlist = new List<Product>();
                foreach (var item in productList)
                {
                    Product pr = new Product();
                    pr.No = item.No;
                    pr.Description = item.No + " " + item.Description + " " + item.Insurer;
                    prlist.Add(pr);
                }
                SelectList productList1 = new SelectList(prlist, "No", "Description");

                ViewBag.List14 = productList1;

               List< Product> prodlist = new List<Product>();
                var financier = common.nav.KTDAFARMERS.ToList();
                foreach(var item in financier)
                {
                    Product prod = new Product();
                    prod.No = item.Grower_No;
                    prod.Description = item.Grower_No +" " +item.Name;
                    prodlist.Add(prod);
                }
                SelectList financierList = new SelectList(prodlist, "No", "Description");
                ViewBag.List18 = financierList;

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewGlobalClientApplications(ClientOnBoard model)
        {
            if (Session["empNo"] == null)
            {
                TempData["error"] = "Your session has expired";
                return RedirectToAction("Login", "Home");
            }
            int step = 1;

            if(model.facebook == null)
            {
                model.facebook = "";
            }
            if (model.twitter == null)
            {
                model.twitter = "";
            }
            if (model.linkedIn == null)
            {
                model.linkedIn = "";
            }
            if (model.googlePlus == null)
            {
                model.googlePlus = "";
            }

            if (model.lastName == null)
            {
                model.lastName = "";
            }
            if(model.tel_mobileNo2 == null)
            {
                model.tel_mobileNo2 = "";
            }
            var appNo = "";
            String requisitionNo = "";
            Boolean newRequisition = false;
            try
            {
                if(Session["appNo"] != null)
                {

                    requisitionNo = Session["appNo"].ToString();
                }
                if (String.IsNullOrEmpty(requisitionNo))
                {
                    requisitionNo = "";
                    newRequisition = true;
                }
            }
            catch (Exception)
            {
                newRequisition = true;
                requisitionNo = "";
            }

            try
            {
                var requestor = Session["empNo"].ToString();
                var status = Common.ObjNav.NewClientOnboadingRequests(requisitionNo, requestor, model.cust_category, Convert.ToInt32(model.business_type),model.policyType, Convert.ToInt32(model.Id_Type), model.id_passport,
                       model.pinNo, Convert.ToInt32(model.title), model.firstName, model.middleName, model.lastName, model.countryOfResidence,
                       model.nationality, Convert.ToDateTime(model.DOB), Convert.ToInt32(model.gender), model.countyCode, model.county, Convert.ToInt32(model.maritalStatus), model.hudumaNo,
                       model.mpesaNo, model.tel_mobileNo, model.tel_mobileNo2, model.email, model.postCode, model.address,
                       model.city, model.facebook, model.twitter, model.linkedIn, model.googlePlus
                       );

                String[] info = status.Split('*');

                if (info[0] == "success")
                {
                    if (newRequisition == true)
                    {
                        requisitionNo = info[2];
                        Session["appNo"] = requisitionNo;
                    }
                    return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step = 2, appNo = requisitionNo });
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }



            return View();
        }

        [HttpGet]
        public ActionResult CorporateClientApplications(string id)
        {
            if (Session["empNo"] == null)
            {
                TempData["error"] = "Your session has expired";
                return RedirectToAction("Login", "Home");
            }
            
            var query = common.nav.CustomerCategory.ToList();
            var list = new SelectList(query, "Code", "Description");


            ViewBag.List = list;

            var list2 = new SelectList(new[]
        {
                new { ID = "0", Name = "Micro-Insurance" },
                new { ID = "1", Name = "General" },
                new { ID = "2", Name = "Life" },
            },
        "ID", "Name", 0);

            ViewBag.List2 = list2;

            
            ClientOnBoard client = new ClientOnBoard();

            List<PostCodes> clist = new List<PostCodes>();
            var countries = common.nav.Countries;

            foreach (var item in countries)
            {
                PostCodes code = new PostCodes();
                code.Code = item.Code;
                code.City = item.Code + " : " + item.Name;
                clist.Add(code);
            }

            SelectList lst = new SelectList(clist, "Code", "City");
            ViewBag.List7 = lst;

            //ViewBag.List3
            List<PostCodes> plist = new List<PostCodes>();
            var postCodes = common.nav.postcodes;

            foreach (var item in postCodes)
            {
                PostCodes codes = new PostCodes();
                codes.Code = item.Code;
                codes.City = item.Code + " " + item.City;
                plist.Add(codes);
            }
            SelectList postList = new SelectList(plist, "Code", "City");
            ViewBag.List8 = postList;
            List<PostCodes> ctyCodes = new List<PostCodes>();

            var countyCode = common.nav.DimensionValueList.Where(x => x.Dimension_Code == "COUNTIES");
            foreach (var item in countyCode)
            {
                PostCodes codes = new PostCodes();
                codes.Code = item.Code;
                codes.City = item.Code + " " + item.Name;
                ctyCodes.Add(codes);
            }
            SelectList ctyList = new SelectList(ctyCodes, "Code", "City");
            ViewBag.List9 = ctyList;

            var reqNo = "";

            if (id != null)
            {
                reqNo = id;
                Session["appNo"] = reqNo;
            }
            else if (Session["appNo"] != null)
            {
                reqNo = Session["appNo"].ToString();
            }


            List<ClientOnBoardList> clientList = new List<ClientOnBoardList>();
            try
            {
                var result = common.nav.ClientApplicationQuery.Where(x => x.No == reqNo && x.Requestor == Convert.ToString(Session["empNo"])).ToList();
                foreach (var item in result)
                {
                    ClientOnBoardList board = new ClientOnBoardList();
                    client.customer_type = board.customer_type = item.Customer_Type;
                    client.cust_category = board.cust_category = item.Customer_Category;
                    client.business_type = board.business_type = item.Business_Type;
                    client.Id_Type = board.Id_Type = item.ID_Type;
                    client.id_passport = board.id_passport = item.ID_No_Passport_No;
                    client.pinNo = board.pinNo = item.PIN_No;
                    client.countryOfResidence = board.countryOfResidence = item.Country_Region_Code;
                    client.countyCode = board.countyCode = item.County_Code;
                    client.county = board.county = item.County;
                    client.hudumaNo = board.hudumaNo = item.Huduma_No;
                    client.mpesaNo = board.mpesaNo = item.Mpesa_No;
                    client.tel_mobileNo = board.tel_mobileNo = item.Tel_Mobile_No;
                    client.tel_mobileNo2 = board.tel_mobileNo2 = item.Tel_Mobile_No_2;
                    client.email = board.email = item.E_Mail;
                    client.postCode = board.postCode = item.Post_Code;
                    client.address = board.address = item.Address;
                    client.city = board.city = item.City;
                    client.facebook = board.facebook = item.Facebook;
                    client.twitter = board.twitter = item.Twitter;
                    client.linkedIn = board.linkedIn = item.LinkedIn;
                    client.googlePlus = board.googlePlus = item.Google;

                    client.cert_of_incorporation_no = board.cert_of_incorporation_no = item.Cert_of_Incorporation_No;
                    client.nature_of_business = board.nature_of_business = item.Nature_of_Business_Sector;
                    client.office_location = board.office_location = item.Office_Location;
                    client.building = board.building = item.Building;
                    client.bank_acc_no = board.bank_acc_no = item.Bank_A_C_No;
                    client.bank_name = board.bank_name = item.Bank_Name;
                    client.company_name = board.company_name = item.Company_Name;


                    if (board.business_type == "Micro-Insurance")
                    {
                        client.business_type = "0";
                    }
                    else if (board.business_type == "General")
                    {
                        client.business_type = "1";
                    }
                    else
                    {
                        client.business_type = "2";
                    }

                    if (board.cust_category == "KTDA")
                    {
                        client.cust_category = "0";
                    }
                    else
                    {
                        client.cust_category = "1";
                    }



                    clientList.Add(board);
                    client.list = clientList;
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CorporateClientApplications(ClientOnBoard model)
        {
            if (Session["empNo"] == null)
            {
                TempData["error"] = "Your session has expired";
                return RedirectToAction("Login", "Home");
            }
            int step = 1;

            if (model.facebook == null)
            {
                model.facebook = "";
            }
            if (model.twitter == null)
            {
                model.twitter = "";
            }
            if (model.linkedIn == null)
            {
                model.linkedIn = "";
            }
            if (model.googlePlus == null)
            {
                model.googlePlus = "";
            }
            var appNo = "";
            String requisitionNo = "";
            Boolean newRequisition = false;
            try
            {
                if (Session["appNo"] != null)
                {

                    requisitionNo = Session["appNo"].ToString();
                }
                if (String.IsNullOrEmpty(requisitionNo))
                {
                    requisitionNo = "";
                    newRequisition = true;
                }
            }
            catch (Exception)
            {
                newRequisition = true;
                requisitionNo = "";
            }
            try
            {
                var requestor = Session["empNo"].ToString();
                var status = Common.ObjNav.NewCorporateClientOnboadingRequests(
                    requisitionNo, requestor, model.cust_category, Convert.ToInt32(model.business_type),
                       model.pinNo,model.countryOfResidence,model.countyCode, model.cert_of_incorporation_no,model.nature_of_business,model.office_location,
                       model.building,model.bank_acc_no,model.bank_name,model.company_name,
                       model.mpesaNo, model.tel_mobileNo, model.tel_mobileNo2, model.email, model.postCode, model.address,
                       model.city, model.facebook, model.twitter, model.linkedIn, model.googlePlus);

                String[] info = status.Split('*');

                if (info[0] == "success")
                {
                    if (newRequisition == true)
                    {
                        requisitionNo = info[2];
                        Session["appNo"] = requisitionNo;
                    }
                    return RedirectToAction("CorporateClientApplications", "ClientOnBoarding", new { step = 2, appNo = requisitionNo });
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }


            return View();
        }


        public ActionResult IndividualClientUnderwriting()
        {

            return View();
        }

        [HttpGet]
        public ActionResult CreateClaimNotification( string id)
        {
            Session["claimNo"] = id;
            
            ClaimNotification notification = new ClaimNotification();
            List<ClaimNotificationLines> nList = new List<ClaimNotificationLines>();
            var claimNotificaton = common.nav.InsuranceClaims.Where(x => x.No == id).ToList();
            foreach(var item in claimNotificaton)
            {
                ClaimNotificationLines model = new ClaimNotificationLines();

                model.customerNo =  notification.customerNo = item.Customer_No;
                model.policyNo = notification.policyNo = item.Policy_No;
                model.claimAgainst = notification.claimAgainst = item.Claiming_Against;
                model.dependantNo = notification.dependantNo = item.Dependent_No;
                model.claimCategory = notification.claimCategory = item.Claim_Category;
                model.dateofAccident = notification.dateofAccident = Convert.ToDateTime( item.Date_of_Accident_Loss_Death).ToShortDateString();
                model.placeOfOccurenceTypes = notification.placeOfOccurenceTypes = item.Place_of_Occurrence_Types;
                model.placeOfOccurence = notification.placeOfOccurence = item.Place_of_Occurence;
                model.customerCategory = notification.customerCategory = item.Customer_Category;

                if(notification.placeOfOccurenceTypes== "Hospital")
                {
                    notification.placeOfOccurenceTypes = "0";

                }else if(notification.placeOfOccurenceTypes == "Home")
                {
                    notification.placeOfOccurenceTypes = "1";
                }
                else
                {
                    notification.placeOfOccurenceTypes = "2";
                }

                if(notification.claimCategory== "Medical")
                {
                    notification.claimCategory = "0";
                }
                else
                {
                    notification.claimCategory = "1";
                }

                if(notification.claimAgainst == "Principal")
                {
                    notification.claimAgainst = "0";

                }
                else
                {
                    notification.claimAgainst = "1";
                }

                nList.Add(model);

               notification.list = nList;

            }


           

            var requestor = "";
            if (Session["empNo"] == null)
            {
                TempData["error"] = "Your session has expired";
                return RedirectToAction("Login", "Home");
            }
            else
            {
                requestor = Session["empNo"].ToString();
            }
            var query = common.nav.CustomerCategory.ToList();
            var list4 = new SelectList(query, "Code", "Description");

            ViewBag.List4 = list4;

            var list1 = new SelectList(new[]
            {
                new { ID = "0", Name = "Principal" },
                new { ID = "1", Name = "Dependant" },
            },
         "ID", "Name", 0);

            ViewBag.List1 = list1;

            var list2 = new SelectList(new[]
           {
                new { ID = "0", Name = "Medical" },
                new { ID = "1", Name = "Death" },
            },
          "ID", "Name", 0);

            ViewBag.List2 = list2;

            var list3 = new SelectList(new[]
          {
                new { ID = "0", Name = "Hospital" },
                new { ID = "1", Name = "Home" },
                new { ID = "1", Name = "Other" },
            },
         "ID", "Name", 0);

            ViewBag.List3 = list3;




            var customers = common.nav.Customer.ToList();
            List<Customer> list = new List<Customer>();
            foreach(var item in customers)
            {
                Customer cust = new Customer();
                cust.No = item.No;
                cust.Name = item.No + " " + item.Name;
                list.Add(cust);
            }
            SelectList custList = new SelectList(list, "No", "Name");
            ViewBag.List = custList;
            return View(notification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClaimNotification(ClaimNotification model)
        {
            var customers = common.nav.Customer.ToList();
            List<Customer> list = new List<Customer>();
            foreach (var item in customers)
            {
                Customer cust = new Customer();
                cust.No = item.No;
                cust.Name = item.No + " " + item.Name;
                list.Add(cust);
            }
            SelectList custList = new SelectList(list, "No", "Name");
            ViewBag.List = custList;

            var query = common.nav.CustomerCategory.ToList();
            var list4 = new SelectList(query, "Code", "Description");

            ViewBag.List4 = list4;

            var list1 = new SelectList(new[]
            {
                new { ID = "0", Name = "Principal" },
                new { ID = "1", Name = "Dependant" },
            },
         "ID", "Name", 0);

            ViewBag.List1 = list1;

            var list2 = new SelectList(new[]
           {
                new { ID = "0", Name = "Medical" },
                new { ID = "1", Name = "Death" },
            },
          "ID", "Name", 0);

            ViewBag.List2 = list2;

            var list3 = new SelectList(new[]
          {
                new { ID = "0", Name = "Hospital" },
                new { ID = "1", Name = "Home" },
                new { ID = "1", Name = "Other" },
            },
         "ID", "Name", 0);

            ViewBag.List3 = list3;

            if (model.dependantNo == null)
            {
                model.dependantNo = "";

            }
            try
            {
                var requisitionNo = "";
                if(Session["claimNo"] != null)
                {
                    requisitionNo = Convert.ToString(Session["claimNo"]);
                }

              var  requestor = Session["empNo"].ToString();
                var status = Common.ObjNav.CreateClaimNotification(requisitionNo, model.customerNo, requestor, model.policyNo, Convert.ToInt32(model.claimAgainst), model.dependantNo,
                    Convert.ToInt32(model.claimCategory), Convert.ToDateTime(model.dateofAccident), Convert.ToInt32(model.placeOfOccurenceTypes), model.placeOfOccurence, model.customerCategory);
                string[] info = status.Split('*');
                if(info[0] == "success")
                {
                    TempData["success"] = info[1];
                    Session["docNo"] = info[2];
                    return RedirectToAction("CreateClaimNotification");
                }
                else
                {
                    TempData["error"] = info[1];
                    return RedirectToAction("CreateClaimNotification");
                }

            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            } 


            return View(model);
        }


        public ActionResult SendClaimNotificationForValidation()
        {
            
            var requisitionNo = "";
            if (Session["docNo"] != null)
            {
                requisitionNo = Session["docNo"].ToString();
            }
            else
            {
                requisitionNo = Convert.ToString(Session["claimNo"]);
            }
            try
            {
                var status = Common.ObjNav.PushClaimNotificationForValidation(requisitionNo);
                string[] info = status.Split('*');
                if (info[0] == "success")
                {
                    TempData["success"] = info[1];
                }
                else
                {
                    TempData["error"] = info[1];
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }


            return RedirectToAction("CreateClaimNotification", "ClientOnBoarding");

        }

        public ActionResult OpenClientOnBoardingRequests()
        {
            var requestor = "";
            if (Session["empNo"] == null)
            {
                TempData["error"] = "Your session has expired";
                return RedirectToAction("Login", "Home");
            }else
            {
                 requestor = Session["empNo"].ToString();
            }
            List<ClientOnBoard> clientList = new List<ClientOnBoard>();
            var result = common.nav.ClientApplicationQuery.Where(x => (x.Status =="Open" || x.Status== "Pending Approval") && x.Customer_Type== "Individual" && x.Requestor== requestor).ToList();
            foreach (var item in result)
            {
                ClientOnBoard board = new ClientOnBoard();
                board.docNo = item.No;
                board.customer_type = item.Customer_Type;
                board.business_type = item.Business_Type;
                board.id_passport = item.ID_No_Passport_No;
                board.nationality = item.Nationality;
                board.firstName = item.First_Name;
                board.middleName = item.Middle_Name;
                board.lastName = item.Last_Name;
                board.status = item.Status;
                clientList.Add(board);

            }

            var result1 = common.nav.ClientApplicationQuery.Where(x => (x.Status == "Open" || x.Status == "Pending Approval") && x.Customer_Type == "Corporate" && x.Requestor == requestor).ToList();
            foreach (var item in result1)
            {
                ClientOnBoard board = new ClientOnBoard();
                board.docNo = item.No;
                board.customer_type = item.Customer_Type;
                board.business_type = item.Business_Type;
                board.id_passport = item.ID_No_Passport_No;
                board.nationality = item.Nationality;
                board.firstName = item.First_Name;
                board.middleName = item.Middle_Name;
                board.lastName = item.Last_Name;
                board.status = item.Status;
                clientList.Add(board);

            }

            return View(clientList);
        }

        public ActionResult AddPolicy(ClientOnBoard model)
        {
            int step = 2;
            var appNo = "";
            if (Session["appNo"] != null)
            {

                appNo = Session["appNo"].ToString();
            }

            if(model.payment_code == null)
            {
                model.payment_code = "";
            }
            if (model.suspend_to_date == null)
            {
                model.suspend_to_date = Convert.ToDateTime( "01/01/0001");
            }


            try
            {
                var status = Common.ObjNav.UpdatePolicyDetails(
                    appNo,Convert.ToInt32( model.applicant_type), model.product, Convert.ToInt32(model.payment_mode), model.insurer,
                    model.payment_code, model.servicePeriod, model.financier, Convert.ToInt32(model.invoicePeriod), model.financier_names, Convert.ToInt32(model.memberTYpe),
                    Convert.ToInt32(model.agent_detail),model.DHB, model.agent_salespersoncode, Convert.ToDecimal( model.DHB_Premium), model.suspend, model.suspend_to_date
                                    );

                string[] info = status.Split('*');
                if(info[0] == "success")
                {
                    TempData["success"] = info[1];
                    return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo });
                }
                else
                {
                    TempData["error"] = info[1];
                    return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo });


                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }



            

            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step,appNo});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDependant(ClientOnBoard model)
        {
            int step = 3;
            var appNo = "";
            if (Session["appNo"] != null)
            {

                appNo = Session["appNo"].ToString();
            }
            try
            {
                var status = Common.ObjNav.CreateClientDependants(appNo, model.dependantcode, model.name, Convert.ToInt32(model.relationship), Convert.ToDateTime(model.DOB),
                             model.idNumber, Convert.ToDecimal(model.age), Convert.ToInt32(model.dependantType), model.DHB, Convert.ToDecimal(model.premium));
                string[] info = status.Split('*');
                if(info[0] == "success")
                {
                    TempData["error"] = info[1];
                    return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo });
                }
                else
                {
                    TempData["error"] = info[1];
                    return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
               
            }
            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBeneficiary(ClientOnBoard model)
        {
            int step = 3;
            var appNo = "";
            if (Session["appNo"] != null)
            {

                appNo = Session["appNo"].ToString();
            }
            try
            {
                var status = Common.ObjNav.CreateClientBeneficiary(appNo, model.dependantcode, model.name, Convert.ToInt32(model.relationship), Convert.ToDateTime(model.DOB),
                             model.idNumber, Convert.ToDecimal(model.age), Convert.ToInt32(model.allocation));
                string[] info = status.Split('*');
                if (info[0] == "success")
                {
                    TempData["error"] = info[1];
                    return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo });
                }
                else
                {
                    TempData["error"] = info[1];
                    return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;

            }
            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo });
        }

        [HttpGet]
        public ActionResult OpenClaimNotification()
        {
            var requestor = "";
            if (Session["empNo"] == null)
            {
                TempData["error"] = "Your session has expired";
                return RedirectToAction("Login", "Home");
            }
            else
            {
                requestor = Session["empNo"].ToString();
            }
            List<ClaimNotification> clist = new List<ClaimNotification>();
            try
            {

                var claim = common.nav.InsuranceClaims.Where(x => x.Requestor == requestor).ToList();
                foreach (var item in claim)
                {
                    ClaimNotification claimN = new ClaimNotification();
                    claimN.docNo = item.No;
                    claimN.customerNo = item.Customer_No;
                    claimN.policyNo = item.Policy_No;
                    claimN.dateOfReporting = Convert.ToDateTime(item.Date_of_Reporting).ToShortDateString();
                    claimN.dateofAccident = Convert.ToDateTime(item.Date_of_Accident_Loss_Death).ToShortDateString();
                    claimN.placeOfOccurenceTypes = item.Place_of_Occurrence_Types;
                    claimN.placeOfOccurence = item.Place_of_Occurence;
                    claimN.status = item.Claim_Status;
                    clist.Add(claimN);

                }


            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }


            return View(clist);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendForApproval()
        {
            var appNo = "";
            var requisitionNo = "";
            if (Session["appNo"] != null)
            {
                requisitionNo = Session["appNo"].ToString();
            }
            int step = 4;
            try
            {
                var status = Common.ObjNav.SendClientApplicationForApproval(requisitionNo);
                string[] info = status.Split('*');
                if(info[0] == "success")
                {
                    TempData["success"] = info[1];
                }
                else
                {
                    TempData["error"] = info[1];
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }


            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });
            
        }

        public ActionResult SendCorporateForApproval()
        {
            var appNo = "";
            var requisitionNo = "";
            if (Session["appNo"] != null)
            {
                requisitionNo = Session["appNo"].ToString();
            }
            int step = 2;
            try
            {
                var status = Common.ObjNav.SendClientApplicationForApproval(requisitionNo);
                string[] info = status.Split('*');
                if (info[0] == "success")
                {
                    TempData["success"] = info[1];
                }
                else
                {
                    TempData["error"] = info[1];
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }


            return RedirectToAction("CorporateClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });
        }
        public ActionResult GoStep1()
        {
            if (Session["empNo"] == null)
            {
                TempData["error"] = "Your session has expired";
                return RedirectToAction("Login", "Home");
            }
            var appNo = "";
            var requisitionNo = "";
            if (Session["appNo"] != null)
            {
                requisitionNo = Session["appNo"].ToString();
            }
            int step = 1;

            return RedirectToAction("CorporateClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });
        }
        public ActionResult GoBackStep1()
        {
            if (Session["empNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var appNo = "";
            var requisitionNo = "";
            if (Session["appNo"] != null)
            {
                requisitionNo = Session["appNo"].ToString();
            }
            int step = 1;

            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step,appNo=requisitionNo });
        }
        public ActionResult GoStep3()
        {
            if (Session["empNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var appNo = "";
            var requisitionNo = "";
            if (Session["appNo"] != null)
            {
                requisitionNo = Session["appNo"].ToString();
            }
            int step = 3;

            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });
        }

        public ActionResult GoStep4()
        {
            if (Session["empNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var appNo = "";
            var requisitionNo = "";
            if (Session["appNo"] != null)
            {
                requisitionNo = Session["appNo"].ToString();
            }
            int step = 4;

            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });
        }

        public ActionResult GoBackStep3()
        {
            if (Session["empNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var appNo = "";
            var requisitionNo = "";
            if (Session["appNo"] != null)
            {
                requisitionNo = Session["appNo"].ToString();
            }
            int step = 3;

            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });
        }
        public ActionResult GoBackStep2()
        {
            if (Session["empNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var appNo = "";
            var requisitionNo = "";
            if (Session["appNo"] != null)
            {
                requisitionNo = Session["appNo"].ToString();
            }
            int step = 2;

            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });
        }
        public JsonResult GetCities(string id)
        {
            //Code
            return Json(new SelectList(common.nav.postcodes.Where(x => (x.Code == id)), "City", "City"));
        }

        public JsonResult GetCountries(string id)
        {
            //Code
            return Json(new SelectList(common.nav.Countries.Where(x => (x.Code == id)), "Nationality", "Nationality"));
        }

        public JsonResult GetCounties(string id)
        {
            //Code
            return Json(new SelectList(common.nav.DimensionValueList.Where(x => (x.Code == id) && x.Dimension_Code == "COUNTIES"), "Name", "Name"));
        }

        public JsonResult GetDHB(string id)
        {
            //Code
            return Json(new SelectList(common.nav.MedicalSchedules.Where(x => (x.Product_Code == id) && x.Premium_TB_Options == "ADULT"), "Benefit_Limit", "Benefit_Limit"));
        }
        public JsonResult GetDHBPremium(string id)
        {
            var query = common.nav.MedicalSchedules.Where(x => x.Benefit_Limit == id);
            //Code
            //return Json(new SelectList(common.nav.MedicalSchedules.Where(x => (x.Benefit_Limit == id)), "Premium", "Premium"));
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInsurer(string id)
        {
            var query = common.nav.ProductList.Where(x => x.No == id);
            //Insurer,Service_Period
            //return Json(new SelectList(common.nav.MedicalSchedules.Where(x => (x.Benefit_Limit == id)), "Premium", "Premium"));
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFinancierName(string id)
        {
            var query = common.nav.KTDAFARMERS.Where(x => x.Grower_No == id);
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMemberPolicies(string id)
        {
            var query = common.nav.MemberPolicies.Where(x => x.Customer_No == id);
           // return Json(query, JsonRequestBehavior.AllowGet);
            return Json(new SelectList(common.nav.MemberPolicies.Where(x => (x.Customer_No == id)), "Contract_No", "Contract_No"));
        }
        public JsonResult GetDependants(string id)
        {
            var query = common.nav.ActualPolicyDependants.Where(x => x.Client_No == id);

            //return Json(query, JsonRequestBehavior.AllowGet);
             return Json(new SelectList(common.nav.ActualPolicyDependants.Where(x => (x.Client_No == id)), "Name", "Name"));
        }

        public JsonResult getPolicyTypes(string id)
        {
            
            ClientOnBoard board = new ClientOnBoard();
            if (id == "0")
            {
                board.policyType = "MICRO-INSURANCE";
            }
            if (id == "1")
            {
                board.policyType = "GENERAL";
            }
            if (id == "2")
            {
                board.policyType = "LIFE";
            }

            return Json(new SelectList(common.nav.PolicyTypes.Where(x => (x.Insurance_Category == board.policyType)), "Policy_Type_Code", "Policy_Type_Code"));




        }
        public ActionResult UploadDocuments(ClientOnBoard model)
        {
            if (Session["empNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int step = 2;
            var requisitionNo = "";
            if(Session["appNo"] != null)
            {
                requisitionNo = Session["appNo"].ToString();
            }
            string fileLocation = ConfigurationManager.AppSettings["FilesLocation"] + "Global Client Application/";
            
            if (model.ImageFile.ContentLength > 0)
            {
                try
                {
                    if (Directory.Exists(fileLocation))
                    {
                        String extension = System.IO.Path.GetExtension(model.ImageFile.FileName);
                        if (new Common().IsAllowedExtension(extension))
                        {
                            var docNo = Session["appNo"].ToString();
                            string directory = fileLocation + docNo + "/";
                            try
                            {
                                if (!Directory.Exists(directory))
                                {

                                    //createDirectory = false;
                                    Directory.CreateDirectory(directory);
                                    if (Directory.CreateDirectory(directory).Exists)
                                    {

                                        string fileName = directory + model.ImageFile.FileName;
                                        if (System.IO.File.Exists(fileName))
                                        {
                                            TempData["error"] = "The file already exist in the directory";

                                        }
                                        else
                                        {
                                            model.ImageFile.SaveAs(fileName);
                                            if (System.IO.File.Exists(fileName))
                                            {
                                                Common.navExtender.AddLinkToRecord("Global Client Application", docNo, fileName, "");
                                                TempData["success"] = "File uploaded successfully";


                                            }
                                            else
                                            {
                                                TempData["error"] = "The file could not be uploaded";
                                                return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });

                                            }


                                        }



                                    }
                                    else
                                    {
                                        TempData["error"] = "The directory does not exist";
                                    }
                                }
                                else
                                {
                                    string fileName = directory + model.ImageFile.FileName;

                                    if (System.IO.File.Exists(fileName))
                                    {
                                        TempData["error"] = "The file already exist in the directory";

                                    }
                                    else
                                    {
                                        model.ImageFile.SaveAs(fileName);
                                        if (System.IO.File.Exists(fileName))
                                        {
                                            Common.navExtender.AddLinkToRecord("Global Client Application", docNo, fileName, "");
                                            TempData["success"] = "File uploaded successfully";


                                        }
                                        else
                                        {
                                            TempData["error"] = "The file could not be uploaded";
                                            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });

                                        }
                                    }


                                }

                            }
                            catch (Exception ex)
                            {

                                TempData["error"] = ex.Message;
                            }
                        }
                        else
                        {
                            TempData["error"] = "The file extension is not acceptable.Please upload only .pdf document";
                        }
                        ///
                    }
                    else
                    {
                        TempData["error"] = "The directory does not exist";
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                TempData["error"] = "please upload a file";
            }

            return RedirectToAction("NewGlobalClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });
        }

        public ActionResult UploadCorporateDocuments(ClientOnBoard model)
        {
            if (Session["empNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int step = 2;
            var requisitionNo = "";
            if (Session["appNo"] != null)
            {
                requisitionNo = Session["appNo"].ToString();
            }
            string fileLocation = ConfigurationManager.AppSettings["FilesLocation"] + "Global Corporate Application/";

            if (model.ImageFile.ContentLength > 0)
            {
                try
                {
                    if (Directory.Exists(fileLocation))
                    {
                        String extension = System.IO.Path.GetExtension(model.ImageFile.FileName);
                        if (new Common().IsAllowedExtension(extension))
                        {
                            var docNo = Session["appNo"].ToString();
                            string directory = fileLocation + docNo + "/";
                            try
                            {
                                if (!Directory.Exists(directory))
                                {

                                    //createDirectory = false;
                                    Directory.CreateDirectory(directory);
                                    if (Directory.CreateDirectory(directory).Exists)
                                    {

                                        string fileName = directory + model.ImageFile.FileName;
                                        if (System.IO.File.Exists(fileName))
                                        {
                                            TempData["error"] = "The file already exist in the directory";

                                        }
                                        else
                                        {
                                            model.ImageFile.SaveAs(fileName);
                                            if (System.IO.File.Exists(fileName))
                                            {
                                                Common.navExtender.AddLinkToRecord("Global Corporate Application", docNo, fileName, "");
                                                TempData["success"] = "File uploaded successfully";


                                            }
                                            else
                                            {
                                                TempData["error"] = "The file could not be uploaded";
                                                return RedirectToAction("CorporateClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });

                                            }


                                        }



                                    }
                                    else
                                    {
                                        TempData["error"] = "The directory does not exist";
                                    }
                                }
                                else
                                {
                                    string fileName = directory + model.ImageFile.FileName;

                                    if (System.IO.File.Exists(fileName))
                                    {
                                        TempData["error"] = "The file already exist in the directory";

                                    }
                                    else
                                    {
                                        model.ImageFile.SaveAs(fileName);
                                        if (System.IO.File.Exists(fileName))
                                        {
                                            Common.navExtender.AddLinkToRecord("Global Corporate Application", docNo, fileName, "");
                                            TempData["success"] = "File uploaded successfully";


                                        }
                                        else
                                        {
                                            TempData["error"] = "The file could not be uploaded";
                                            return RedirectToAction("CorporateClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });

                                        }
                                    }


                                }

                            }
                            catch (Exception ex)
                            {

                                TempData["error"] = ex.Message;
                            }
                        }
                        else
                        {
                            TempData["error"] = "The file extension is not acceptable.Please upload only .pdf document";
                        }
                        ///
                    }
                    else
                    {
                        TempData["error"] = "The directory does not exist";
                    }
                }
                catch (Exception e)
                {

                    TempData["error"] = e.Message;
                }

            }
            else
            {
                TempData["error"] = "please upload a file";
            }

            return RedirectToAction("CorporateClientApplications", "ClientOnBoarding", new { step, appNo = requisitionNo });
        }


       
    }
}