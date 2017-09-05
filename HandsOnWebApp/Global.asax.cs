using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace HandsOnWebApp {

    public class Global : HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

            string commandCreateTable = @"
                IF object_id('dbo.sum_results') is null
                BEGIN
                  CREATE TABLE sum_results(
                    v1   float  not null,
                    v2   float  not null,
                    sum  float  not null
                  );
                END
            ";

            try {
                var constr = ConfigurationManager.ConnectionStrings["handsondb"];

                using (SqlConnection sqlcon = new SqlConnection(constr.ConnectionString)) {
                    sqlcon.Open();
                    using (SqlCommand command = new SqlCommand(commandCreateTable, sqlcon)) {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { }
        }
    }
}