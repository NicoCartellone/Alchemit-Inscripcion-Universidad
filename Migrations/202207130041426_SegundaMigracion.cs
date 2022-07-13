namespace Inscripcion_Universidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaMigracion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estudiantes", "Materia_Id", "dbo.Materias");
            DropIndex("dbo.Estudiantes", new[] { "Materia_Id" });
            DropColumn("dbo.Estudiantes", "IdMateria");
            DropColumn("dbo.Estudiantes", "Materia_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estudiantes", "Materia_Id", c => c.Guid());
            AddColumn("dbo.Estudiantes", "IdMateria", c => c.Int(nullable: false));
            CreateIndex("dbo.Estudiantes", "Materia_Id");
            AddForeignKey("dbo.Estudiantes", "Materia_Id", "dbo.Materias", "Id");
        }
    }
}
