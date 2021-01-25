using System;
using System.Configuration;
using System.Net;
using KYM_Portal.ODATASERVICE;
using KYM_Portal.NavEXtender;
using KYM_Portal.KYMService;

namespace KYM_Portal.Utils
{
    public class Common
    {


        public readonly NAV nav = new ODATASERVICE.NAV(new Uri(ConfigurationManager.AppSettings["baseUrl"]))

        {

            Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Username"],
                   ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"])

        };






        public static KYM ObjNav
        {
            get
            {
                var ws = new KYM();

                try
                {
                    var credentials = new NetworkCredential(ConfigurationManager.AppSettings["Username"],
                        ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                    ws.Credentials = credentials;
                    ws.PreAuthenticate = true;
                    ws.Timeout = -1;
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
                return ws;
            }
        }


        public static NavXtender navExtender
        {
            get
            {
                var res = new NavXtender();
                try
                {
                    var credential = new NetworkCredential(ConfigurationManager.AppSettings["Username"],
                        ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);

                    res.Credentials = credential;
                    res.PreAuthenticate = true;

                }
                catch (Exception ex)
                {

                    ex.Data.Clear();
                }

                return res;
            }
        }

        public Boolean IsAllowedExtension(String extension)
        {
            Boolean check = Convert.ToBoolean(ConfigurationManager.AppSettings["CheckFileExtensions"]);
            if (check)
            {
                String allowedFileTypes = ConfigurationManager.AppSettings["AllowedFileExtensions"];
                String[] info = allowedFileTypes.Split(',');
                extension = extension.Replace(".", " ");
                extension = extension.Trim();
                extension = extension.ToLower();
                foreach (String fileExtension in info)
                {
                    String myExtension = fileExtension;
                    myExtension = myExtension.Replace(".", " ");
                    myExtension = myExtension.Trim();
                    myExtension = myExtension.ToLower();
                    if (myExtension == extension)
                    {
                        return true;
                    }
                }

            }
            else
            {
                return true;
            }
            return false;
        }


    }
}