namespace Inscripcion_Universidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estudiantes", "HistorialAcademico_Id", c => c.Guid());
            CreateIndex("dbo.Estudiantes", "HistorialAcademico_Id");
            AddForeignKey("dbo.Estudiantes", "HistorialAcademico_Id", "dbo.HistorialAcademicoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estudiantes", "HistorialAcademico_Id", "dbo.HistorialAcademicoes");
            DropIndex("dbo.Estudiantes", new[] { "HistorialAcademico_Id" });
            DropColumn("dbo.Estudiantes", "HistorialAcademico_Id");
        }
    }
}
