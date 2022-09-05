<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="ProyectoPeluqueriaFinal.Account.OpenAuthProviders" %>

<div id="socialLoginList">
    <h4>Utilice otro servicio para iniciar sesión.</h4>
    <hr />
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default" name="provider" value="<%#: Item %>"
                    title="Log in using your <%#: Item %> account.">
                    <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <p>No hay servicios de autenticación externos configurados. Ver<a href="https://go.microsoft.com/fwlink/?LinkId=252803">
                   este articulo</a> para obtener detalles sobre cómo configurar esta aplicación ASP.NET para admitir el inicio de sesión a través de servicios externos.</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</div>
