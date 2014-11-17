using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegEstudiantes.Presentacion
{
    public partial class ConsProfesores : System.Web.UI.Page
    {
        string filtro = "1=1";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (ProfesoresDropDownList.SelectedIndex == 1)
                filtro += "and Nombres like '%" + BuscarTextBox.Text + "%'";
            else if (ProfesoresDropDownList.SelectedIndex == 2)
                filtro += "and Apellidos like '%" + BuscarTextBox.Text + "%'";

            DatosGridView.DataSource = BLL.Profesores.StaticListar(filtro);
            DatosGridView.DataBind();
        }
    }
}