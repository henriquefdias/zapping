﻿using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zapping.Domain.Extensions;
using Zapping.Domain.Interfaces.Repositories;

namespace Zapping.Domain.Commands.Usuario.AutenticarUsuario
{
    public class AutenticarUsuarioHandler : Notifiable, IRequestHandler<AutenticarUsuarioRequest, AutenticarUsuarioResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AutenticarUsuarioHandler(IMediator mediator, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<AutenticarUsuarioResponse> Handle(AutenticarUsuarioRequest request, CancellationToken cancellationToken)
        {
            //Valida se o objeto request esta nulo
            if (request == null)
            {
                AddNotification("Request", "Request é obrigatório");
                return null;
            }

            request.Senha = request.Senha.ConvertToMD5();

            Entities.Usuario usuario = _repositoryUsuario.ObterPor(x => x.Email == request.Email && x.Senha == request.Senha);

            if (usuario == null)
            {
                AddNotification("Usuario", "Usuário não encontrado.");
                return new AutenticarUsuarioResponse()
                {
                    Autenticado = false
                };
            }

            //Cria objeto de resposta
            var response = (AutenticarUsuarioResponse)usuario;

            ////Retorna o resultado
            return await Task.FromResult(response);
        }
    }
}
