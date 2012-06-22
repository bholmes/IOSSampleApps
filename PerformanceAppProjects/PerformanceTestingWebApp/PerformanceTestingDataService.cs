﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace PerformanceTestingWebApp
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
                string myInsertQuery =
                    string.Format("INSERT INTO `billholmes54`.`PerformanceGLCubeResults` (`id`, `DBDeviceId`, `NumberTriangles`, `FramesPerSecond`) VALUES (NULL, '{0}', '{1}', '{2}');",
                    result.DeviceDatabaseId, result.NumberOfTriangles, result.FramesPerSecond);

                conn.Open();
                transaction = conn.BeginTransaction();

                System.Data.Odbc.OdbcCommand myCommand = new System.Data.Odbc.OdbcCommand(myInsertQuery, conn, transaction);
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "select last_insert_id();";
                databaseId = Convert.ToInt32(myCommand.ExecuteScalar());

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

            return databaseId;
        }

        public void AddPerformanceCubeResults(List<PerformanceCubeResult> results)
        {
            foreach (PerformanceCubeResult result in results)
            {
                AddPerformanceCubeResult(result);
            }
        }

        public List<PerformanceCubeResult> GetPerformanceCubeResults()
        {
            List<PerformanceCubeResult> cubeResults = new List<PerformanceCubeResult>();

            System.Data.Odbc.OdbcConnection conn = createSQLConnection();
            try
            {
                // 
                string mySelectQuery = "SELECT * FROM `PerformanceGLCubeResults`;";
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

        private static System.Data.Odbc.OdbcConnection createSQLConnection()
        {
            System.Data.Odbc.OdbcConnection conn = new System.Data.Odbc.OdbcConnection();
#error need password
            conn.ConnectionString = "DRIVER={MySQL ODBC 3.51 Driver}; SERVER=billholmes54.db.9465659.hostedresource.com; PORT=3306; DATABASE=billholmes54; USER=billholmes54; PASSWORD=need password; OPTION=0;";
            return conn;
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
