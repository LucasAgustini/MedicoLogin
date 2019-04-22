using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicoLogin.ViewModels
{
    public class CadastroEspecialidadeViewModel
    {
        [Required(ErrorMessage = "Informe a especialidade!")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nome { get; set; }

    }
}