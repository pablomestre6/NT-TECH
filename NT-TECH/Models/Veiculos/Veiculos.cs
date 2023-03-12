using System;
using System.ComponentModel.DataAnnotations;

namespace NT_TECH.Models.Veiculos
{
    public class Veiculos
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = " Placa do veiculo e obrigatorio ")]
        public string? PlacadoVeiculo { get; set; }

        [Required(ErrorMessage = " Essa solicitação e obrigatoria")]
        public string? ModelodoVeiculo { get; set; }

        [Required]
        [Display(Name = "Data de saída")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DateTime { get; set; }
    }
}
