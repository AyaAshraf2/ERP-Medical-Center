using System;
using System.Data;
using System.Data.SqlClient;

namespace Utilities
{
    public class SqlAdoWrapper
    {

        #region SQL Commands Functions

        /// <summary>
        /// Execute an SQL command that returns data.
        /// </summary>
        /// <param name="strStoredProcdureName">The name of the stored procedure to execute.</param>
        /// <returns>Returns null if error occured otherwise it returns the data table that will carry the returned
        /// data from the command.</returns>
        public static DataTable ExecuteQueryCommand(string strStoredProcdureName)
        {
            return ExecuteQueryCommand(strStoredProcdureName, null, true, null);
        }
        /// <summary>
        /// Execute an SQL command that returns data.
        /// </summary>
        /// <param name="strStoredProcdureName">The name of the stored procedure to execute.</param>
        /// <param name="sqlprmParameters">The Parameter collection of the SQL  command.</param>
        /// <param name="bTextCommand">Determines whether the command is text or Stored procedure. True = txt command ,False = Stored procedure</param>
        /// <returns>Returns null if error occured otherwise it returns the data table that will carry the returned
        /// data from the command.</returns>
        public static DataTable ExecuteQueryCommand(string strStoredProcdureName, SqlParameter[] sqlprmParameters, bool bTextCommand)
        {
            return ExecuteQueryCommand(strStoredProcdureName, sqlprmParameters, bTextCommand, null);
        }
        /// <summary>
        /// Execute an SQL command that returns data.
        /// </summary>
        /// <param name="strStoredProcdureName">The name of the stored procedure to execute.</param>
        /// <param name="sqlprmParameters">The Parameter collection of the SQL  command.</param>
        /// <param name="bTextCommand">Determines whether the command is text or Stored procedure.
        /// <param name="trTrans">The transaction that the SQL Command will run in.</param>
        /// True = txt command ,False = Stored procedure</param>
        /// <returns>Returns null if error occured otherwise it returns the data table that will carry the returned
        /// data from the command.</returns>
        public static DataTable ExecuteQueryCommand(string strStoredProcdureName, SqlParameter[] sqlprmParameters, bool bTextCommand,
            SqlTransaction trTrans)
        {
            DataTable dtResult = new DataTable();
            using (SqlCommand cmdSelect = new SqlCommand())
            using (SqlConnection SQLConnection = new SqlConnection())
            {
                cmdSelect.CommandTimeout = 0;
                cmdSelect.CommandType = bTextCommand ? CommandType.Text : CommandType.StoredProcedure;
                cmdSelect.CommandText = strStoredProcdureName;
                if (sqlprmParameters != null && sqlprmParameters.Length > 0)
                    cmdSelect.Parameters.AddRange(sqlprmParameters);
                if (trTrans != null)
                    cmdSelect.Transaction = trTrans;
                SqlDataAdapter daSelect = new SqlDataAdapter(cmdSelect);
                SQLConnection.ConnectionString = DBConnection.ConnectionString;
                //if (DBConnection.Connect())
                //{
                cmdSelect.Connection = SQLConnection;
                SQLConnection.Open();
                daSelect.Fill(dtResult);
                SQLConnection.Close();
                //}
                //else
                //    return null;
                if (daSelect != null)
                {
                    daSelect.Dispose();
                    daSelect = null;
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return dtResult;
            //SqlCommand cmdSelect = new SqlCommand();
        }
        /// <summary>
        /// Execute an SQL command that returns one value only.
        /// </summary>
        /// <param name="strStoredProcdureName">The SQL command that will return the result.</param>
        /// <returns>Returns false if error occured otherwise it returns true.</returns>
        public static object ExecuteScalarCommand(string strStoredProcdureName)
        {
            return ExecuteScalarCommand(strStoredProcdureName, null, true, null);
        }
        /// <summary>
        /// Execute an SQL command that returns one value only.
        /// </summary>
        /// <param name="cmdCommand">The SQL command that will return the result.</param>
        /// <param name="Result">The value returned from the command.</param>
        /// <param name="bTextCommand">Determines whether the command is text or Stored procedure.</param>
        /// <returns>Returns false if error occured otherwise it returns true.</returns>
        public static object ExecuteScalarCommand(string strStoredProcdureName, SqlParameter[] sqlprmParameters, bool bTextCommand)
        {
            return ExecuteScalarCommand(strStoredProcdureName, sqlprmParameters, bTextCommand, null);
        }
        /// <summary>
        /// Execute an SQL command that returns one value only.
        /// </summary>
        /// <param name="cmdCommand">The SQL command that will return the result.</param>
        /// <param name="Result">The value returned from the command.</param>
        /// <param name="bTextCommand">Determines whether the command is text or Stored procedure.</param>
        /// <param name="trTrans">The transaction that the SQL Command will run in.</param>
        /// <returns>Returns false if error occured otherwise it returns true.</returns>
        public static object ExecuteScalarCommand(string strStoredProcdureName, SqlParameter[] sqlprmParameters, bool bTextCommand,
            SqlTransaction trTrans)
        {
            using (SqlCommand cmdCommand = new SqlCommand())
            using (SqlConnection SQLConnection = new SqlConnection())
            {
                cmdCommand.CommandTimeout = 0;
                cmdCommand.CommandText = strStoredProcdureName;
                cmdCommand.CommandType = bTextCommand ? CommandType.Text : CommandType.StoredProcedure;
                cmdCommand.Connection = SQLConnection;
                SQLConnection.ConnectionString = DBConnection.ConnectionString;
                if (sqlprmParameters != null && sqlprmParameters.Length > 0)
                    cmdCommand.Parameters.AddRange(sqlprmParameters);
                if (trTrans != null)
                    cmdCommand.Transaction = trTrans;
                SQLConnection.Open();
                object objResult = cmdCommand.ExecuteScalar();
                SQLConnection.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return objResult;
            }
        }
        /// <summary>
        /// Execute an sql command that dosen't return any data.
        /// </summary>
        /// <param name="strStoredProcdureName">The name of the stored procedure to execute.</param>
        /// <param name="sqlprmParameters">The Parameter collection of the SQL  command.</param>
        /// <param name="trTrans">The transaction that the SQL Command will run in.</param>
        /// <param name="bTextCommand">Determines whether the command is text or Stored procedure.</param>
        /// <returns>Returns -1 if error occured otherwise it returns the number of affected rows in the Database
        /// by this command.</returns>
        public static int ExecuteNonQueryCommand(string strStoredProcdureName, SqlParameter[] sqlprmParameters, bool bTextCommand,
            SqlTransaction trTrans)
        {
            using (SqlCommand cmdCommand = new SqlCommand())
            using (SqlConnection SQLConnection = new SqlConnection())
            {
                cmdCommand.CommandTimeout = 0;
                cmdCommand.CommandText = strStoredProcdureName;
                cmdCommand.CommandType = bTextCommand ? CommandType.Text : CommandType.StoredProcedure;
                if (sqlprmParameters != null && sqlprmParameters.Length > 0)
                    cmdCommand.Parameters.AddRange(sqlprmParameters);
                SQLConnection.ConnectionString = DBConnection.ConnectionString;
                cmdCommand.Connection = SQLConnection;
                if (trTrans != null)
                    cmdCommand.Transaction = trTrans;
                SQLConnection.Open();
                int iResult = cmdCommand.ExecuteNonQuery();
                SQLConnection.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return iResult;
            }
            //else
            //    return -1;
        }
        /// <summary>
        /// Execute an sql command that dosen't return any data.
        /// </summary>
        /// <param name="strStoredProcdureName">The name of the stored procedure to execute.</param>
        /// <param name="sqlprmParameters">The Parameter collection of the SQL  command.</param>
        /// <param name="bTextCommand">Determines whether the command is text or Stored procedure.</param>
        /// <returns>Returns -1 if error occured otherwise it returns the number of affected rows in the Database
        /// by this command.</returns>
        public static int ExecuteNonQueryCommand(string strStoredProcdureName, SqlParameter[] sqlprmParameters, bool bTextCommand)
        {
            return ExecuteNonQueryCommand(strStoredProcdureName, sqlprmParameters, bTextCommand, null);
        }
        /// <summary>
        /// Gets the databases exsit on the server.
        /// </summary>
        /// <param name="bSelectMaster">A value to indicate whether to select the master data base or not.</param>
        /// <param name="bConnectToServer">A value to indicate whether to connect to the server or to the company (true: Server; false: Company).</param>
        /// <returns>Returns a data table that have the database names in it.</returns>
        public static DataTable SelectServerDatabases(bool bSelectMaster)
        {
            string strCommand = string.Empty;
            string strMaster = string.Empty;
            if (!bSelectMaster)
                strMaster = "'master', ";
            strCommand = "select db_name(dbid) as DataBaseName from master.dbo.sysdatabases"
                + " where has_dbaccess(db_name(dbid)) = 1 and db_name(dbid) not in(" + strMaster + "'tempdb', 'model'"
                + ",'msdb', 'ReportServer', 'ReportServerTempDB') order by name";
            return ExecuteQueryCommand(strCommand);
            //DataTable tblDatabases = new DataTable();
            //SqlCommand cmdSelectDBs = new SqlCommand();
            //cmdSelectDBs.CommandTimeout = 0;
            //if (DBConnection.Connection.State == ConnectionState.Open)
            //    cmdSelectDBs = DBConnection.Connection.CreateCommand();
            //cmdSelectDBs.CommandType = CommandType.Text;
            //string strMaster = string.Empty;
            //if (!bSelectMaster)
            //    strMaster = "'master', ";
            //cmdSelectDBs.CommandText = "select db_name(dbid) as DataBaseName from master.dbo.sysdatabases"
            //    + " where has_dbaccess(db_name(dbid)) = 1 and db_name(dbid) not in(" + strMaster + "'tempdb', 'model'"
            //    + ",'msdb', 'ReportServer', 'ReportServerTempDB') order by name";
            //SqlDataAdapter daDatabases = new SqlDataAdapter();
            //daDatabases.SelectCommand = cmdSelectDBs;
            //DBConnection.Connect();
            //daDatabases.Fill(tblDatabases);
            //return tblDatabases;
        }

        #endregion

        #region Data Table Functions

        /// <summary>
        /// Checks if a set of strings is the names of columns in a data table.
        /// </summary>
        /// <param name="dtCheck">The datatable to check the columns in it.</param>
        /// <param name="Columns">The set of strings to check in the datatable.</param>
        /// <returns>Returns true if all columns names exist in the datatable.</returns>
        public static bool CheckColumns(DataTable dtCheck, string[] Columns)
        {
            if (dtCheck == null) return true;
            for (int i = 0; i < Columns.Length; i++)
                if (Columns[i] == null || dtCheck.Columns.Contains(Columns[i]))
                    continue;
                else
                    return false;
            return true;
        }
       
        /// <summary>
        /// Checks if the table name exists in the current database or not.
        /// </summary>
        /// <param name="strTableName">The table name to check.</param>
        /// <returns>Returns true if the table name exists in the current database otherwise ot returns false.</returns>
        public static bool CheckTableName(string strTableName)
        {
            try
            {
                SqlParameter[] sqlprm = new SqlParameter[1];
                sqlprm[0] = new SqlParameter("@Name", strTableName);
                object objRes = ExecuteScalarCommand("select Count(Name) from sys.Tables where Name =@Name", sqlprm, true);
                return objRes == DBNull.Value ? false : Convert.ToInt32(objRes) > 0;
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
                return false;
            }
        }
        /// <summary>
        /// Get all the Table names in the current database.
        /// </summary>
        /// <returns>Returns a datatable that contains the names of the tables in the current database.</returns>
        public static DataTable GetTableNames()
        {
            return ExecuteQueryCommand("select Name from sys.Tables", null, true);
        }
        /// <summary>
        /// Gets the column names of the supplied data table.
        /// </summary>
        /// <param name="strTableName">The data table to get its culumn names.</param>
        /// <param name="bSelectStringColumnsOnly">A value to determine whether to get the string fields only or not.</param>
        /// <returns>Returns a data table that contains the strings of the required columns.</returns>
        public static DataTable GetTableColumnNames(string strTableName, bool bSelectStringColumnsOnly)
        {
            try
            {
                if (!CheckTableName(strTableName))
                    return null;
                SqlParameter[] sqlprm = new SqlParameter[1];
                sqlprm[0] = new SqlParameter("@TableName", strTableName);
                string strCommandtext = "SELECT DISTINCT sys.columns.name as DBName FROM sys.types INNER JOIN "
                    + "sys.columns INNER JOIN  sys.tables ON sys.columns.object_id = sys.tables.object_id ON sys.types.system_type_id = "
                    + "sys.columns.system_type_id "
                    + "WHERE (sys.types.name <> 'sysname') AND (sys.tables.name = @TableName)";
                if (bSelectStringColumnsOnly)
                    strCommandtext += " and sys.types.name in ('nvarchar','varchar','char','nchar')";
                strCommandtext += " ORDER BY DBName";
                return ExecuteQueryCommand(strCommandtext, sqlprm, true);
            }
            catch (Exception ex)
            {
                ErrorHandler.LogError(ex);
                return null;
            }
        }

        #endregion

    }
}