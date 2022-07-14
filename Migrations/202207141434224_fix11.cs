namespace Inscripcion_Universidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InscripcionMaterias",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Materia_Id = c.Guid(),
                        Estudiante_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estudiantes", t => t.Estudiante_Id)
                .ForeignKey("dbo.Materias", t => t.Materia_Id)
                .Index(t => t.Materia_Id)
                .Index(t => t.Estudiante_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InscripcionMaterias", "Materia_Id", "dbo.Materias");
            DropForeignKey("dbo.InscripcionMaterias", "Estudiante_Id", "dbo.Estudiantes");
            DropIndex("dbo.InscripcionMaterias", new[] { "Estudiante_Id" });
            DropIndex("dbo.InscripcionMaterias", new[] { "Materia_Id" });
            DropTable("dbo.InscripcionMaterias");
        }
    }
}
