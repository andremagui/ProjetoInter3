using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ProjetoVacinas.Context.Models;


namespace ProjetoVacinas.Controllers
{
    public class UsersController : Controller
    {
        private readonly Appsettings _appSettings;

        public UsersController(Appsettings appsettings)
        {
            _appSettings = appsettings;
        }

        public IActionResult index()
        {
            
            MySqlConnection conn = new MySqlConnection(_appSettings.ConnectionString);

            List<User> result = new List<User>();
            List<Dependent> dependents = new List<Dependent>();
            List<Vaccine> vaccines = new List<Vaccine>();
            List<Dose> doses = new List<Dose>();

            try
            {

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT UserID, UserName, UserCpf, UserEmail FROM User", conn))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        using (MySqlCommand cmd2 = new MySqlCommand("select DependentID, DependentName, DependentBirth, DependentBlood,DependentAllergy, DependentSusNo from Dependent inner join User_dep on Dependent.DependentID = User_dep.Dep_DependentID where User_dep.Dep_DependentID = " + dataReader.GetInt32(0), conn))
                        {
                            MySqlDataReader dataReader2 = cmd2.ExecuteReader();

                            while (dataReader2.Read())
                            {
                                using (MySqlCommand cmd3 = new MySqlCommand("select VaccineID, VaccineName from Vaccine inner join Vaccine_Dep_Att on Dependent.DependentID = Vaccine_Dep_Att.Dep_DependentID where Vaccine_Dep_Att.DependentID = " + dataReader2.GetInt32(0), conn))
                                {
                                    MySqlDataReader dataReader3 = cmd3.ExecuteReader();

                                    while (dataReader3.Read())
                                    {
                                        using (MySqlCommand cmd4 = new MySqlCommand("select DoseID, DoseType from Dose inner join Vaccine on Dose.VaccineID = Vaccine.VaccineID where VaccineID.VaccineID = " + dataReader3.GetInt32(0), conn))
                                        {
                                            MySqlDataReader dataReader4 = cmd3.ExecuteReader();

                                            while (dataReader4.Read())
                                            {
                                                doses.Add(new Dose
                                                {
                                                    DoseID = dataReader4.GetInt32(0),
                                                    DoseType = dataReader4.GetString(1),
                                                });
                                            }
                                        }

                                        vaccines.Add(new Vaccine
                                        {
                                            VaccineID = dataReader3.GetInt32(0),
                                            VaccineName = dataReader3.GetString(1),
                                            Doses = doses
                                        });
                                    }

                                    dependents.Add(new Dependent
                                    {
                                        DependentID = dataReader2.GetInt32(0),
                                        DependentName = dataReader2.GetString(1),
                                        DependentBirth = dataReader2.GetDateTime(2),
                                        DependentBlood = dataReader2.GetString(3),
                                        DependentAllergy = dataReader2.GetString(4),
                                        DependentSusNo = dataReader2.GetString(5),
                                        Vaccines = vaccines
                                    });
                                }
                            }

                            result.Add(new User
                            {
                                UserID = dataReader.GetInt32(0),
                                UserName = dataReader.GetString(1),
                                UserCpf = dataReader.GetString(2),
                                UserEmail = dataReader.GetString(3),
                                Dependents = dependents
                            });
                        }
                    }
                    return View();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }

        }

       
    }
}