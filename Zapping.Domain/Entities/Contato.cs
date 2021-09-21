using Zapping.Domain.Entities.Base;
using Zapping.Domain.Enums;

namespace Zapping.Domain.Entities
{
    public class Contato : EntityBase
    {
        protected Contato() { }
        public Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public EnumNicho Nicho { get; set; }
    }
}
