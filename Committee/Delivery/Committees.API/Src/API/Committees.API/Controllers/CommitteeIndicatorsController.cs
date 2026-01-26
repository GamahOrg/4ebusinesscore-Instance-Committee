using Committees.Application.Features.CommitteeIndicators.AllCommitteeData;
using Committees.Application.Features.CommitteeIndicators.IndicatorsOverAll;
using Committees.Application.Features.CommitteeIndicators.MeetingIndicators;
using Committees.Application.Features.CommitteeIndicators.MembersIndicator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Committees.API.Controllers
{
    public class CommitteeIndicatorsController : BaseController
    {
        private readonly IMediator _mediator;

        public CommitteeIndicatorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("IndicatorsOverAll")]
        public async Task<ResponseDTO> IndicatorsOverAll()
        {
            return await _mediator.Send(new IndicatorsOverAllQuery());
        }
        [HttpGet, Route("MeetingIndicators")]
        public async Task<ResponseDTO> MeetingIndicators()
        {
            return await _mediator.Send(new MeetingIndicatorsQuery());
        }
        [HttpGet, Route("MembersIndicator")]
        public async Task<ResponseDTO> MembersIndicator()
        {
            return await _mediator.Send(new MembersIndicatorQuery());
        }

        [HttpGet, Route("AllCommitteeDataIndicators")]
        public async Task<ResponseDTO> AllCommitteeData([FromQuery] AllCommitteeDataQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
