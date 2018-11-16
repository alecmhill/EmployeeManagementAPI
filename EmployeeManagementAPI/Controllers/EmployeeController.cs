using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using EmployeeManagementAPI.Models;
using Newtonsoft.Json;

namespace EmployeeManagementAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/employees")]
    public class EmployeeController : ApiController
    {
        // To Get all Employee Records
        [HttpGet]
        [Route("GetEmployees")]
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> Items = new List<EmployeeModel>();

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetEmployees";

            try
            {
                SystemAdminSettings.SetAndOpenConnection(cmd);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            EmployeeModel Item = new EmployeeModel();
                            Item.Id = Convert.ToInt32(row["Id"]);
                            Item.Name = row["Name"].ToString();
                            Item.Age = Convert.ToInt32(row["Age"]);
                            Item.Address = row["Address"].ToString();
                            Item.Department = row["Department"].ToString();
                            Item.PositionId = Convert.ToInt32(row["PositionId"]);
                            Items.Add(Item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

            return Items;
        }

        // To Get one employee record
        [HttpGet]
        [Route("GetEmployeeById")]
        public List<EmployeeModel> GetEmployeeById(int Id)
        {
            List<EmployeeModel> Items = new List<EmployeeModel>();

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetEmployeeById";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            try
            {
                SystemAdminSettings.SetAndOpenConnection(cmd);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            EmployeeModel Item = new EmployeeModel();
                            Item.Id = Convert.ToInt32(row["Id"]);
                            Item.Name = row["Name"].ToString();
                            Item.Age = Convert.ToInt32(row["Age"]);
                            Item.Address = row["Address"].ToString();
                            Item.Department = row["Department"].ToString();
                            Item.PositionId = Convert.ToInt32(row["PositionId"]);
                            Items.Add(Item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

            return Items;
        }

        // To Add Employee
        [HttpPost]
        [Route("AddEmployee")]
        public string AddEmployee(EmployeeModel Items)
        {
            string ReturnValue = "";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertEmployee";
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Items.Name;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = Items.Age;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Items.Address;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = Items.Department;
            cmd.Parameters.Add("@PositionId", SqlDbType.Int).Value = Items.PositionId;
            try
            {
                SystemAdminSettings.SetAndOpenConnection(cmd);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                ReturnValue = "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

            return ReturnValue;
        }


        // To update existing employee record
        [HttpPost]
        [Route("UpdateEmployee")]
        public string UpdateEmployee(EmployeeModel Items)
        {
            string ReturnValue = "";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateEmployee";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Items.Id;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Items.Name;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = Items.Age;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Items.Address;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = Items.Department;
            cmd.Parameters.Add("@PositionId", SqlDbType.Int).Value = Items.PositionId;
            try
            {
                SystemAdminSettings.SetAndOpenConnection(cmd);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                ReturnValue = "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

            return ReturnValue;
        }

        // To delete existing employee record
        [HttpPost]
        [Route("Deletemployee")]
        public string Deletemployee(EmployeeModel Items)
        {
            string ReturnValue = "";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteEmployee";
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Items.Id;
            try
            {
                SystemAdminSettings.SetAndOpenConnection(cmd);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                ReturnValue = "Success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

            return ReturnValue;
        }
    }
}