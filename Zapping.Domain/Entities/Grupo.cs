using System;
using Zapping.Domain.Entities.Base;
using Zapping.Domain.Enums;

namespace Zapping.Domain.Entities
{
    public class Grupo : EntityBase
    {
        public Grupo()
        {
        }

        public Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public EnumNicho Nicho { get; set; }
    }
}
