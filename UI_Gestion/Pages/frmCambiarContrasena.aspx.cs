using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI_Gestion.Code;
using PCL_Gestion.str;
using PCL_Gestion.dao;

namespace UI_Gestion.Pages
{
    public partial class frmCambiarContrasena : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            strUsuarioSistema str = new strUsuarioSistema();
            daoUsuariosSistema dao = new daoUsuariosSistema(this.GetStringConnection);
            str = dao.GetObject(this.GetUserName);

            if (txtContrasenaActual.Text != str.Password)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "alert('La contraseña no coincide con la contraseña actual.');", true);
            }
            else if (txtContrasenaNueva.Text != txtConfirmarContrasenaNueva.Text)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "alert('Favor de confirmar la nueva contraseña, no coinciden.');", true);
            }
            else
            {
                str.Password = txtConfirmarContrasenaNueva.Text;
                int update = dao.Update(str);
                if (update == 1)
                {
                    txtContrasenaActual.Text = "";
                    txtContrasenaNueva.Text = "";
                    txtConfirmarContrasenaNueva.Text = "";
                    ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "alert('La nueva contraseña ha cambiado exitosamente.');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "alert('Error: Reporte al departamento de sistemas.');", true);
            }
        }
    }
}