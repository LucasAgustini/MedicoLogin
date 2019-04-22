using MedicoLogin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MedicoLogin.DAO
{

    public class EFContext : DbContext
    {


        //tabelas bd
        public DbSet <Usuario> Usuarios { get; set; }
        public DbSet <Especialidade> Especialidades { get; set; }
        public DbSet <Medico> Medicos { get; set; }
        public DbSet <Cidade> Cidades { get; set; }

    }
}