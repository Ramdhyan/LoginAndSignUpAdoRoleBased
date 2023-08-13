using System;
using ProjectForPractice.Models;

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace ProjectForPractice.Controllers
{
    public class AdminController : Controller
    {
        public static string connectionstring = ConfigurationManager.AppSettings.Get("Con").ToString();

        // GET: Admin
       
        
        public ActionResult Index()
        {
          

            List<Registration> lst = new List<Registration>();

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("sp_alldata", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                var username = Session["UserName"];
                var role = (int)Session["RoleId"];

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (username != null && role == 2)
                    {
                        Registration registration = new Registration();
                        registration.Id = Convert.ToInt32(dr["Id"]);
                        registration.Name = dr["Name"].ToString();
                        registration.Email = dr["Email"].ToString();
                        registration.Mobile = dr["Mobile"].ToString();
                        registration.Gender = dr["Gender"].ToString();
                        registration.Profile = dr["Profile"].ToString();
                        registration.Qualification = dr["Qualification"].ToString();
                        registration.State = dr["State"].ToString();
                        registration.City = dr["City"].ToString();
                        lst.Add(registration);
                    }
                }
            }

            return View(lst);
        }
    }
}