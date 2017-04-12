using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WikiDataProvider.Data.Extensions;

namespace WikiDataProvider.Example
{
    public class PersonService
    {
        /// <summary>
        /// Inserts a row into the Person table and returns the new id assigned in the database.
        /// </summary>
        /// <param name="p">Person</param>
        /// <returns>int</returns>
        public static int Insert(Person p)
        {
            int id = 0;

            WikiDataProvider.Data.DataProvider.Instance.ExecuteNonQuery(
                GetConnection,
                "People_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@FirstName", p.FirstName);
                    paramCollection.AddWithValue("@LastName", p.LastName);
                    paramCollection.AddWithValue("@MiddleInitial", p.MiddleInitial);

                    SqlParameter parm = new SqlParameter("@Id", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    paramCollection.Add(parm);
                },
                returnParameters: delegate (SqlParameterCollection paramCollection)
                {
                    int.TryParse(paramCollection["@Id"].Value.ToString(), out id);
                });

            return id;
        }

        /// <summary>
        /// Retrieves a single record from the Person Table specified by the parameter id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Person</returns>
        public static Person SelectById(int id)
        {
            Person p = null;
            WikiDataProvider.Data.DataProvider.Instance.ExecuteCmd(
                GetConnection,
                "People_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@id", id);
                },
                map: delegate (IDataReader reader, short set) {
                    p = PersonMapper(reader);
                });
            return p;
        }

        /// <summary>
        /// Returns all the rows from the Person table as a Generic List of Person objects
        /// </summary>
        /// <returns>List<Person></returns>
        public static List<Person> SelectAll()
        {
            List<Person> personList = new List<Person>();

            WikiDataProvider.Data.DataProvider.Instance.ExecuteCmd(
                GetConnection,
                "People_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    Person p = PersonMapper(reader);
                    personList.Add(p);
                });

            return personList;
        }

        /// <summary>
        /// Updates a row in the Person Table
        /// </summary>
        /// <param name="p">Person</param>
        public static void Update(Person p) {
            WikiDataProvider.Data.DataProvider.Instance.ExecuteNonQuery(
                GetConnection,
                "People_Update",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", p.Id);
                    paramCollection.AddWithValue("@FirstName", p.FirstName);
                    paramCollection.AddWithValue("@LastName", p.LastName);
                    paramCollection.AddWithValue("@MiddleInitial", p.MiddleInitial);
                },
                returnParameters: null);
        }

        /// <summary>
        /// Deletes a row from the Person Table based on the id Parameter
        /// </summary>
        /// <param name="id">int</param>
        public static void Delete(int id) {
            WikiDataProvider.Data.DataProvider.Instance.ExecuteNonQuery(
                GetConnection,
                "People_DeleteById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                },
                returnParameters: null
                );
        }

        /// <summary>
        /// Reusable method used for mapping the results of the IDataReader to a Person Object
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Person PersonMapper(IDataReader reader)
        {
            Person p = new Person();

            int startingIndex = 0;
            p.Id = reader.GetSafeInt32(startingIndex++);
            p.FirstName = reader.GetSafeString(startingIndex++);
            p.LastName = reader.GetSafeString(startingIndex++);
            p.MiddleInitial = reader.GetSafeString(startingIndex++);

            return p;
        }
        
        /// <summary>
        /// Method used for returning the connnection string from the web.config or app.config
        /// </summary>
        /// <returns>SqlConnection</returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}
