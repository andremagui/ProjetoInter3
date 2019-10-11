using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ProjetoVacinas.Context.Models;
using ProjetoVacinas.Models;



namespace ProjetoVacinas.Controllers
{
    public class UbsController : Controller
    {
        private readonly Appsettings _appSettings;

        public UbsController(Appsettings appsettings)
        {
            _appSettings = appsettings;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult CreateUser(CreateViewModel request)
        {
           

            MySqlConnection conn = new MySqlConnection(_appSettings.ConnectionString);

            try {
      
                conn.Open();

                if (request.UserID > 0)
                {
                    using (MySqlCommand cmd = new MySqlCommand("UPDATE User SET (UserName = @UserName, UserCpf = @UserCpf, UserEmail = @UserEmail) WHERE UserID =" + request.UserID, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", request.UserName);
                        cmd.Parameters.AddWithValue("@UserCpf", request.UserCpf);
                        cmd.Parameters.AddWithValue("@UserEmail", request.UserEmail);

                        cmd.ExecuteNonQuery();

                    }
                    return RedirectToAction("Index");//pagina de busca de cpf

                }
                else
                {
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO User (UserName, UserCpf, UserEmail) VALUES (@UserName, @UserCpf, @UserEmail) FROM User WHERE UserID =" + request.UserID, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", request.UserName);
                        cmd.Parameters.AddWithValue("@UserCpf", request.UserCpf);
                        cmd.Parameters.AddWithValue("@UserEmail", request.UserEmail);

                        cmd.ExecuteNonQuery();

                    }
                    
                    return RedirectToAction("Index");//pagina de busca de cpf
                }
            }catch (Exception ex)
            {
                    return View();
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }

        }
        
    }
}
