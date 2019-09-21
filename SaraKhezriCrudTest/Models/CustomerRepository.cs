using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SaraKhezriCrudTest.Models
{
    public class CustomerRepository : ICustomerRepository
    {

        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myTestDB;Data Source=DESKTOP-0RB0HRU\\SQLEXPRESS";

        public IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Customer customer = new Customer();

                    customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    customer.FirstName = sqlDataReader["FirstName"].ToString();
                    customer.LastName= sqlDataReader["LastName"].ToString();
                    customer.DateOfBirth = sqlDataReader["DateOfBirth"].ToString();
                    customer.PhoneNumber= sqlDataReader["PhoneNumber"].ToString();
                    customer.Email = sqlDataReader["Email"].ToString();
                    customer.BankAccountNumber = sqlDataReader["BankAccountNumber"].ToString();

                    customers.Add(customer);
                }
                con.Close();
            }
            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@BankAccountNumber", customer.BankAccountNumber);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", customer.Id);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@BankAccountNumber", customer.BankAccountNumber);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Customer GetCustomerData(int? id)
        {
            Customer customer = new Customer();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblCustomer WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    customer.FirstName = sqlDataReader["FirstName"].ToString();
                    customer.LastName = sqlDataReader["LastName"].ToString();
                    customer.DateOfBirth = sqlDataReader["DateOfBirth"].ToString();
                    customer.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();
                    customer.Email = sqlDataReader["Email"].ToString();
                    customer.BankAccountNumber = sqlDataReader["BankAccountNumber"].ToString();
                }
            }
            return customer;
        }


        public Customer GetCustomerDataWithEmail(string email)
        {
            Customer customer = new Customer();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblCustomer WHERE Email= " + email;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    customer.FirstName = sqlDataReader["FirstName"].ToString();
                    customer.LastName = sqlDataReader["LastName"].ToString();
                    customer.DateOfBirth = sqlDataReader["DateOfBirth"].ToString();
                    customer.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();
                    customer.Email = sqlDataReader["Email"].ToString();
                    customer.BankAccountNumber = sqlDataReader["BankAccountNumber"].ToString();
                }
            }
            return customer;
        }
        public Customer GetCustomerDataWithNameAndDOB(string firstName, string lastName, string DateOfBirth)
        {
            Customer customer = new Customer();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string sqlQuery = "select * from tblCustomer where FirstName = '" + firstName + "' and LastName = '" + lastName + "'and DateOfBirth = '" + DateOfBirth + "'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    customer.FirstName = sqlDataReader["FirstName"].ToString();
                    customer.LastName = sqlDataReader["LastName"].ToString();
                    customer.DateOfBirth = sqlDataReader["DateOfBirth"].ToString();
                    customer.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();
                    customer.Email = sqlDataReader["Email"].ToString();
                    customer.BankAccountNumber = sqlDataReader["BankAccountNumber"].ToString();
                }
            }
            return customer;
        }

        public void DeleteCustomer(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
