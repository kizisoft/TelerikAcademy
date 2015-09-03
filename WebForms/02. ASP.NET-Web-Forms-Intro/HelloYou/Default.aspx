<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelloYou._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">Hello Application</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <section id="loginForm">
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-6 control-label">First Name</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" TextMode="SingleLine" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="SecondName" CssClass="col-md-6 control-label">Second Name</asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="SecondName" CssClass="form-control" TextMode="SingleLine" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6 pull-right">
                            <asp:Button runat="server" OnClick="ShowName_Click" Text="Say Hello" CssClass="btn btn-primary btn-lg" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
        <div class="col-md-4">
            <asp:PlaceHolder runat="server" ID="ResultMessage" Visible="false">
                <div class="alert alert-dismissable alert-info">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    Hello, <strong><asp:Literal runat="server" ID="Message" /></strong>!
                </div>
            </asp:PlaceHolder>
        </div>
    </div>

</asp:Content>
