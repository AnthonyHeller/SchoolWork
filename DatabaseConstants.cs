
namespace EnterpriseSystems.Infrastructure.Model.Constants
{
    public class DatabaseConnectionStrings
    {
        public const string Default = "NULL";
    }


    public class CustomerRequestColumnNames
    {
        const int Identity = 0;
        const int Status = 1;
        const int BusinessEntityName = 2;
        const int TypeCode = 3;
        const int ConsumerClassificationType = 4;
        const int CreatedDate = 5;
        const int CreatedUserId = 6;
        const int CreatedProgramCode = 7;
        const int LastUpdatedDate = 8;
        const int LastUpdatedUserId = 9;
        const int LastUpdatedProgramCode = 10;
    }

    public class AppointmentColumnsNames
    {
        const int Identity = 0;
        const int EntityName = 1;
        const int EntityIdentity = 2;
        const int SequenceNumber = 3;
        const int FunctionType = 4;
        const int AppointmentBegin = 5;
        const int AppointmentEnd = 6;
        const int TimezoneDescription = 7;
        const int Status = 8;
        const int RecordStatus = 9;
        const int CreatedDate = 10;
        const int CreatedUserId = 11;
        const int CreatedProgramCode = 12;
        const int LastUpdatedDate = 13;
        const int LastUpdatedUserId = 14;
        const int LastUpdatedProgramCode = 15;
    }

    public class StopColumnsNames
    {
        const int Identity = 0;
        const int EntityName = 1;
        const int EntityIdentity = 2;
        const int RoleType = 3;
        const int StopNumber = 4;
        const int CustomerAlias = 5;
        const int OrganizationName = 6;
        const int AddressLine1 = 7;
        const int AddressLine2 = 8;
        const int AddressCityName = 9;
        const int AddressStateCode = 10;
        const int AddressCountryCode = 11;
        const int AddressPostalCode = 12;
        const int RecordStatus = 13;
        const int CreatedDate = 14;
        const int CreatedUserId = 15;
        const int CreatedProgramCode = 16;
        const int LastUpdatedDate = 17;
        const int LastUpdatedUserId = 18;
        const int LastUpdatedProgramCode = 19;
    }

    public class CommentsColumnsNames
    {
        const int Identity = 0;
        const int EntityName = 1;
        const int EntityIdentity = 2;
        const int SequenceNumber = 3;
        const int CommentType = 4;
        const int CommentText = 5;
        const int RecordStatus = 6;
        const int CreatedDate = 7;
        const int CreatedUserId = 8;
        const int CreatedProgramCode = 9;
        const int LastUpdatedDate = 10;
        const int LastUpdatedUserId = 11;
        const int LastUpdatedProgramCode = 12;
    }
    

    public class ReferenceNumberColumnsNames
    {
        const int Identity = 0;
        const int EntityName = 1;
        const int EntityIdentity = 2;
        const int SoutheasternReferenceNumberType = 3;
        const int ReferenceNumber = 4;
        const int RecordStatus = 5;
        const int CreatedDate = 6;
        const int CreatedUserId = 7;
        const int CreatedProgramCode = 8;
        const int LastUpdatedDate = 9;
        const int LastUpdatedUserId = 10;
        const int LastUpdatedProgramCode = 11;
    }

}
