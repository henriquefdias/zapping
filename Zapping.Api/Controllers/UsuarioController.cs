using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Zapping.Domain.Commands.Usuario.AdicionarUsuario;
using Zapping.Infra.Repositories.Transactions;

namespace Zapping.Api.Controllers
{
    public class UsuarioController : Base.ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator, IUnitOfWork unitOfWork) :base (unitOfWork)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]AdicionarUsuarioRequest request)
        {

            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        [HttpGet]
        [AllowAnonymous]
        [Route("Get")]
        public string Get()
        {
            return "Chegou um Get";
        }

        [HttpGet]
        [Authorize]
        [Route("GetAuthenticated")]
        public string GetAuthenticated()
        {
            return "Chegou um Get autenticado";
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("Post")]
        public string Post()
        {
            return "Chegou um Post";
        }
        
        [HttpPut]
        [AllowAnonymous]
        [Route("Put")]
        public string Put()
        {
            return "Chegou um Put";
        }
        
        [HttpDelete]
        [AllowAnonymous]
        [Route("delete")]
        public string Delete()
        {
            return "Chegou um delete";
        }
        */

    }
}
