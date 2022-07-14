namespace Inscripcion_Universidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstudianteFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estudiantes", "Carrera_Id", "dbo.Carreras");
            DropIndex("dbo.Estudiantes", new[] { "Carrera_Id" });
            AddColumn("dbo.Estudiantes", "Carrera_Id1", c => c.Guid());
            CreateIndex("dbo.Estudiantes", "Carrera_Id1");
            AddForeignKey("dbo.Estudiantes", "Carrera_Id1", "dbo.Carreras", "Id");
            DropColumn("dbo.Estudiantes", "IdCarrera");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estudiantes", "IdCarrera", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Estudiantes", "Carrera_Id1", "dbo.Carreras");
            DropIndex("dbo.Estudiantes", new[] { "Carrera_Id1" });
            DropColumn("dbo.Estudiantes", "Carrera_Id1");
            CreateIndex("dbo.Estudiantes", "Carrera_Id");
            AddForeignKey("dbo.Estudiantes", "Carrera_Id", "dbo.Carreras", "Id");
        }
    }
}
