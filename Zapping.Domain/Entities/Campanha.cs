using System;
using Zapping.Domain.Entities.Base;

namespace Zapping.Domain.Entities
{
    public class Campanha : EntityBase
    {
        protected Campanha() { }
        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
    }
}
