﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zapping.Domain.Commands.Usuario.AutenticarUsuario
{
    public class AutenticarUsuarioRequest : IRequest<AutenticarUsuarioResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
