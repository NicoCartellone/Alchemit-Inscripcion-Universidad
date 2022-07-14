namespace Inscripcion_Universidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estudiantes", "Materia_Id", c => c.Guid());
            CreateIndex("dbo.Estudiantes", "Materia_Id");
            AddForeignKey("dbo.Estudiantes", "Materia_Id", "dbo.Materias", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estudiantes", "Materia_Id", "dbo.Materias");
            DropIndex("dbo.Estudiantes", new[] { "Materia_Id" });
            DropColumn("dbo.Estudiantes", "Materia_Id");
        }
    }
}
