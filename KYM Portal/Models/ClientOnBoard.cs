using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KYM_Portal.Models
{
    public class ClientOnBoard
    {
        public String docNo { get; set; }
        public String customer_type { get; set; }
        public String cust_category { get; set; }
        public String business_type { get; set; }
        public String Id_Type { get; set; }
        public String id_passport { get; set; }
        public String pinNo { get; set; }
        public String title { get; set; }
        public String firstName { get; set; }
        public String middleName { get; set; }
        public String lastName { get; set; }
        public String countryOfResidence { get; set; }
        public String nationality { get; set; }
        public String DOB { get; set; }
        public String gender { get; set; }
        public String countyCode { get; set; }
        public String county { get; set; }
        public String maritalStatus { get; set; }
        public String hudumaNo { get; set; }
        public String mpesaNo { get; set; }

        //Contact and Communication Details
        public String tel_mobileNo { get; set; }
        public String tel_mobileNo2 { get; set; }
        public String email { get; set; }
        public String postCode { get; set; }
        public String address { get; set; }
        public String city { get; set; }
        public String facebook { get; set; }
        public String twitter { get; set; }
        public String linkedIn { get; set; }
        public String googlePlus { get; set; }
        public String status { get; set; }
        public string policyType { get; set; }
        public string filename { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public List<ClientOnBoardList> list { get; set; }

        //additional fields for corporate onboarding
        public String cert_of_incorporation_no { get; set; }
        public String nature_of_business { get; set; }
        public String office_location { get; set; }
        public String building { get; set; }
        public String bank_acc_no { get; set; }
        public String bank_name { get; set; }
        public String company_name { get; set; }

        // policy details
        public String applicant_type { get; set; }
        public String product { get; set; }
        public String insurer { get; set; }
        public String servicePeriod { get; set; }
        public String invoicePeriod { get; set; }
        public String memberTYpe { get; set; }
        public String DHB { get; set; }
        public String DHB_Premium { get; set; }
        public String total_Premium { get; set; }
        public String payment_mode { get; set; }
        public String payment_code { get; set; }
        public String financier { get; set; }
        public String financier_names { get; set; }
        public String agent_detail { get; set; }
        public String agent_salespersoncode{ get; set; }
        public bool suspend { get; set; }
        public DateTime suspend_to_date { get; set; }

        // dependants
        public string dependantcode { get; set; }
        public string name { get; set; }
        public string relationship { get; set; }
        public string  idNumber { get; set; }
        public string age { get; set; }
        public string dependantType { get; set; }
        public string premium { get; set; }
        public string allocation { get; set; }

        public List<Beneficiary> beneficiaries { get; set; }
        public List<Dependant> dependants { get; set; }



    }

    public class Beneficiary
    {
        public String docNo { get; set; }
        public int id { get; set; }
        public String beneficiary { get; set; }
        public string dependantcode { get; set; }
        public string name { get; set; }
        public string relationship { get; set; }
        public string idNumber { get; set; }
        public string age { get; set; }
        public string dependantType { get; set; }
        public string premium { get; set; }
        public string DOB { get; set; }
        public string allocation { get; set; }

    }
    public class Dependant
    {
        public String docNo { get; set; }
        public int id { get; set; }
        public string dependantcode { get; set; }
        public string name { get; set; }
        public string relationship { get; set; }
        public string idNumber { get; set; }
        public string age { get; set; }
        public string dependantType { get; set; }
        public string dhcb { get; set; }
        public string premium { get; set; }
        public string DOB { get; set; }
        public string allocation { get; set; }

    }
    public class ClientOnBoardList
    {
        public String docNo { get; set; }
        public String customer_type { get; set; }
        public String cust_category { get; set; }
        public String business_type { get; set; }
        public String Id_Type { get; set; }
        public String id_passport { get; set; }
        public String pinNo { get; set; }
        public String title { get; set; }
        public String firstName { get; set; }
        public String middleName { get; set; }
        public String lastName { get; set; }
        public String countryOfResidence { get; set; }
        public String nationality { get; set; }
        public String DOB { get; set; }
        public String gender { get; set; }
        public String countyCode { get; set; }
        public String county { get; set; }
        public String maritalStatus { get; set; }
        public String hudumaNo { get; set; }
        public String mpesaNo { get; set; }

        //Contact and Communication Details
        public String tel_mobileNo { get; set; }
        public String tel_mobileNo2 { get; set; }
        public String email { get; set; }
        public String postCode { get; set; }
        public String address { get; set; }
        public String city { get; set; }
        public String facebook { get; set; }
        public String twitter { get; set; }
        public String linkedIn { get; set; }
        public String googlePlus { get; set; }
        public String status { get; set; }
        public string policyType { get; set; }
        public string filename { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        //additional fields for corporate onboarding
        public String cert_of_incorporation_no { get; set; }
        public String nature_of_business { get; set; }
        public String office_location { get; set; }
        public String building { get; set; }
        public String bank_acc_no { get; set; }
        public String bank_name { get; set; }
        public String company_name { get; set; }


        // policy details
        public String applicant_type { get; set; }
        public String product { get; set; }
        public String insurer { get; set; }
        public String servicePeriod { get; set; }
        public String invoicePeriod { get; set; }
        public String memberTYpe { get; set; }
        public String DHB { get; set; }
        public String DHB_Premium { get; set; }
        public String total_Premium { get; set; }
        public String payment_mode { get; set; }
        public String payment_code { get; set; }
        public String financier { get; set; }
        public String financier_names { get; set; }
        public String agent_detail { get; set; }
        public String agent_salespersoncode { get; set; }
        public bool suspend { get; set; }
        public DateTime suspend_to_date { get; set; }

        public string dependantcode { get; set; }
        public string name { get; set; }
        public string relationship { get; set; }
        public string idNumber { get; set; }
        public string age { get; set; }
        public string dependantType { get; set; }
        public string premium { get; set; }
        public string allocation { get; set; }

        public List<Beneficiary> beneficiaries { get; set; }
        public List<Dependant> dependants { get; set; }
    }
    public class PostCodes
    {
        public string Code { get; set; }
        public string City { get; set; }
    }

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Product
    {
        public string No { get; set; }
        public string Description { get; set; }
    }

    public class ClaimNotification {
        public string docNo { get; set; }
        public string customerNo { get; set; }
        public string employeeNo { get; set; }
        public string policyNo { get; set; }
        public string claimAgainst { get; set; }
        public string dependantNo { get; set; }
        public string dateOfReporting { get; set; }
        public string claimCategory { get; set; }
        public string dateofAccident { get; set; }
        public string placeOfOccurenceTypes { get; set; }
        public string placeOfOccurence { get; set; }
        public string customerCategory { get; set; }
        public string status { get; set; }
        public List<ClaimNotificationLines> list { get; set; }
    }

    public class ClaimNotificationLines
    {
        public string docNo { get; set; }
        public string customerNo { get; set; }
        public string employeeNo { get; set; }
        public string policyNo { get; set; }
        public string claimAgainst { get; set; }
        public string dependantNo { get; set; }
        public string dateOfReporting { get; set; }
        public string claimCategory { get; set; }
        public string dateofAccident { get; set; }
        public string placeOfOccurenceTypes { get; set; }
        public string placeOfOccurence { get; set; }
        public string customerCategory { get; set; }
        public string status { get; set; }
    }

    public class Customer
    {
        public string No { get; set; }
        public string Name { get; set; }
    }
}
