using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Utilerias;
using MVCLaboratorio.Models;

namespace MVCLaboratorio.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult EmployeeRead()
        {
            DataTable dtEmployee;
            dtEmployee = BaseHelper.ejecutarConsulta("EmployeeRead", CommandType.StoredProcedure);
            List<Employee> lstEmployee = new List<Employee>();

            foreach (DataRow item in dtEmployee.Rows)
            {
                Employee emp = new Employee();
                emp.IdEmployee = int.Parse(item["IdEmpleado"].ToString());
                emp.Name = item["Nombre"].ToString();
                emp.Address = item["Direccion"].ToString();
                lstEmployee.Add(emp);
            }
            return View(lstEmployee);
        }

        public ActionResult EmployeeCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeCreate(string name,string address)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Name_sp", name));
            parameters.Add(new SqlParameter("@Address_sp", address));
            BaseHelper.ejecutarSentencia("EmployeeCreate", CommandType.StoredProcedure, parameters);
            
            return RedirectToAction("EmployeeRead");   
        }

        public ActionResult EmployeeDelete(int id)
        {
            DataTable dtEmployee;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", id));

            dtEmployee = BaseHelper.ejecutarConsulta("EmployeeDetail", CommandType.StoredProcedure, parameters);

            Employee empdata = new Employee();
            if (dtEmployee.Rows.Count > 0)
            {
                empdata.IdEmployee = int.Parse(dtEmployee.Rows[0]["IdEmpleado"].ToString());
                empdata.Name = dtEmployee.Rows[0]["Nombre"].ToString();
                empdata.Address = dtEmployee.Rows[0]["Direccion"].ToString();

                return View(empdata);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult EmployeeDelete(int id, FormCollection data)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", id));

            BaseHelper.ejecutarConsulta("EmployeeDelete", CommandType.StoredProcedure, parameters);

            return RedirectToAction("EmployeeRead");
        }

        public ActionResult EmployeeEdit(int id)
        {
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@id", id));
            DataTable dtEmployee = BaseHelper.ejecutarConsulta("EmployeeDetail", CommandType.StoredProcedure, Parameters);

            Employee emp = new Employee();

            if (dtEmployee.Rows.Count > 0)
            {
                emp.Name = dtEmployee.Rows[0]["Nombre"].ToString();
                emp.Address = dtEmployee.Rows[0]["Direccion"].ToString();

                return View(emp);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult EmployeeEdit(int id, Employee data)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id_sp", id));
            parameters.Add(new SqlParameter("@Name_sp", data.Name));
            parameters.Add(new SqlParameter("@Address_sp", data.Address));

            BaseHelper.ejecutarConsulta("EmployeeEdit", CommandType.StoredProcedure, parameters);

            return RedirectToAction("EmployeeRead");
        }

        public ActionResult EmployeeDetails(int id)
        {
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@id", id));
            DataTable dtEmployee = BaseHelper.ejecutarConsulta("EmployeeDetail", CommandType.StoredProcedure, Parameters);

            Employee emp = new Employee();

            if (dtEmployee.Rows.Count > 0)
            {
                emp.IdEmployee = id;
                emp.Name = dtEmployee.Rows[0]["Nombre"].ToString();
                emp.Address = dtEmployee.Rows[0]["Direccion"].ToString();

                return View(emp);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
