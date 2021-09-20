using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zapping.Domain.Commands.Usuario.AdicionarUsuario.Notifications
{
    public class AvisarAdministradores : INotificationHandler<AdicionarUsuarioNotification>
    {
        public async Task Handle(AdicionarUsuarioNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Chamar webservice que avisa sobre cadastro de novo usuario: " + notification.Usuario.PrimeiroNome);
        }
    }
}
