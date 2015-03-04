﻿using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class StopVO
    {
        public StopVO()
        {
            CustomerRequestVO = new List<CustomerRequestVO>();
            Comments = new List<CommentVO>();
            ReferenceNumbers = new List<ReferenceNumberVO>();
            Appointments = new List<AppointmentVO>();
        }

        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityIdentity { get; set; }
        public string RoleType { get; set; }
        public string StopNumber { get; set; }
        public string CustomerAlias { get; set; }
        public string OrganizationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCityName { get; set; }
        public string AddressStateCode { get; set; }
        public string AddressCountryCode { get; set; }
        public string AddressPostalCode { get; set; }
        public string RecordStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUserID { get; set; }
        public string CreatedProgramCode { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string LastUpdatedUserId { get; set; }
        public string LastUpdatedProgramCode { get; set; }


        public List<CustomerRequestVO> CustomerRequest { get; set; }
        public List<CommentVO> Comments { get; set; }
        public List<ReferenceNumberVO> ReferenceNumbers { get; set; }
        public List<AppointmentVO> Appointments { get; set; }
    }
}
