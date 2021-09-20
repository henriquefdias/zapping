using prmToolkit.NotificationPattern;
using System;
using Zapping.Domain.Entities.Base;
using Zapping.Domain.Extensions;

namespace Zapping.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario(string primeiroNome, string ultimoNome, string email, string senha)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Email = email;
            Senha = senha;

            new AddNotifications<Usuario>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 150, "O primeiro nome deve conter de 3 a 150 caracteres.")
                .IfNullOrInvalidLength(x => x.UltimoNome, 3, 150)
                .IfNotEmail(x => x.Email)
                .IfNullOrInvalidLength(x => x.Senha, 3, 32);

            if(!string.IsNullOrEmpty(this.Senha))
            {
                this.Senha = Senha.ConvertToMD5();
            }

            DataCadastro = DateTime.Now;
            Ativo = false;
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; private set; }

    }
}
