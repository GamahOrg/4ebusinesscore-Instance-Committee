using Committees.Application.Features.Committees.Queries.GetAllInternalMembers;
using Committees.Application.Features.Committees.Queries.GetAllWithServiceType;
using Committees.Application.Features.Committees.Queries.NotGetApprovedCommitteeById;
using Committees.Application.Features.Proceedings.Command.Put;
using Committees.Application.Features.Proceedings.Queries.GetById;

namespace Committees.API.Controllers
{
    public class CommitteeController : BaseController
    {
        private readonly IMediator _mediator;

        public CommitteeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #region Committee

        [HttpPost]
        [Route("PostCommittee")]
        public Task<ResponseDTO> PostCommittee([FromForm] PostCommitteeDto postCommitteeDto)
        {
            return _mediator.Send(new PostCommitteeCommand { CommitteeDto = postCommitteeDto });
        }

        [HttpGet]
        [Route("GetAllCommitteesPaginated")]
        public async Task<ResponseDTO> GetAllCommitteesPaginated(int pageNumber, int pageSize, string? searchTerm)
        {
            var query = new GetAllCommitteesPaginatedQuery(pageNumber, pageSize, searchTerm);
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("GetAllCommittees")]
        public async Task<ResponseDTO> GetAllCommittees()
        {
            var query = new GetAllCommitteesQuery();
            return await _mediator.Send(query);
        }
        [HttpGet]
        [Route("GetAllCommitteesWithServiceType")]
        public async Task<ResponseDTO> GetAllCommitteesWithServiceType([FromQuery] GetAllWithServiceTypeQuery query)
        {

            return await _mediator.Send(query);
        }
        [HttpGet, Route("GetCommitteeById/{committeeId}")]
        public async Task<ResponseDTO> GetCommitteeById(Guid committeeId) => await _mediator.Send(new GetCommitteeByIdQuery(committeeId));

        [HttpGet, Route("GetNotApprovedCommitteeById/{committeeId}")]
        public async Task<ResponseDTO> GetNotApprovedCommitteeById(Guid committeeId) => await _mediator.Send(new GetNotApprovedCommitteeByIdQuery(committeeId));


        [HttpGet, Route("GetCommitteeTimeTable/{committeeId}")]
        public async Task<ResponseDTO> GetCommitteeTimeTable(Guid committeeId) => await _mediator.Send(new GetCommitteeTimeTableQuery() { CommitteeId = committeeId });

        [HttpPut("PutCommittee/{committeeId}")]
        public Task<ResponseDTO> PutCommittee([FromForm] PutCommitteeDto putCommitteeDto, Guid committeeId)
        {
            return _mediator.Send(new PutCommitteeCommand { CommitteeId = committeeId, CommitteeDto = putCommitteeDto });
        }
        [HttpPut("PutCommitteeMember/{memberId}")]
        public async Task<ResponseDTO> PutCommitteeMember([FromRoute] Guid memberId, [FromBody] PutExternalMemberCommand command)
        {
            command.ExternalMemberId = memberId;
            return await _mediator.Send(command);
        }

        [HttpPut("ChangeCommitteeStatus/{committeeId}")]
        public async Task<ResponseDTO> ChangeCommitteeStatus([FromRoute] Guid committeeId, [FromBody] UpdateRequestStatusCommand command)
        {
            command.CommitteeId = committeeId;
            return await _mediator.Send(command);
        }

        //[HttpPut("AssignWorkflowToCommittee")]
        //public async Task<ResponseDTO> AssignWorkflowToCommittee(AssignWorkflowToCommitteeCommand command)
        //{
        //    return await _mediator.Send(command);
        //}

        [HttpDelete("DeleteCommittee/{committeeId}")]
        public Task<ResponseDTO> DeleteCommittee(Guid committeeId)
        {
            return _mediator.Send(new DeleteCommitteeCommand() { CommitteeId = committeeId });
        }

