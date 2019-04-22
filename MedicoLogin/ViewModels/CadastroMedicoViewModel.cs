using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicoLogin.ViewModels
{
    public class CadastroMedicoViewModel
    {

        [Required(ErrorMessage = "Informe o CRM")]
        [MaxLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Endereco { get; set; }


    }
}