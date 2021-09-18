using System;
using Zapping.Domain.Entities.Base;

namespace Zapping.Domain.Entities
{
    public class Envio : EntityBase
    {
        public Campanha Campanha { get; set; }
        public Grupo Grupo { get; set; }
        public Contato Contato { get; set; }
        public bool Enviado { get; set; }
    }
}
