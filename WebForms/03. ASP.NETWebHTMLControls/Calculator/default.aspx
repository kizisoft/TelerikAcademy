<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Calculator._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Calculator</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <form id="CalculatorForm" runat="server">
        <br />
        <div class="col-md-4">
            <div class="well well-lg panel panel-default text-center">
                <div class="panel panel-default text-right">
                    <asp:Label Text="" runat="server" ID="Calc" CssClass="panel-body" />
                    <asp:Label Text="" runat="server" ID="Result" OnPreRender="Result_PreRender" CssClass="panel-body" Height="50" Font-Size="X-Large" />
                </div>
                <hr class="alert-info" />
                <div class="panel-body">
                    <div class="col-md-3">
                        <asp:Button Text="1" runat="server" OnClick="ButtonNumber_Click" CssClass="btn btn-info btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="2" runat="server" OnClick="ButtonNumber_Click" CssClass="btn btn-info btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="3" runat="server" OnClick="ButtonNumber_Click" CssClass="btn btn-info btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="+" runat="server" OnClick="ButtonMath_Click" CommandName="plus" CssClass="btn btn-warning btn-lg" />
                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-md-3">
                        <asp:Button Text="4" runat="server" OnClick="ButtonNumber_Click" CssClass="btn btn-info btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="5" runat="server" OnClick="ButtonNumber_Click" CssClass="btn btn-info btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="6" runat="server" OnClick="ButtonNumber_Click" CssClass="btn btn-info btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="-" runat="server" OnClick="ButtonMath_Click" CommandName="minus" CssClass="btn btn-warning btn-lg" />
                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-md-3">
                        <asp:Button Text="7" runat="server" OnClick="ButtonNumber_Click" CssClass="btn btn-info btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="8" runat="server" OnClick="ButtonNumber_Click" CssClass="btn btn-info btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="9" runat="server" OnClick="ButtonNumber_Click" CssClass="btn btn-info btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="*" runat="server" OnClick="ButtonMath_Click" CommandName="mult" CssClass="btn btn-warning btn-lg" />
                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-md-3">
                        <asp:Button Text="Clear" runat="server" OnClick="ButtonClear_Click" CssClass="btn btn-danger btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="0" runat="server" OnClick="ButtonNumber_Click" CssClass="btn btn-info btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="/" runat="server" OnClick="ButtonMath_Click" CommandName="div" CssClass="btn btn-warning btn-lg" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button Text="√" runat="server" OnClick="ButtonMath_Click" CommandName="sqrt" CssClass="btn btn-warning btn-lg" />
                    </div>
                </div>
                <div class="panel-body">
                    <div class="col-md-12">
                        <asp:Button Text="=" runat="server" OnClick="ButtonCalc_Click" CssClass="btn btn-warning btn-lg col-md-12" Width="98%" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
