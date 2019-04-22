namespace MedicoLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        CidadeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.CidadeID);
            
            CreateTable(
                "dbo.Especialidades",
                c => new
                    {
                        EspecialidadeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EspecialidadeID);
            
            CreateTable(
                "dbo.Medico",
                c => new
                    {
                        MedicoID = c.Int(nullable: false, identity: true),
                        EspecialidadeID = c.Int(nullable: false),
                        CidadeID = c.Int(nullable: false),
                        CRM = c.String(nullable: false, maxLength: 10),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Endereco = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Convenio = c.Boolean(nullable: false),
                        Clinica = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MedicoID)
                .ForeignKey("dbo.Cidades", t => t.CidadeID, cascadeDelete: true)
                .ForeignKey("dbo.Especialidades", t => t.EspecialidadeID, cascadeDelete: true)
                .Index(t => t.EspecialidadeID)
                .Index(t => t.CidadeID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 20),
                        Senha = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medico", "EspecialidadeID", "dbo.Especialidades");
            DropForeignKey("dbo.Medico", "CidadeID", "dbo.Cidades");
            DropIndex("dbo.Medico", new[] { "CidadeID" });
            DropIndex("dbo.Medico", new[] { "EspecialidadeID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Medico");
            DropTable("dbo.Especialidades");
            DropTable("dbo.Cidades");
        }
    }
}
