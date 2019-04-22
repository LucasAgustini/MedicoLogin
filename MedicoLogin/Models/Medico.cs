using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedicoLogin.Models
{
    [Table("Medico")]
    public class Medico
    {
        
        public int MedicoID { get; set; }

        public int EspecialidadeID { get; set; }
        [ForeignKey("EspecialidadeID")]
        public virtual Especialidade Especialidade { get; set; }


        public int CidadeID { get; set; }
        [ForeignKey("CidadeID")]
        public virtual Cidade Cidade { get; set; }


        [Required]
        [MaxLength(10)]
        public string CRM { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Endereco { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public Boolean Convenio { get; set; }

        public Boolean Clinica { get; set; }



      
    }
}