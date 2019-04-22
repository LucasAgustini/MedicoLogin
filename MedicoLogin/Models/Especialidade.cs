using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicoLogin.Models
{
    public class Especialidade
    {
        public int EspecialidadeID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

    }
}