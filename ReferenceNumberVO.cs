using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class ReferenceNumberVO
    {
        public ReferenceNumberVO()
        {
            CustomerRequestVO = new List<CustomerRequestVO>();
            Stops = new List<StopVO>();
            Comments = new List<CommentVO>();
            Appointments = new List<AppointmentVO>();
        }

        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityIdentity { get; set; }
        public string SEReferencNumberType { get; set; }
        public string RefrenceNumber { get; set; }
        public string RecordStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUserID { get; set; }
        public string CreatedProgramCode { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string LastUpdatedUserId { get; set; }
        public string LastUpdatedProgramCode { get; set; }


        public List<CustomerRequestVO> CustomerRequest { get; set; }
        public List<StopVO> Stops { get; set; }
        public List<CommentVO> Comments { get; set; }
        public List<AppointmentVO> Appointments { get; set; }
    }
}
