namespace Domain.Enums
{
    public enum State
    {
        NotDeleted,
        Deleted
    }
    public enum StatusEnum
    {
        FailedToSave,
        SavedSuccessfully,
        Exception,
        Success,
        Failed,
        FailedToFindTheObject,
        AlreadyExisting
    }
    public enum ActionNameEnum
    {
        Get,
        Post,
        Put,
        Delete,
    }

    public enum CommitteeType
    {
        Committee,
        Council
    }
    public enum CommitteeMember
    {
        External,
        Internal
    }
    public enum CommitteeMemberUser
    {
        User,
        Role
    }
    public enum UserType
    {
        Local,
        Domain
    }
    public enum CommitteeTime
    {
        Always,
        Temporary,
        ProjectTemporary
    }
    public enum CommitteesStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public enum CommitteeFormation
    {
        Internal,
        External
    }
    public enum CommitteeTypeInfo
    {
        Internal,
        External
    }
    public enum MeetingStatus
    {
        Remote,
        Onsite
    }
    public enum ProceedingAcceptance
    {
        Approved,
        Rejected,
        ModificationRequest,
        Reservation
    }
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected,
        RequireEdit,
        Redirected
    }
    public enum ServiceType
    {
        All = 1,
        RequestService = 2,
        ReportService = 3,
        Committee = 4,
        Pmo_Chnages = 5,
        Pmo_CloseProject = 6,
        Pmo_FeasabilityStudyRequest = 7,
        Pmo_HoldRequest = 8,
        Pmo_CancelRequest = 9,
        Pmo_BidRequest = 10,
        AvaliableCoureses = 11,
        UnavaliableCoureses = 12

    }
}