        [HttpDelete("DeleteCommitteeMember/{memberId}")]
        public Task<ResponseDTO> DeleteCommitteeMember(Guid memberId)
        {
            return _mediator.Send(new DeleteExternalMemberCommand() { ExternalMemberId = memberId });
        }

        #endregion

        #region ProceedingMember
        [HttpPost]
        [Route("PostProceedingMembers")]
        public Task<ResponseDTO> PostProceedingMembers([FromBody] PostProceedingMembersCommand command)
        {
            return _mediator.Send(command);
        }

        [HttpPut("PutProceedingMemberAttendence")]
        public async Task<ResponseDTO> PutProceedingMemberAttendence(PutProceedingMemberAttendenceCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("PutProceedingMemberAcceptance")]
        public async Task<ResponseDTO> PutProceedingMemberAcceptance(PutProceedingMemberAcceptanceCommand command)
        {
            return await _mediator.Send(command);
        }
        #endregion

        #region Meetings
        [HttpPost]
        [Route("PostMeeting")]
        public Task<ResponseDTO> PostMeeting([FromForm] PostMeetingDto postMeetingDto)
        {
            return _mediator.Send(new PostMeetingCommand { MeetingDto = postMeetingDto });
        }

        [HttpGet]
        [Route("GetAllMeetings")]
        public async Task<ResponseDTO> GetAllMeetings()
        {
            var query = new GetAllMeetingsQuery();
            return await _mediator.Send(query);
        }

        [HttpGet, Route("GetMeetingsByCommitteeId/{committeeId}")]
        public async Task<ResponseDTO> GetMeetingsByCommitteeId(Guid committeeId) => await _mediator.Send(new GetMeetingsByCommitteeIdQuery(committeeId));


        [HttpGet, Route("GetMeetingById/{meetingId}")]
        public async Task<ResponseDTO> GetMeetingById(Guid meetingId) => await _mediator.Send(new GetMeetingByIdQuery(meetingId));
        #endregion

        [HttpGet, Route("GetMeetingByName/{meetingName}")]
        public async Task<ResponseDTO> GetMeetingByName(string meetingName) => await _mediator.Send(new GetMeetingByNameQuery(meetingName));


        #region Proceedings

        [HttpPost]
        [Route("PostProceeding")]
        public Task<ResponseDTO> PostProceeding([FromForm] PostProceedingDto postProceedingDto)
        {
            return _mediator.Send(new PostProceedingCommand { ProceedingDto = postProceedingDto });
        }

        [HttpPut]
        [Route("PutProceeding")]
        public Task<ResponseDTO> PostProceeding([FromForm] PutProceedingCommand putProceedingDto)
        {
            return _mediator.Send(putProceedingDto);
        }

        [HttpGet, Route("GetProceedingsByCommitteeId/{committeeId}")]
        public async Task<ResponseDTO> GetProceedingsByCommitteeId(Guid committeeId) => await _mediator.Send(new GetProceedingByCommitteeIdQuery(committeeId));

        [HttpGet, Route("GetProceedingById/{proceedingId}")]
        public async Task<ResponseDTO> GetProceedingId(Guid proceedingId) => await _mediator.Send(new GetProceedingByIdQuery(proceedingId));


        [HttpGet]
        [Route("GetAllProceedings")]
        public async Task<ResponseDTO> GetAllProceedings()
        {
            return await _mediator.Send(new GetAllProceedingsQuery());
        }
        #endregion

        [HttpGet]
        [Route("GetAllInternals")]
        public async Task<ResponseDTO> GetAllInternals([FromQuery] GetAllInternalMembersQuery request)
        {
            return await _mediator.Send(request);
        }


        #region OutPut

        [HttpPost]
        [Route("PostOutput")]
        public Task<ResponseDTO> PostOutput([FromForm] PostOutputDto postOutputDto)
        {
            return _mediator.Send(new PostOutputCommand { OutputDto = postOutputDto });
        }
        #endregion

    }
}
