﻿using EnterpriseSystems.Infrastructure.Model.Constants;
using EnterpriseSystems.Infrastructure.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EnterpriseSystems.Infrastructure.DAO
{
    public class SqlServerDAO
    {
        public CustomerRequestVO GetCustomerRequestByIdentity(int customerRequestIdentity)
        {
            string selectQueryStatement = "SELECT * FROM CUS_REQ WHERE CUS_REQ_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionStrings.Default))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.Identity, customerRequestIdentity);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

                var customerRequestByIdentity = BuildCustomerRequests(queryResult).FirstOrDefault();

                return customerRequestByIdentity;
            }
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestsByReferenceNumber(string referenceNumber)
        {
            string selectQueryStatement = "SELECT A.* FROM CUS_REQ A, REQ_ETY_REF_NBR B WHERE "
                                    + "B.ETY_NM = 'CUS_REQ' AND B.ETY_KEY_I = A.CUS_REQ_I AND "
                                    + "B.REF_NBR = @REF_NBR";

             using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionStrings.Default))
                {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.Identity, referenceNumber);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }
				var customerRequestsByReferenceNumber = BuildCustomerRequests(queryResult);

                return customerRequestsByReferenceNumber;
			    }
        }

        public IEnumerable<CustomerRequestVO> GetCustomerRequestsByReferenceNumberAndBusinessName(string referenceNumber, string businessName)
        {
            string selectQueryStatement = "SELECT A.* FROM CUS_REQ A, REQ_ETY_REF_NBR B WHERE "
                        + "A.BUS_UNT_KEY_CH = @BUS_UNT_KEY_CH AND B.ETY_NM = 'CUS_REQ' "
                        + "AND B.ETY_KEY_I = A.CUS_REQ_I AND B.REF_NBR = @REF_NBR";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionStrings.Default))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.Identity, referenceNumber, businessName);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }

            }
            var customerRequestsByReferenceNumberAndBusinessName = BuildCustomerRequests(queryResult);

            return customerRequestsByReferenceNumberAndBusinessName;
        }

        private List<CustomerRequestVO> BuildCustomerRequests(DataTable dataTable)
        {
            var customerRequests = new List<CustomerRequestVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var customerRequest = new CustomerRequestVO
                {
                    Identity = (int)currentRow[CustomerRequestColumnNames.Identity],
                    Status = currentRow[CustomerRequestColumnNames.Status].ToString(),
                    BusinessEntityKey = currentRow[CustomerRequestColumnNames.BusinessEntityName].ToString(),
                    TypeCode = currentRow[CustomerRequestColumnNames.TypeCode].ToString(),
                    ConsumerClassificationType = currentRow[CustomerRequestColumnNames.ConsumerClassificationType].ToString(),
                    CreatedDate = (DateTime?)currentRow[CustomerRequestColumnNames.CreatedDate],
                    CreatedUserId = currentRow[CustomerRequestColumnNames.CreatedUserId].ToString(),
                    CreatedProgramCode = currentRow[CustomerRequestColumnNames.CreatedProgramCode].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow[CustomerRequestColumnNames.LastUpdatedDate],
                    LastUpdatedUserId = currentRow[CustomerRequestColumnNames.LastUpdatedUserId].ToString(),
                    LastUpdatedProgramCode = currentRow[CustomerRequestColumnNames.LastUpdatedProgramCode].ToString()
                };

                customerRequest.Appointments = GetAppointmentsByCustomerRequest(customerRequest);
                customerRequest.Comments = GetCommentsByCustomerRequest(customerRequest);
                customerRequest.ReferenceNumbers = GetReferenceNumbersByCustomerRequest(customerRequest);
                customerRequest.Stops = GetStopsByCustomerRequest(customerRequest);
                customerRequests.Add(customerRequest);
            }

            return customerRequests;
        }


        private List<AppointmentVO> GetAppointmentsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_SCH WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionStrings.Default))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.Identity, customerRequest);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }
            }

            var appointmentByCustomerRequest = BuildAppointments(queryResult);

            return appointmentByCustomerRequest;

            throw new NotImplementedException();


        }

        private List<AppointmentVO> BuildAppointments(DataTable dataTable)
        {
            var Appointments = new List<AppointmentVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var Appointment = new AppointmentVO
                {
                    Identity = (int)currentRow[AppointmentColumnsNames.Identity],
                    EntityName = currentRow[AppointmentColumnsNames.EntityName].ToString(),
                    EntityIdenty = (int)currentRow[AppointmentColumnsNames.EntityIdenty],
                    SequenceNumber = (int)currentRow[AppointmentColumnsNames.SequenceNumber],
                    FunctionType = currentRow[AppointmentColumnsNames.FunctionType].ToString(),
                    AppointmentBegin = (DateTime?)currentRow[AppointmentColumnsNames.AppointmentBegin],
                    AppointmentEnd = (DateTime?)currentRow[AppointmentColumnsNames.AppointmentEnd],
                    TimezoneDescript = currentRow[AppointmentColumnsNames.TimezoneDescript].ToString(),
                    Status = currentRow[AppointmentColumnsNames.Status].ToString(),
                    RecordStatus = currentRow[AppointmentColumnsNames.RecordStatus].ToString(),
                    CreatedDate = (DateTime?)currentRow[AppointmentColumnsNames.CreatedDate],
                    CreatedUserId = currentRow[AppointmentColumnsNames.CreatedUserId].ToString(),
                    CreatedProgramCode = currentRow[AppointmentColumnsNames.CreatedProgramCode].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow[AppointmentColumnsNames.LastUpdatedDate],
                    LastUpdatedUserId = currentRow[AppointmentColumnsNames.LastUpdatedUserId].ToString(),
                    LastUpdatedProgramCode = currentRow[AppointmentColumnsNames.LastUpdatedProgramCode].ToString()
                };
            }
            return Appointment;

            throw new NotImplementedException();
        }


        private List<CommentVO> GetCommentsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionStrings.Default))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.Identity, customerRequest);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }
            }
            var commentsByCustomerRequest = BuildComments(queryResult);

            return commentsByCustomerRequest;

            throw new NotImplementedException();
        }


        private List<CommentVO> BuildComments(DataTable dataTable)
        {
            var Comments = new List<CommentVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var Comment = new CommentVO
                {
               Identity = (int)currentRow[CommentColumnNames.Identity],
               EntityName = currentRow[CommentColumnNames.EntityName].ToString(),
               EntityIdentity = (int)currentRow[CommentColumnNames.EntityIdentity],
               SequenceNumber = (int)currentRow[CommentColumnNames.SequenceNumber],
               CommentType = currentRow[CommentColumnNames.CommentType].ToString(),
               CommentText = currentRow[CommentColumnNames.CommentText].ToString(),
               RecordStatus = currentRow[CommentColumnNames.RecordStatus].ToString(),
               CreatedDate = (DateTime)currentRow[CommentColumnNames.CreatedDate],
               CreatedUserId = currentRow[CommentColumnNames.CreatedUserId].ToString(),
               CreatedProgramCode = currentRow[CommentColumnNames.CreatedProgramCode].ToString(),
               LastUpdatedDate = (DateTime)currentRow[CommentColumnNames.LastUpdatedDate],
               LastUpdatedUserId = currentRow[CommentColumnNames.LastUpdatedUserId].ToString(),
               LastUpdatedProgramCode = currentRow[CommentColumnNames.LastUpdatedProgramCode].ToString()
                
                };
            }
            return Comment;

            throw new NotImplementedException();
        }


        private List<ReferenceNumberVO> GetReferenceNumbersByCustomerRequest(CustomerRequestVO customerRequest)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_REF_NBR WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionStrings.Default))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.Identity, customerRequest);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }
            }
            //var referenceNumbersByCustomerRequest = BuildReferenceNumbers(queryResult);

            throw new NotImplementedException();
        }


        private List<ReferenceNumberVO> BuildReferenceNumbers(DataTable dataTable)
        {
            var ReferenceNumbers = new List<ReferenceNumberVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
                var ReferenceNumber = new ReferenceNumberVO
                {
                    Identity = (int)currentRow[ReferenceNumberColumnsNames.Identity],
                    EntityName = currentRow[ReferenceNumberColumnsNames.EntityName].ToString(),
                    EntityIdentity = (int)currentRow[ReferenceNumberColumnsNames.EntityIdentity],
                    SoutheasternReferenceNumberType = (int)currentRow[ReferenceNumberColumnsNames.SoutheasternReferenceNumberType],
                    ReferenceNumber = currentRow[ReferenceNumberColumnsNames.RefrenceNumber].ToString(),
                    RecordStatus = currentRow[ReferenceNumberColumnsNames.RecordStatus].ToString(),
                    CreatedDate = (DateTime?)currentRow[ReferenceNumberColumnsNames.CreatedDate],
                    CreatedUserId = currentRow[ReferenceNumberColumnsNames.CreatedUserId].ToString(),
                    CreatedProgramCode = currentRow[ReferenceNumberColumnsNames.CreatedProgramCode].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow[ReferenceNumberColumnsNames.LastUpdatedDate],
                    LastUpdatedUserId = currentRow[ReferenceNumberColumnsNames.LastUpdatedUserId].ToString(),
                    LastUpdatedProgramCode = currentRow[ReferenceNumberColumnsNames.LastUpdatedProgramCode].ToString()
                };
            }
            return ReferenceNumbers;

            throw new NotImplementedException();
        }


        private List<StopVO> GetStopsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_OGN WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionStrings.Default))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.Identity, customerRequest);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }
            }
            //var stopsByCustomerRequest = BuildStops(queryResult);

            throw new NotImplementedException();
        }


        private List<StopVO> BuildStops(DataTable dataTable)
        {
            var Stops = new List<StopVO>();

            foreach (DataRow currentRow in dataTable.Rows)
            {
               var Stop = new StopVO
                {
                    Identity = (int)currentRow[StopColumnNames.Identity],
                    EntityName = currentRow[StopColumnNames.Status].ToString(),
                    EntityIdentity = (int)currentRow[StopColumnNames.EntityIdentity],
                    RoleType = currentRow[StopColumnNames.RoleType].ToString(),
                    StopNumber = currentRow[StopColumnNames.TypeCode].ToString(),
                    CustomerAlias = currentRow[StopColumnNames.ConsumerClassificationType].ToString(),
                    OrganizationName = currentRow[StopColumnNames.LastUpdatedProgramCode].ToString(),
                    AddressLine1 = currentRow[StopColumnNames.CreatedUserId].ToString(),
                    AddressLine2 = currentRow[StopColumnNames.CreatedProgramCode].ToString(),
                    AddressCityName = currentRow[StopColumnNames.LastUpdatedProgramCode].ToString(),
                    AddressStateCode = currentRow[StopColumnNames.LastUpdatedUserId].ToString(),
                    AddressCountryCode = currentRow[StopColumnNames.LastUpdatedProgramCode].ToString(),
                    AddressPostalCode = currentRow[StopColumnNames.LastUpdatedProgramCode].ToString(),
                    RecordStatus = currentRow[StopColumnNames.LastUpdatedProgramCode].ToString(),
                    CreatedDate = (DateTime?)currentRow[StopColumnNames.CreatedDate],
                    CreatedUserId = currentRow[StopColumnNames.LastUpdatedProgramCode].ToString(),
                    CreatedProgramCode = currentRow[StopColumnNames.LastUpdatedProgramCode].ToString(),
                    LastUpdatedDate = (DateTime?)currentRow[StopColumnNames.CreatedDate],
                    LastUpdatedUserId = currentRow[StopColumnNames.LastUpdatedProgramCode].ToString(),
                    LastUpdatedProgramCode = currentRow[StopColumnNames.LastUpdatedProgramCode].ToString(),
                };

        
            }
            return Stops;
            

            throw new NotImplementedException();
        }


        private List<AppointmentVO> GetAppointmentsByStop(StopVO stop)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_SCH WHERE ETY_NM = 'REQ_ETY_OGN' AND ETY_KEY_I = @REQ_ETY_OGN_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionStrings.Default))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.Identity, stop);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }
            }
            //var appointmentsByStop = BuildAppointments(queryResult);

            throw new NotImplementedException();
        }


        private List<CommentVO> GetCommentsByStop(StopVO stop)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'REQ_ETY_OGN' AND ETY_KEY_I = @REQ_ETY_OGN_I";

            using (SqlConnection defaultSqlConnection = new SqlConnection(DatabaseConnectionStrings.Default))
            {
                defaultSqlConnection.Open();
                DataTable queryResult = new DataTable();

                using (SqlCommand queryCommand = new SqlCommand(selectQueryStatement, defaultSqlConnection))
                {
                    queryCommand.Parameters.AddWithValue(CustomerRequestQueryParameters.Identity, customerRequest);
                    var sqlReader = queryCommand.ExecuteReader();
                    queryResult.Load(sqlReader);
                }
            }
            //var commentsByStop = BuildComments(queryResult);

            throw new NotImplementedException();
        }
    }
}
