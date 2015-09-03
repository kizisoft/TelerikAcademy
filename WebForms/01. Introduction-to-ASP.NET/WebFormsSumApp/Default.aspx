<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsSumApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">Sum tow numbers - Web Forms Application</p>
    </div>

    <div class="row">
        <div class="col-md-8">
            <h2>Sum numbers</h2>
            <div class="col-md-8">
                <section id="loginForm">
                    <div class="form-horizontal">
                        <asp:PlaceHolder runat="server" ID="ResultMessage" Visible="false"> 
                            <p class="text-danger">
                                Result =
                                <asp:Literal runat="server" ID="Message" />
                            </p>
                        </asp:PlaceHolder>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="FirstNumber" CssClass="col-md-6 control-label">First Number</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox runat="server" ID="FirstNumber" CssClass="form-control" TextMode="Number" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstNumber"
                                    CssClass="text-danger" ErrorMessage="The First Number field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="SecondNumber" CssClass="col-md-6 control-label">Second Number</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox runat="server" ID="SecondNumber" CssClass="form-control" TextMode="Number" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="SecondNumber"
                                    CssClass="text-danger" ErrorMessage="The Second Number field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" OnClick="Calc" Text="Calculate" CssClass="btn btn-primary btn-lg" />
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>

</asp:Content>
