using _4EPlatform.Application.Features.LookUps.LKCommitteeTimeFeature.Command.Delete;
using _4EPlatform.Application.Features.LookUps.LKCommitteeTimeFeature.Command.Post;
using _4EPlatform.Application.Features.LookUps.LKCommitteeTimeFeature.Command.Put;
using Committees.Application.Features.LookUps.LKCommitteeTimeFeature.Command.Post;
using Committees.Application.Features.LookUps.LKCommitteeTimeFeature.Query;

namespace Committees.API.Controllers
{
    public class LKCommitteeTimeController : BaseController
    {
        private readonly IMediator _mediator;
        public LKCommitteeTimeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllLKCommitteeTimeQuery")]
        public async Task<ResponseDTO> GetAllLKCommitteeTimeQuery()
        {
            return await _mediator.Send(new GetAllLKCommitteeTimeQuery());
        }

        [HttpPost("PostLKCommitteeTime")]
        public async Task<ResponseDTO> PostLKCommitteeTime([FromForm] PostLKCommitteeTimeDto dto)
        {
            return await _mediator.Send(new PostLKCommitteeTimeCommand(dto));
        }
        [HttpPut("PutLKCommitteeTime")]
        public async Task<ResponseDTO> PutLKCommitteeTime(int Id, [FromForm] PutLKCommitteeTimeDto Dto)
        {
            return await _mediator.Send(new PutLKCommitteeTimeCommand(Dto, Id));
        }
        [HttpDelete("DeleteLKCommitteeTime")]
        public async Task<ResponseDTO> DeleteLKCommitteeTime(int Id)
        {
            return await _mediator.Send(new DeleteLKCommitteeTimeCommand(Id));
        }
    }
}
