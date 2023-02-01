using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;
using static DataLogic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private string cmdText = "Select * from Regions";
        private string cmdInsertText = @"UPDATE [dbo].[regions]
                                         SET [region_name] = 'Dao Vo'
                                         WHERE region_id = 10";

        [TestMethod]
        public void TestMethod1()
        {

            String connectionString = "Data Source=.;Initial Catalog=CaseStudy4;Integrated Security=True";
            var con = new SqlConnection(connectionString);
            con.Open();
            var cmd = new SqlCommand(cmdText, con);
            var result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (result.Read())
            {
                Assert.IsNotNull(result[0]);
                Assert.IsNotNull(result[1]);
            }
            con.Close();


            var cmdUpdate = new SqlCommand(cmdInsertText, con);

            con.Open();
            var kq = cmdUpdate.ExecuteNonQuery();
            Assert.IsTrue(kq == 1);

            DataLogic.GetDepartments(connectionString, 2020);
        }
    }


}
