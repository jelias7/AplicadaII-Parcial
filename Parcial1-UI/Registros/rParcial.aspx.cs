using BLL;
using Entidades;
using Parcial1_UI.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1_UI.Registros
{
    public partial class rParcial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IDTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ViewState["Evaluaciones"] = new Evaluaciones();
                BindGrid();
            }
        }
        private void Limpiar()
        {
            IDTextBox.Text = "0";
            EstudianteTextBox.Text = string.Empty;
            CategoriaTextBox.Text = string.Empty;
            ValorTextBox.Text = string.Empty;
            LogradoTextBox.Text = string.Empty;
            TotalTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Today.ToString("yyyy-MM-dd");
            Grid.DataSource = null;
            Grid.DataBind();
        }
        protected void BindGrid()
        {
            if (ViewState["Evaluaciones"] != null)
            {
                Grid.DataSource = ((Evaluaciones)ViewState["Evaluaciones"]).Detalle;
                Grid.DataBind();
            }
        }
        void MostrarMensaje(TiposMensajes tipos, string mensaje)
        {
            Mensaje.Text = mensaje;

            if (tipos == TiposMensajes.Success)
                Mensaje.CssClass = "alert-sucess";

            if (tipos == TiposMensajes.Error)
                Mensaje.CssClass = "alert-danger";

            if (tipos == TiposMensajes.Warning)
                Mensaje.CssClass = "alert-warning";
        }
        private void LlenaCampo(Evaluaciones e)
        {
            ((Evaluaciones)ViewState["Detalle"]).Detalle = e.Detalle;
            IDTextBox.Text = e.EvaluacionId.ToString();
            EstudianteTextBox.Text = e.Estudiante;
            TotalTextBox.Text = e.Total.ToString();
            FechaTextBox.Text = e.Fecha.ToString("yyyy-MM-dd");
            this.BindGrid();
        }

        private Evaluaciones LlenaClase()
        {
            Evaluaciones e = new Evaluaciones();
            e = (Evaluaciones)ViewState["Evaluaciones"];
            e.EvaluacionId = Utils.ToInt(IDTextBox.Text);
            e.Estudiante = EstudianteTextBox.Text;
            e.Total = Utils.ToDecimal(TotalTextBox.Text);
            e.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            return e;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositorioBase<Evaluaciones> Repositorio = new RepositorioBase<Evaluaciones>();
            Evaluaciones evaluacion = new Evaluaciones();

            evaluacion = LlenaClase();

            if (Utils.ToInt(IDTextBox.Text) == 0)
            {
                paso = Repositorio.Guardar(evaluacion);
                Limpiar();
            }
            else
            {
                paso = Repositorio.Modificar(evaluacion);
            }

            if (paso)
            {
                MostrarMensaje(TiposMensajes.Success, "Guardado");
                return;
            }
            else
            {
                MostrarMensaje(TiposMensajes.Error, "Problema");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Evaluaciones> Repositorio = new RepositorioBase<Evaluaciones>();

            var ev = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));
            if (ev != null)
            {
                if (Repositorio.Eliminar(Utils.ToInt(IDTextBox.Text)))
                {
                    MostrarMensaje(TiposMensajes.Success, "Borrado");
                    Limpiar();
                }
                else
                    MostrarMensaje(TiposMensajes.Error, "Error");
            }
            else
                MostrarMensaje(TiposMensajes.Error, "Error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Evaluaciones> Repositorio = new RepositorioBase<Evaluaciones>();
            Evaluaciones ev = new Evaluaciones();

            ev = Repositorio.Buscar(Utils.ToInt(IDTextBox.Text));

            if (ev != null)
                LlenaCampo(ev);
            else
                MostrarMensaje(TiposMensajes.Error, "Error");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void AgregarGrid_Click(object sender, EventArgs e)
        {
            Evaluaciones Evaluaciones = new Evaluaciones();
            Evaluaciones = (Evaluaciones)ViewState["Evaluaciones"];

            decimal Perdido = Utils.ToDecimal(ValorTextBox.Text) - Utils.ToDecimal(LogradoTextBox.Text);

            Evaluaciones.Detalle.Add(new EvaluacionDetalle(CategoriaTextBox.Text,
                Utils.ToDecimal(ValorTextBox.Text),
                Utils.ToDecimal(LogradoTextBox.Text), Perdido));

            ViewState["Detalle"] = Evaluaciones.Detalle;


            this.BindGrid();

            foreach(var item in Evaluaciones.Detalle)
            {
                TotalTextBox.Text = item.Perdido.ToString();
            }
        }

        protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Evaluaciones ev = new Evaluaciones();

            ev = (Evaluaciones)ViewState["Evaluaciones"];

            ViewState["Detalle"] = ev.Detalle;

            int Fila = e.RowIndex;

            ev.Detalle.RemoveAt(Fila);

            this.BindGrid();

            foreach(var item in ev.Detalle)
            {
                TotalTextBox.Text = item.Perdido.ToString();
            }
        }
    }
}