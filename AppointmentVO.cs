using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class AppointmentVO
    {
        public AppointmentVO()
        {
            CustomerRequestVO = new List<CustomerRequestVO>();
            Comments = new List<CommentVO>();
            ReferenceNumbers = new List<ReferenceNumberVO>();
            Stops = new List<StopVO>();
        }

        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityIdentity { get; set; }
        public int? SequenceNumber { get; set; }
        public string FunctionType { get; set; }
        public DateTime? AppointmentBegin { get; set; }
        public DateTime? AppointmentEnd { get; set; }
        public string TimezoneDescript { get; set; }
        public string Status { get; set; }
        public string RecordStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateduserID { get; set; }
        public string CreatedProgramCode { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string LastUpdatedUserId { get; set; }
        public string LastUpdatedProgramCode { get; set; }


        public List<CustomerRequestVO> CustomerRequest { get; set; }
        public List<CommentVO> Comments { get; set; }
        public List<ReferenceNumberVO> ReferenceNumbers { get; set; }
        public List<StopVO> Stops { get; set; }
    }
}
