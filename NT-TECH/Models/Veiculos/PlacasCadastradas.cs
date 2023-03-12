using System;

namespace NT_TECH.Models.Veiculos
{
    public class PlacasCadastradas
    {
        public Guid Id { get; set; }

        public string? PlacasCadastrada { get; set; }

        public string? ChavesAtivas { get; set; }

        public string? NaoAtivas { get; set; }
    }
}
