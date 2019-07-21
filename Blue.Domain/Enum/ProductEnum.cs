using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Blue.Domain
{
    public enum ProductEnum
    {
        [Description("Crédito Pessoal")]
        CP,
        [Description("Cartão")]
        Cartao,
        [Description("Seguro")]
        Seguro,
        [Description("Limite de Crédito")]
        Limite,
        [Description("Atualização Cadastral")]
        AtualizacaoCadastral
    }
}
