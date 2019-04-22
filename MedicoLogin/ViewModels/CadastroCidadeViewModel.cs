using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicoLogin.ViewModels
{
    public class CadastroCidadeViewModel
    {
        [Required(ErrorMessage = "Informe o nome da cidade!")]
        [MaxLength(70, ErrorMessage = "Maximo 70 caracteres")]
        public string Nome { get; set; }

    }
}