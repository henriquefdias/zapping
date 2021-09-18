using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zapping.Domain.Interfaces.Repositories;

namespace Zapping.Domain.Commands.Usuario.AdicionarUsuario
{
    public class AdicionarUsuarioHandler : Notifiable, IRequestHandler<AdicionarUsuarioRequest, Response>
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarUsuarioHandler(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Response> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            // Valida se o request esta preenchido
            if (request == null)
            {
                AddNotification("Request", "Informe os dados do usuário.");
                return new Response(this);
            }

            //Verificar se o usuario existe
            if (_repositoryUsuario.Existe(x => x.Email == request.Email))
            {
                AddNotification("Email", "Email já cadastrado no sistema.");
                return new Response(this);
            }

            Entities.Usuario usuario = new Entities.Usuario();

            usuario.PrimeiroNome = request.PrimeiroNome;
            usuario.UltimoNome = request.UltimoNome;
            usuario.Email = request.Email;
            usuario.Senha = request.Senha;

            _repositoryUsuario.Adicionar(usuario);
        }
    }
}
