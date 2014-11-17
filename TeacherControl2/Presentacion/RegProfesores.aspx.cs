using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace RegEstudiantes.Presentacion
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        BLL.Profesores profesores = new BLL.Profesores();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ProfesorId"] != null)
            {
                Buscar(int.Parse(Request.QueryString["ProfesorId"]));
            }

        }

        const string AREA = "809,829,849";
        const int ANO_INICIALD = 1978;
        const int INICIAL_MATRICULA = 0;

        public bool validar()
        {
            bool retorno = false;
            string mensaje1 = "", mensaje2 = "", mensaje3 = "", mensaje4 = "", mensaje5 = "", mensaje6 = "", mensaje7 = "";
            string direccionEmail = "";
            if (NombreTextBox.Text.Length == 0)
                mensaje1 = "El nombre no puede estar vacio";
            else
                mensaje1 = "";
            if (ApellidoTextBox.Text.Length == 0)
                mensaje1 = "El Apellido no puede estar vacio";
            else
                mensaje1 = "";
            if (DireccionTextBox.Text.Length == 0)
                mensaje2 = "La direccion no puede estar vacio";
            else
                mensaje2 = "";
            if (SexoDropDownList.SelectedIndex == -1)
                mensaje3 = "El Sexo no ha sido selecionado";
            else
                mensaje3 = "";

            direccionEmail = EmailTextBox.Text;

            int arroba;
            int punto;

            if (direccionEmail.Length == 0)
                mensaje4 = "Email no puede estar vacio";


            else if (direccionEmail.IndexOf("@") == -1)
                mensaje4 = "El campo tiene que tener @";

            else if (direccionEmail.IndexOf(".") == -1)
                mensaje4 = "El Campo tiene que tener .";
            else
            {

                arroba = direccionEmail.IndexOf("@");
                punto = direccionEmail.IndexOf(".");
                if (punto - arroba > 4)
                    mensaje4 = "";
                else mensaje4 = "Verifique su correo";
            }

            string areatelefono;


            areatelefono = TelefonoTextBox.Text.Substring(0, 3);


            if (TelefonoTextBox.Text.Length != 12)
                mensaje5 = "Telefono incompleto";
            else if (!AREA.Contains(areatelefono))
                mensaje5 = "El area del telefono esta incorrecto ";
            else mensaje5 = "";

            areatelefono = CelularTextBox.Text.Substring(0, 3);


            if (CelularTextBox.Text.Length != 12)
                mensaje6 = "Telefono incompleto";
            else if (!AREA.Contains(areatelefono))
                mensaje6 = "El area del telefono esta incorrecto ";
            else mensaje6 = "";

            if (mensaje1 == "" && mensaje2 == "" && mensaje3 == "" && mensaje4 == "" && mensaje5 == "" && mensaje6 == "" && mensaje7 == "")
                retorno = true;
            return retorno;
        }

        public void Limpiar()
        {
            IdProfesorTextBox.Text = "";
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            SexoDropDownList.SelectedIndex = 0;
            DireccionTextBox.Text = "";
            FechaNacTextBox.Text = "";
            EmailTextBox.Text = "";
            TelefonoTextBox.Text = "";
            CelularTextBox.Text = "";
        }


        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (validar() == true)
            {
                int idprofesores = 0;
                int.TryParse(IdProfesorTextBox.Text, out idprofesores);
                profesores.IdProfesor = idprofesores;
                profesores.Nombres = NombreTextBox.Text;
                profesores.Apellidos = ApellidoTextBox.Text;
                profesores.Direccion = DireccionTextBox.Text;
                profesores.FechaNacimiento = Convert.ToDateTime(FechaNacTextBox.Text);
                profesores.Genero = Convert.ToByte(SexoDropDownList.SelectedIndex);
                profesores.Email = EmailTextBox.Text;
                profesores.Telefono1 = TelefonoTextBox.Text;
                profesores.Telefono2 = CelularTextBox.Text;
                if (idprofesores == 0)
                    profesores.Insertar();
                else
                    profesores.Modificar();
                Limpiar();
            }
        }

        void Buscar(int idprofesor)
        {
            profesores.IdProfesor = idprofesor;
            if (profesores.Buscar() == true)
            {

                NombreTextBox.Text = profesores.Nombres;
                ApellidoTextBox.Text = profesores.Apellidos;
                DireccionTextBox.Text = profesores.Direccion;
                FechaNacTextBox.Text = profesores.FechaNacimiento.ToString("yyyy-MM-dd");
                SexoDropDownList.SelectedIndex = profesores.Genero;
                EmailTextBox.Text = profesores.Email;
                TelefonoTextBox.Text = profesores.Telefono1;
                CelularTextBox.Text = profesores.Telefono2;
            }
            else
                Limpiar();
        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (IdProfesorTextBox.Text.Length > 0)
            {
                int idprofesor = 0;
                int.TryParse(IdProfesorTextBox.Text, out idprofesor);
                profesores.IdProfesor = idprofesor;
                profesores.Eliminar();
            }

            Limpiar();

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
       {
            int idprofesor = 0;
            int.TryParse(IdProfesorTextBox.Text, out idprofesor);
            Buscar(idprofesor);
        }

        protected void IdProfesorTextBox_TextChanged(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IdProfesorTextBox.Text, out id);
            profesores.IdProfesor = id;
            if (profesores.Buscar() == false)
            {
                IdProfesorTextBox.Text = "";
            }
        }
    }
}