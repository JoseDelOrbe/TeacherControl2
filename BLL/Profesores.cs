using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class Profesores
    {
        public int IdProfesor { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Direccion { set; get; }
        public byte Genero { set; get; }
        public DateTime FechaNacimiento { set; get; }
        public string Email { set; get; }
        public string Telefono1 { set; get; }
        public string Telefono2 { set; get; }

        ConexionDb conexion = new ConexionDb();

        /// <summary>
        /// Insertar Profesores.....
        /// </summary>
        public bool Insertar()
        {
            return conexion.EjecutarDB("insert into Profesores(Nombres, Apellidos, Direccion, Genero, FechaNacimiento, Email, Telefono1, Telefono2)Values('" + this.Nombres + "','" + this.Apellidos + "','" + this.Direccion + "'," + this.Genero + ",'" + this.FechaNacimiento.ToString("MM/dd/yyyy HH:mm:ss") + "','" + this.Email + "','" + this.Telefono1 + "','" + this.Telefono2 + "')");
        }

        /// <summary>
        /// Eliminar Profesores.....
        /// </summary>
        public bool Eliminar()
        {
            return conexion.EjecutarDB("Delete from Profesores where IdProfesor = " + IdProfesor);
        }

        /// <summary>
        /// Modificar Profesores.....
        /// </summary>
        public bool Modificar()
        {
            return conexion.EjecutarDB("Update Profesores set Nombres='" + this.Nombres + "', Apellidos='" + this.Apellidos + "' , Direccion= '" + this.Direccion + "', Genero=" + this.Genero + ", FechaNacimiento='" + this.FechaNacimiento.ToString("MM/dd/yy HH:mm:ss") + "', Email='" + this.Email + "', Telefono1='" + this.Telefono1 + "', Telefono2='" + this.Telefono2 + "' Where IdProfesor = " + this.IdProfesor);
        }



        /// <summary>
        /// Buscar Profesores.....
        /// </summary>
        public bool Buscar()
        {
            bool Mensaje = false;
            DataTable dt;      

            dt = conexion.BuscarDb("Select * from Profesores Where IdProfesor=" + IdProfesor);

            if (dt.Rows.Count > 0)
            {
                Mensaje = true;
                this.IdProfesor = (int)dt.Rows[0]["IdProfesor"];
                this.Nombres = (string)dt.Rows[0]["Nombres"];
                this.Apellidos = (string)dt.Rows[0]["Apellidos"];
                this.Direccion = (string)dt.Rows[0]["Direccion"];
                this.Genero = (byte)dt.Rows[0]["Genero"];
                this.FechaNacimiento = (DateTime)dt.Rows[0]["FechaNacimiento"];
                this.Email = (string)dt.Rows[0]["Email"];
                this.Telefono1 = (string)dt.Rows[0]["Telefono1"];
                this.Telefono2 = (string)dt.Rows[0]["Telefono2"];

            }
            return Mensaje;
        }

        public static DataTable StaticListar(string condicion)
        { //ugly fix temporal
            ConexionDb conexion = new ConexionDb();
            return conexion.BuscarDb("select * from Profesores where " + condicion);
        }

        public static DataTable Listar(string columnas, string condicion)
        {
            ConexionDb conexion = new ConexionDb();
            return conexion.BuscarDb("select " + columnas + " from Profesores where " + condicion);
        }
    }
}
