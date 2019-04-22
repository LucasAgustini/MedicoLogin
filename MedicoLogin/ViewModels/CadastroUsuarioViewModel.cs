using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicoLogin.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        [MaxLength(20, ErrorMessage = "Maximo 100 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo 2 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres")]
        //[MinLength(6, ErrorMessage = "Minimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme a senha")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres")]
        //[MinLength(6, ErrorMessage = "Minimo 6 caracteres")]
        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage = "Senhas sao diferentes!")]
        public string ConfirmaSenha { get; set; }
    }
}