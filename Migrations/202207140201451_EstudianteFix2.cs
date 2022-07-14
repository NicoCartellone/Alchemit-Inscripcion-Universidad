namespace Inscripcion_Universidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstudianteFix2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Estudiantes", "Carrera_Id");
            RenameColumn(table: "dbo.Estudiantes", name: "Carrera_Id1", newName: "Carrera_Id");
            RenameIndex(table: "dbo.Estudiantes", name: "IX_Carrera_Id1", newName: "IX_Carrera_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Estudiantes", name: "IX_Carrera_Id", newName: "IX_Carrera_Id1");
            RenameColumn(table: "dbo.Estudiantes", name: "Carrera_Id", newName: "Carrera_Id1");
            AddColumn("dbo.Estudiantes", "Carrera_Id", c => c.Guid());
        }
    }
}
