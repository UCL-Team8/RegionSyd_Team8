using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace RegionSyd_Team8.Models
{
    public class AssignmentRepository : IRepository<Assignment>
    {
        public ObservableCollection<Assignment> Assignments { get; set; }

        private readonly string _connectionString;

        public AssignmentRepository()
        {
            Assignments = new ObservableCollection<Assignment>();
        }

        public AssignmentRepository(string connectionString)
        {
            Assignments = new ObservableCollection<Assignment>();
            _connectionString = connectionString;
        }

        public void AddAssignment(Assignment assignment)
        {
            Assignments.Add(assignment);
        }

        public void RemoveAssignment(Assignment assignment)
        {
            Assignments.Remove(assignment);
        }

        public void UpdateAssignment(Assignment assignment)
        {
            //implementation
        }





        public IEnumerable<Assignment> GetAll()
        {
            var assignments = new List<Assignment>();
            string query = "SELECT * FROM ASSIGMENTS";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        assignments.Add(new Assignment
                        {
                            AssignmentID = (int)reader["AssignmentID"],
                            Description = (string)reader["AssignmentDescription"],
                            PickUpTime = (DateTime)reader["PickUpTime"],
                            DropOffTime = (DateTime)reader["DropOffTime"],
                            FromAddress = (string)reader["StartLocation1"],
                            ToAddress = (string)reader["EndLocation1"],

                        });
                    }
                }
            }

            return assignments;
        }

        public Assignment GetById(int id)
        {
            Assignment assignment = null;
            string query = "SELECT * FROM ASSIGMENTS WHERE AssignmentID = @AssignmentID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AssignmentID", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        assignment = new Assignment
                        {
                            AssignmentID = (int)reader["AssignmentID"],
                            Description = (string)reader["AssignmentDescription"],
                            PickUpTime = (DateTime)reader["PickUpTime"],
                            DropOffTime = (DateTime)reader["DropOffTime"],
                            FromAddress = (string)reader["StartLocation1"],
                            ToAddress = (string)reader["EndLocation1"],
                        };
                    }
                }
            }

            return assignment;
        }

        public void Add(Assignment assignment)
        {
            string query = "INSERT INTO ASSIGMENTS (AssignmentID, AssignmentDescription, PickUpTime, DropOffTime, StartLocation1, EndLocation1) VALUES (@AssignmentID, @AssignmentDescription, @PickUpTime, @DropOffTime, @StartLocation1, @EndLocation1)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AssignmentID", assignment.AssignmentID);
                command.Parameters.AddWithValue("@AssignmentDescription", assignment.Description);
                command.Parameters.AddWithValue("@PickUpTime", assignment.PickUpTime);
                command.Parameters.AddWithValue("@DropOffTime", assignment.DropOffTime);
                command.Parameters.AddWithValue("@StartLocation1", assignment.FromAddress);
                command.Parameters.AddWithValue("@EndLocation1", assignment.ToAddress);


                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Assignment assignment)
        {
            string query = "UPDATE ASSIGMENTS SET AssignmentDescription = @AssignmentDescription WHERE AssignmentID = @AssignmentID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AssignmentDescription", assignment.Description);
                command.Parameters.AddWithValue("@AssignmentID", assignment.AssignmentID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM ASSIGMENTS WHERE AssignmentID = @AssignmentID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AssignmentID", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
