using System;
using System.Collections.Generic;

namespace EnterpriseSystems.Infrastructure.Model.Entities
{
    public class CommentVO
    {
        public CommentVO()
        {
            CustomerRequestVO = new List<CustomerRequestVO>();
            Stops = new List<StopVO>();
            ReferenceNumbers = new List<ReferenceNumberVO>();
            Appointments = new List<AppointmentVO>();
        }

        public int Identity { get; set; }
        public string EntityName { get; set; }
        public int EntityIdentity { get; set; }
        public int? SequenceNumber { get; set; }
        public string CommentType { get; set; }
        public string CommentText { get; set; }
        public string RecordStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedUserID { get; set; }
        public string CreatedProgramCode { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string LastUpdatedUserId { get; set; }
        public string LastUpdatedProgramCode { get; set; }


        public List<CustomerRequestVO> CustomerRequest { get; set; }
        public List<StopVO> Stops { get; set; }
        public List<ReferenceNumberVO> ReferenceNumbers { get; set; }
        public List<AppointmentVO> Appointments { get; set; }
    }
}
