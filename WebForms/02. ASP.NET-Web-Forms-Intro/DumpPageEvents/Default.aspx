<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DumpPageEvents._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">Dump all the events in the page execution lifecycle</p>
    </div>

    <div class="row">
        <ul class="col-md-4 list-group" runat="server" id="Results">
        </ul>
        <br />
        <div class="col-md-4">
            <asp:Button Text="Show more events" runat="server" ID="Show" CssClass="btn btn-primary btn-lg" OnClick="ButtonShow_Click" OnInit="ButtonShow_Init" OnUnload="ButtonShow_Unload" OnPreRender="ButtonShow_PreRender" OnLoad="ButtonShow_Load" />
        </div>
    </div>

</asp:Content>
