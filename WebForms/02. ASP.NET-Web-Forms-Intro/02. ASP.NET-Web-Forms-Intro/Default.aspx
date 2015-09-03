<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.ASP.NET_Web_Forms_Intro._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">Hello application</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Hello section</h2>
            <p>
                Hello, ASP.Net! - from ASPX code!
            </p>
            <p>
                <asp:Label Text="" ID="HelloLabel" runat="server" Visible="false" />
            </p>
            <p>
                <asp:Button Text="Click Me" runat="server" OnClick="ShowHello_Click" />
            </p>
        </div>
        <div class="col-md-8">
            <p>
                <br />
                <label>Assembly name: </label>
                <asp:Label ID="AssemblyName" runat="server" Visible="true" />
            </p>
        </div>

    </div>

</asp:Content>
