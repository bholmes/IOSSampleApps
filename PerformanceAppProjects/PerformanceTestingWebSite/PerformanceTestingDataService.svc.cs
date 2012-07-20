using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace PerformanceTestingWebSite
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PerformanceTestingDataService : IPerformanceTestingDataService
    {
        public int AddDevice(FullDeviceInfo deviceInfo)
        {
            int databaseId = -1;

            System.Data.Odbc.OdbcConnection conn = createSQLConnection();
            System.Data.Odbc.OdbcTransaction transaction = null;
            try
            {
                string selectQuery = string.Format("SELECT `DatabaseId` FROM `PerformanceAppDeviceInfo` WHERE `UniqueId` = '{0}'", deviceInfo.UniqueId);
                conn.Open();
                System.Data.Odbc.OdbcCommand selectCommand = new System.Data.Odbc.OdbcCommand(selectQuery, conn);
                try
                {
                    databaseId = (int)selectCommand.ExecuteScalar();
                }
                catch (Exception)
                {

                }

                if (databaseId == -1)
                {

                    string myInsertQuery =
                        string.Format("INSERT INTO `billholmes54`.`PerformanceAppDeviceInfo` (`DatabaseId`, `UniqueId`, `SystemName`, `ModelName`, `UIIdion`, `SpecificHWVersion`, `OSName`, `OSVersion`, `OwnerName`) VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');",
                        deviceInfo.UniqueId, deviceInfo.SystemName, deviceInfo.ModelName, deviceInfo.UIIdion, deviceInfo.SpecificHWVersion,
                        deviceInfo.OSName, deviceInfo.OSVersion, deviceInfo.OwnerName);

                    transaction = conn.BeginTransaction();

                    System.Data.Odbc.OdbcCommand insertCommand = new System.Data.Odbc.OdbcCommand(myInsertQuery, conn, transaction);
                    insertCommand.ExecuteNonQuery();

                    insertCommand.CommandText = "select last_insert_id();";
                    databaseId = Convert.ToInt32(insertCommand.ExecuteScalar());

                    transaction.Commit();
                }
                else
                {
                    string myInsertQuery =
                        string.Format("UPDATE `billholmes54`.`PerformanceAppDeviceInfo` SET `SystemName` = '{0}', `ModelName` = '{1}', `UIIdion` = '{2}', `SpecificHWVersion` = '{3}', `OSName` = '{4}', `OSVersion` = '{5}', `OwnerName` = '{6}' WHERE `PerformanceAppDeviceInfo`.`DatabaseId` = {7} LIMIT 1;",
                        deviceInfo.SystemName, deviceInfo.ModelName, deviceInfo.UIIdion, deviceInfo.SpecificHWVersion,
                        deviceInfo.OSName, deviceInfo.OSVersion, deviceInfo.OwnerName, databaseId);

                    System.Data.Odbc.OdbcCommand updateCommand = new System.Data.Odbc.OdbcCommand(myInsertQuery, conn);
                    updateCommand.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();

                throw;
            }
            finally
            {
                conn.Close();
            }

            return databaseId;
        }

        public DeviceInfo FindDeviceInfo(int databaseId)
        {
            System.Data.Odbc.OdbcConnection conn = createSQLConnection();
            try
            {
                string selectQuery = string.Format("SELECT `ModelName`, `UIIdion`, `SpecificHWVersion`, `OSName`, `OSVersion` FROM `PerformanceAppDeviceInfo` WHERE `DatabaseId` = {0}", databaseId);
                conn.Open();
                System.Data.Odbc.OdbcCommand selectCommand = new System.Data.Odbc.OdbcCommand(selectQuery, conn);
                try
                {
                    System.Data.Odbc.OdbcDataReader reader = selectCommand.ExecuteReader();

                    if (!reader.Read())
                        return null;

                    return new DeviceInfo()
                    {
                        DatabaseId = databaseId,
                        ModelName = reader["ModelName"].ToString (),
                        OSName = reader["OSName"].ToString(),
                        OSVersion = reader["OSVersion"].ToString(),
                        SpecificHWVersion = reader["SpecificHWVersion"].ToString(),
                        UIIdion = reader["UIIdion"].ToString(),
                    };
                }
                catch (Exception)
                {

                }
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        public FullDeviceInfo FindFullDeviceInfo(string uniqueId)
        {
            System.Data.Odbc.OdbcConnection conn = createSQLConnection();
            try
            {
                string selectQuery = string.Format("SELECT * FROM  `PerformanceAppDeviceInfo` WHERE  `UniqueId` =  '{0}'", uniqueId);
                conn.Open();
                System.Data.Odbc.OdbcCommand selectCommand = new System.Data.Odbc.OdbcCommand(selectQuery, conn);
                try
                {
                    System.Data.Odbc.OdbcDataReader reader = selectCommand.ExecuteReader();

                    if (!reader.Read())
                        return null;

                    return new FullDeviceInfo ()
                    {
                        DatabaseId =  Convert.ToInt32 (reader["DatabaseId"]),
                        ModelName = reader["ModelName"].ToString(),
                        OSName = reader["OSName"].ToString(),
                        OSVersion = reader["OSVersion"].ToString(),
                        SpecificHWVersion = reader["SpecificHWVersion"].ToString(),
                        UIIdion = reader["UIIdion"].ToString(),
                        SystemName = reader["SystemName"].ToString(),
                        OwnerName = reader["OwnerName"].ToString (),
                        UniqueId = uniqueId,
                    };
                }
                catch (Exception)
                {

                }
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        public List<DeviceInfo> GetDeviceList()
        {
            // SELECT `DatabaseId`, `ModelName`, `UIIdion`, `SpecificHWVersion`, `OSName`, `OSVersion` FROM `PerformanceAppDeviceInfo`
            List<DeviceInfo> retList = new List<DeviceInfo>();

            System.Data.Odbc.OdbcConnection conn = createSQLConnection();
            try
            {
                string selectQuery = "SELECT `DatabaseId`, `ModelName`, `UIIdion`, `SpecificHWVersion`, `OSName`, `OSVersion` FROM `PerformanceAppDeviceInfo`";
                conn.Open();
                System.Data.Odbc.OdbcCommand selectCommand = new System.Data.Odbc.OdbcCommand(selectQuery, conn);
                try
                {
                    System.Data.Odbc.OdbcDataReader reader = selectCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        DeviceInfo di = new DeviceInfo()
                        {
                            DatabaseId = (int)reader["DatabaseId"],
                            ModelName = reader["ModelName"].ToString(),
                            OSName = reader["OSName"].ToString(),
                            OSVersion = reader["OSVersion"].ToString(),
                            SpecificHWVersion = reader["SpecificHWVersion"].ToString(),
                            UIIdion = reader["UIIdion"].ToString(),
                        };
                        retList.Add(di);
                    }
                }
                catch (Exception)
                {

                }
            }
            finally
            {
                conn.Close();
            }

            return retList;
        }

        public int AddPerformanceCubeResult(PerformanceCubeResult result)
        {
            int databaseId = -1;

            System.Data.Odbc.OdbcConnection conn = createSQLConnection();
            System.Data.Odbc.OdbcTransaction transaction = null;
            try
            {
                string mySelectQuery =
                    string.Format("SELECT  `id` ,  `FramesPerSecond` FROM  `PerformanceGLCubeResults` WHERE  `DBDeviceId` ={0} AND  `NumberTriangles` ={1} AND  `isMonoTouch` ={2}",
                    result.DeviceDatabaseId, result.NumberOfTriangles, result.IsMonoTouch ? 1 : 0);

                conn.Open();

                System.Data.Odbc.OdbcCommand mySelectCommand = new System.Data.Odbc.OdbcCommand(mySelectQuery, conn);
                System.Data.Odbc.OdbcDataReader reader = mySelectCommand.ExecuteReader();

                if (reader.Read())
                {
                    System.Data.Odbc.OdbcCommand myUpdateCommand = new System.Data.Odbc.OdbcCommand(mySelectQuery, conn);
                    databaseId = Convert.ToInt32(reader["id"]);

                    string myUpdateQuery = string.Format("UPDATE  `billholmes54`.`PerformanceGLCubeResults` SET  `FramesPerSecond` =  '{1}' WHERE  `PerformanceGLCubeResults`.`id` ={0} AND  `PerformanceGLCubeResults`.`FramesPerSecond` <{1} LIMIT 1 ;",
                        databaseId, result.FramesPerSecond);

                    myUpdateCommand.CommandText = myUpdateQuery;
                    myUpdateCommand.ExecuteNonQuery();
                }

                else
                {
                    transaction = conn.BeginTransaction();
                    System.Data.Odbc.OdbcCommand myInsertCommand = new System.Data.Odbc.OdbcCommand(mySelectQuery, conn, transaction);

                    string myInsertQuery =
                        string.Format("INSERT INTO `billholmes54`.`PerformanceGLCubeResults` (`id`, `DBDeviceId`, `NumberTriangles`, `FramesPerSecond`, `isMonoTouch`) VALUES (NULL, '{0}', '{1}', '{2}', '{3}');",
                        result.DeviceDatabaseId, result.NumberOfTriangles, result.FramesPerSecond, result.IsMonoTouch ? "1" : "0");

                    myInsertCommand.CommandText = myInsertQuery;
                    myInsertCommand.ExecuteNonQuery();

                    myInsertCommand.CommandText = "select last_insert_id();";
                    databaseId = Convert.ToInt32(myInsertCommand.ExecuteScalar());

                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();

                throw;
            }
            finally
            {
                conn.Close();
            }

            return databaseId;
        }

        public void AddPerformanceCubeResults(List<PerformanceCubeResult> results)
        {
            foreach (PerformanceCubeResult result in results)
            {
                AddPerformanceCubeResult(result);
            }
        }

        private enum GetPerformanceCubeResultsFilter
        {
            All,
            MonoTouch,
            ObjectiveC
        }

        public List<PerformanceCubeResult> GetPerformanceCubeResults()
        {
            return GetPerformanceCubeResults(GetPerformanceCubeResultsFilter.All);
        }

        private List<PerformanceCubeResult> GetPerformanceCubeResults(GetPerformanceCubeResultsFilter filter)
        {
            List<PerformanceCubeResult> cubeResults = new List<PerformanceCubeResult>();

            System.Data.Odbc.OdbcConnection conn = createSQLConnection();
            try
            {
                // 
                string mySelectQuery;
                switch (filter)
                {
                    case GetPerformanceCubeResultsFilter.MonoTouch:
                        mySelectQuery = "SELECT *  FROM `PerformanceGLCubeResults` WHERE `isMonoTouch` = 1 ORDER BY `DBDeviceId` ASC";
                        break;
                    case GetPerformanceCubeResultsFilter.ObjectiveC:
                        mySelectQuery = "SELECT *  FROM `PerformanceGLCubeResults` WHERE `isMonoTouch` = 0 ORDER BY `DBDeviceId` ASC";
                        break;
                    default:
                        mySelectQuery = "SELECT * FROM `PerformanceGLCubeResults` ORDER BY `PerformanceGLCubeResults`.`DBDeviceId` ASC";
                        break;
                }
                System.Data.Odbc.OdbcCommand myCommand = new System.Data.Odbc.OdbcCommand(mySelectQuery, conn);
                conn.Open();
                System.Data.Odbc.OdbcDataReader myReader = myCommand.ExecuteReader();

                try
                {
                    while (myReader.Read())
                    {
                        cubeResults.Add(new PerformanceCubeResult()
                        {
                            DatabaseId = (int)myReader["id"],
                            DeviceDatabaseId = (int)myReader["DBDeviceId"],
                            NumberOfTriangles = (int)myReader["NumberTriangles"],
                            FramesPerSecond = (double)myReader["FramesPerSecond"],
                            IsMonoTouch = Convert.ToBoolean(myReader["isMonoTouch"])
                        });
                    }
                }
                finally
                {
                    myReader.Close();
                }
            }
            finally
            {
                conn.Close();
            }

            return cubeResults;
        }

        public List<PerformanceCubeResult> GetPerformanceCubeResultsForMonoTouch()
        {
            return GetPerformanceCubeResults(GetPerformanceCubeResultsFilter.MonoTouch);
        }

        public List<PerformanceCubeResult> GetPerformanceCubeResultsForObjectiveC()
        {
            return GetPerformanceCubeResults(GetPerformanceCubeResultsFilter.ObjectiveC);
        }

        private static System.Data.Odbc.OdbcConnection createSQLConnection()
        {
            System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection();
#error need password
            conn.ConnectionString = "DRIVER={MySQL ODBC 3.51 Driver}; SERVER=billholmes54.db.9465659.hostedresource.com; PORT=3306; DATABASE=billholmes54; USER=billholmes54; PASSWORD=removed; OPTION=0;";
            return conn;
        }

        public PerformanceCubeResult FindPerformanceCubeResult(int databaseId)
        {
            System.Data.Odbc.OdbcConnection conn = createSQLConnection();
            try
            {
                string selectQuery = string.Format("SELECT * FROM  `PerformanceGLCubeResults` WHERE  `id` ={0}",
                    databaseId);
                conn.Open();
                System.Data.Odbc.OdbcCommand selectCommand = new System.Data.Odbc.OdbcCommand(selectQuery, conn);
                try
                {
                    System.Data.Odbc.OdbcDataReader reader = selectCommand.ExecuteReader();

                    if (!reader.Read())
                        return null;

                    return new PerformanceCubeResult()
                    {
                        DatabaseId = databaseId,
                        DeviceDatabaseId = Convert.ToInt32(reader["DBDeviceId"]),
                        NumberOfTriangles = Convert.ToInt32(reader["NumberTriangles"]),
                        FramesPerSecond = Convert.ToDouble(reader["FramesPerSecond"])
                    };
                }
                catch (Exception)
                {

                }
            }
            finally
            {
                conn.Close();
            }

            return null;
        }

        // used to reset all the tables for this service
        private void clearAllTables()
        {
            //DELETE FROM `PerformanceGLCubeResults`;
            //ALTER TABLE PerformanceGLCubeResults AUTO_INCREMENT = 0;
            //DELETE FROM `PerformanceAppDeviceInfo`;
            //ALTER TABLE PerformanceAppDeviceInfo AUTO_INCREMENT = 0;
            System.Data.Odbc.OdbcConnection conn = createSQLConnection();
            System.Data.Odbc.OdbcTransaction transaction = null;
            try
            {
                string myInsertQuery = "DELETE FROM `PerformanceGLCubeResults`;";

                conn.Open();
                transaction = conn.BeginTransaction();

                System.Data.Odbc.OdbcCommand myCommand = new System.Data.Odbc.OdbcCommand(myInsertQuery, conn, transaction);
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "ALTER TABLE PerformanceGLCubeResults AUTO_INCREMENT = 0;";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "DELETE FROM `PerformanceAppDeviceInfo`;";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "ALTER TABLE PerformanceAppDeviceInfo AUTO_INCREMENT = 0;";
                myCommand.ExecuteNonQuery();

                transaction.Commit();

            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
