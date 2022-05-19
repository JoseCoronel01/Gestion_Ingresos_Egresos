namespace UI_Gestion.Data
{
    public class UI_GestionContext : System.Data.Entity.DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public UI_GestionContext() : base() { }

        public System.Data.Entity.DbSet<UI_Gestion.Models.strBanco> strBanco { get; set; }

        public System.Data.Entity.DbSet<UI_Gestion.Models.strConcepto> strConcepto { get; set; }

        public System.Data.Entity.DbSet<UI_Gestion.Models.strImpuesto> strImpuesto { get; set; }

        public System.Data.Entity.DbSet<UI_Gestion.Models.strRecibo> strRecibo { get; set; }

        public System.Data.Entity.DbSet<UI_Gestion.Models.strTipoEgresoIngreso> strTipoEgresoIngreso { get; set; }

        public System.Data.Entity.DbSet<UI_Gestion.Models.strSubTipoEgresoIngreso> strSubTipoEgresoIngreso { get; set; }

        public System.Data.Entity.DbSet<UI_Gestion.Models.strTipoReferencia> strTipoReferencia { get; set; }

        public System.Data.Entity.DbSet<UI_Gestion.Models.strReferencia> strReferencias { get; set; }

        public System.Data.Entity.DbSet<UI_Gestion.Models.strContacto> strContacto { get; set; }

        public System.Data.Entity.DbSet<UI_Gestion.Models.strUsuarioSistema> strUsuarioSistema { get; set; }
    }
}