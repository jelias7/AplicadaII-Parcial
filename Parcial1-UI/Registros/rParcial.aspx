<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="rParcial.aspx.cs" Inherits="Parcial1_UI.Registros.rParcial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="panel panel-primary">
        <div class="panel-body">
             <div class="form-horizontal col-md-12" role="form">
                 <div class="form-group row">
                 <label for="Label1" class="col-sm-1 col-form-label">Label</label>
                 </div>
                 <div class="form-group row">
                 <label for="Label2" class="col-sm-1 col-form-label">Label</label>
                 </div>
                 <div class="form-group row">
                 <label for="Label3" class="col-sm-1 col-form-label">Label</label>
                 </div>
                 <div class="form-group row">
                 <label for="Label4" class="col-sm-1 col-form-label">Label</label>
                 </div>
             </div>
        </div>
        <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                  <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" CausesValidation="false" style="color:#fff" runat="server" ID="NuevoButton" />
                  <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuardarButton" />
                  <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" CausesValidation="false" runat="server" ID="EliminarButton" />

                </div>
            </div>
       </div>
    </div>
</asp:Content>
