using ProjectForPractice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectForPractice.Controllers
{
    public class HomeController : Controller
    {
        public static string connectionstring = ConfigurationManager.AppSettings.Get("Con").ToString();
        public void BindState()
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("BindState", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var states = new List<SelectListItem>();
                while(dr.Read())
                {
                    states.Add(new SelectListItem
                    {
                        Text = dr["SteteName"].ToString(),
                        Value = dr["State_Id"].ToString()
                    });
                }
            ViewBag.State = states;
            }

        }
        [HttpPost]
        public ActionResult GetCities(int StateId)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("BindCity", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@State_Id",StateId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var cities = new List<SelectListItem>();
                while (dr.Read())
                {
                    cities.Add(new SelectListItem
                    {
                        Text = dr["CityName"].ToString(),
                        Value = dr["City_Id"].ToString()
                    });
                }
            return Json(cities);
            }
        }
        public ActionResult Index()
        {
            BindState();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Registration registration)
        {
            using(SqlConnection con=new SqlConnection(connectionstring))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        HttpPostedFileBase file = Request.Files["Profile"];
                        registration.Profile = file.FileName;
                        SqlCommand cmd = new SqlCommand("sp_registration", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", registration.Name);
                        cmd.Parameters.AddWithValue("@Email", registration.Email);
                        cmd.Parameters.AddWithValue("@Mobile", registration.Mobile);
                        cmd.Parameters.AddWithValue("@Gender", registration.Gender);
                        cmd.Parameters.AddWithValue("@profile", file.FileName);
                        cmd.Parameters.AddWithValue("@Qualification", registration.Qualification);
                        cmd.Parameters.AddWithValue("@DOB", registration.DOB);
                        cmd.Parameters.AddWithValue("@State", registration.State);
                        cmd.Parameters.AddWithValue("@City", registration.City);
                        cmd.Parameters.AddWithValue("@Address", registration.Address);
                        cmd.Parameters.AddWithValue("@PinCode", registration.PinCode);
                        cmd.Parameters.AddWithValue("@Password", registration.Password);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        file.SaveAs(Server.MapPath("~/content/Images/" + file.FileName));
                        if (i > 0)
                        {
                            TempData["msg"] = "<script>alert('Registration Success !')</script>";
                            return RedirectToAction("Login", "Home");
                        }
                        else
                        {
                            TempData["msg"] = "<script>alert('Oops ! Something Went wrong please try again late.')</script>";

                        }
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            BindState();

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        SqlCommand cmd = new SqlCommand("sp_login", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", login.UserName);
                        cmd.Parameters.AddWithValue("@Password", login.Password);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            Session["UserName"] = login.UserName.ToString();
                            Session["RoleId"] = dr["RoleId"];
                            int role = (int)Session["RoleId"];
                            if(Session["UserName"]!=null && role == 1)
                            {
                                TempData["msg"] = "<script>alert('Welcome to User Pannel !')</script>";

                                return RedirectToAction("UserData", "Home");
                            }
                            else if(Session["UserName"] != null && role == 2)
                            {
                                TempData["msg"] = "<script>alert('Welcome to Admin Pannel !')</script>";

                                return RedirectToAction("Index", "Admin");

                            }
                            else
                            {
                                TempData["error"] = "<script>alert('Invalid Credentials ! Please Check userName Or Password')</script>";
                            }
                        }
                     else
                        {
                            TempData["error"] = "<script>alert('Invalid Credentials ! Please Check userName Or Password')</script>";
                            return RedirectToAction("Login", "Home");
                        }
                            
                       
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View();
        }
        public ActionResult UserData()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}