using System;
using System.Data.SqlClient;
using System.Data;

namespace Utilities
{
    /// <summary>
    /// Connect and disconnect the application with the database.
    /// </summary>
    public class DBConnection
    {

        #region Private Members

        static SqlConnection sqlcnnDBConnection = new SqlConnection();
        //static string strConnectionString = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the connection object of the application to the database.
        /// </summary>
        //public static SqlConnection Connection
        //{
        //    get
        //    {
        //        return sqlcnnDBConnection;
        //    }
        //}
        /// <summary>
        /// Gets and sets the connection string of the database.
        /// </summary>
        public static string ConnectionString = "";

        #endregion

        #region Public Functions

        /// <summary>
        /// Connects to the database of the application.
        /// </summary>
        /// <returns>Returns true if the application successfully connected to the database otherwise 
        /// it returns false.</returns>
        public static bool Connect()
        {
            try
            {
                //if (sqlcnnDBConnection.State == ConnectionState.Open) return true;
                //return Connect(ConfigurationManager.ServerName, ConfigurationManager.DataBaseName,
                //    bool.TrueString.ToLower() == ConfigurationManager.IntegratedSecurity.ToLower(), ConfigurationManager.Username,
                //    ConfigurationManager.Password, ConfigurationManager.PortNo);
                if (sqlcnnDBConnection.State == ConnectionState.Open || sqlcnnDBConnection.State == ConnectionState.Connecting || sqlcnnDBConnection.State == ConnectionState.Executing)
                return true;
            sqlcnnDBConnection = new SqlConnection();
            //strConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["OTPConnectionString"].ConnectionString;
            sqlcnnDBConnection.ConnectionString = ConnectionString;
            sqlcnnDBConnection.Open();
            return true;
            }
            catch (Exception e)
            {
                ErrorHandler.LogError(e);
            }
            return false;
            //finally
            //{
            //    if (sqlcnnDBConnection.State != ConnectionState.Open)
            //        strConnectionString = string.Empty;
            //}
        }
        /// <summary>
        /// Disconnects the connection from the database server.
        /// </summary>
        /// <returns>Returns true if the connection is disconnected successfully other wise it returns false.</returns>
        public static bool Disconnect()
        {
            try
            {
                if (sqlcnnDBConnection != null && sqlcnnDBConnection.State != ConnectionState.Closed)
                {
                    sqlcnnDBConnection.Close();
                    sqlcnnDBConnection.Dispose();
                }
                return true;
            }
            catch (Exception e)
            {
                ErrorHandler.LogError(e);
                return false;
            }
        }
        
        #endregion

    }
}