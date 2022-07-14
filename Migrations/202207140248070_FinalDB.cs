namespace Inscripcion_Universidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistorialAcademicoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdMateria = c.Guid(),
                        FechaExamen = c.DateTime(nullable: false),
                        Nota = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materias", t => t.IdMateria)
                .Index(t => t.IdMateria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistorialAcademicoes", "IdMateria", "dbo.Materias");
            DropIndex("dbo.HistorialAcademicoes", new[] { "IdMateria" });
            DropTable("dbo.HistorialAcademicoes");
        }
    }
}
