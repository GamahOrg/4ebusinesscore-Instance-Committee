using _4EPlatform.Application.Features.LookUps.LKProceedingAcceptanceFeature.Command.Delete;
using _4EPlatform.Application.Features.LookUps.LKProceedingAcceptanceFeature.Command.Post;
using _4EPlatform.Application.Features.LookUps.LKProceedingAcceptanceFeature.Command.Put;
using Committees.Application.Features.LookUps.LKProceedingAcceptanceFeature.Command.Post;
using Committees.Application.Features.LookUps.LKProceedingAcceptanceFeature.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Committees.API.Controllers
{
    public class LKProceedingAcceptanceController : BaseController
    {
        private readonly IMediator _mediator;
        public LKProceedingAcceptanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllLKProceedingAcceptanceQuery")]
        public async Task<ResponseDTO> GetAllLKProceedingAcceptanceQuery()
        {
            return await _mediator.Send(new GetAllLKProceedingAcceptanceQuery());
        }

        [HttpPost("PostLKProceedingAcceptance")]
        public async Task<ResponseDTO> PostLKProceedingAcceptance([FromForm] PostLKProceedingAcceptanceDto dto)
        {
            return await _mediator.Send(new PostLKProceedingAcceptanceCommand(dto));
        }
        [HttpPut("PutLKProceedingAcceptance")]
        public async Task<ResponseDTO> PutLKProceedingAcceptance(int Id, [FromForm] PutLKProceedingAcceptanceDto Dto)
        {
            return await _mediator.Send(new PutLKProceedingAcceptanceCommand(Dto, Id));
        }
        [HttpDelete("DeleteLKProceedingAcceptance")]
        public async Task<ResponseDTO> DeleteLKProceedingAcceptance(int Id)
        {
            return await _mediator.Send(new DeleteLKProceedingAcceptanceCommand(Id));
        }
    }
}
