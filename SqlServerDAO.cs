using EnterpriseSystems.Infrastructure.Model.Constants;
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
        public IEnumerable<CustomerRequestVO> GetCustomerRequestByIdentity(int customerRequestIdentity)
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

            //...
            //Connection, command, add parameters, execute query
            //...
            //var customerRequestsByReferenceNumberAndBusinessName = BuildCustomerRequests(queryResult);

            throw new NotImplementedException();
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

            //...
            //Connection, command, add parameter using customerRequest.Identity, execute query
            //...
            //var appointmentsByCustomerRequest = BuildAppointments(queryResult);

            throw new NotImplementedException();
        }

        private List<AppointmentVO> BuildAppointments(DataTable dataTable)
        {
            foreach (DataRow currentRow in dataTable.Rows)
            {
                //...
                //Hydrate AppointmentVO
                //...
            }

            throw new NotImplementedException();
        }


        private List<CommentVO> GetCommentsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            //...
            //Connection, command, add parameter using customerRequest.Identity, execute query
            //...
            //var commentsByCustomerRequest = BuildComments(queryResult);

            throw new NotImplementedException();
        }

        private List<CommentVO> BuildComments(DataTable dataTable)
        {
            foreach (DataRow currentRow in dataTable.Rows)
            {
                //...
                //Hydrate CommentVO
                //...
            }

            throw new NotImplementedException();
        }


        private List<ReferenceNumberVO> GetReferenceNumbersByCustomerRequest(CustomerRequestVO customerRequest)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_REF_NBR WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            //...
            //Connection, command, add parameter using customerRequest.Identity, execute query
            //...
            //var referenceNumbersByCustomerRequest = BuildReferenceNumbers(queryResult);

            throw new NotImplementedException();
        }

        private List<ReferenceNumberVO> BuildReferenceNumbers(DataTable dataTable)
        {
            foreach (DataRow currentRow in dataTable.Rows)
            {
                //...
                //Hydrate ReferenceNumberVO
                //...
            }

            throw new NotImplementedException();
        }


        private List<StopVO> GetStopsByCustomerRequest(CustomerRequestVO customerRequest)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_OGN WHERE ETY_NM = 'CUS_REQ' AND ETY_KEY_I = @CUS_REQ_I";

            //...
            //Connection, command, add parameter using customerRequest.Identity, execute query
            //...
            //var stopsByCustomerRequest = BuildStops(queryResult);

            throw new NotImplementedException();
        }

        private List<StopVO> BuildStops(DataTable dataTable)
        {
            foreach (DataRow currentRow in dataTable.Rows)
            {
                //...
                //Hydrate StopVO
                //...
            }

            throw new NotImplementedException();
        }


        private List<AppointmentVO> GetAppointmentsByStop(StopVO stop)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_SCH WHERE ETY_NM = 'REQ_ETY_OGN' AND ETY_KEY_I = @REQ_ETY_OGN_I";

            //...
            //Connection, command, add parameter using stop.Identity, execute query
            //...
            //var appointmentsByStop = BuildAppointments(queryResult);

            throw new NotImplementedException();
        }

        private List<AppointmentVO> GetCommentsByStop(StopVO stop)
        {
            string selectQueryStatement = "SELECT * FROM REQ_ETY_CMM WHERE ETY_NM = 'REQ_ETY_OGN' AND ETY_KEY_I = @REQ_ETY_OGN_I";

            //...
            //Connection, command, add parameter using stop.Identity, execute query
            //...
            //var commentsByStop = BuildComments(queryResult);

            throw new NotImplementedException();
        }
    }
}
