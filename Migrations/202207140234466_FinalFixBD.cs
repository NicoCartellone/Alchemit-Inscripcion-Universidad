namespace Inscripcion_Universidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalFixBD : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Materias", "IdCarrera");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materias", "IdCarrera", c => c.Guid(nullable: false));
        }
    }
}
