using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicoLogin.Models
{
    public class Cidade
    {
        public int CidadeID { get; set; }


        [Required]
        [MaxLength(70)]
        public string Nome { get; set; }

    }
}