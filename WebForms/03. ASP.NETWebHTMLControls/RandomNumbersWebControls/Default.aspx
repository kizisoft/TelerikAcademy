<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RandomNumbersWebControls.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random Numbers Generator</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <br />

    <form id="RandomNumbersForm" runat="server" class="form-horizontal panel-body">
        <div class="panel panel-default col-md-4 col-md-offset-1">
            <fieldset>
                <legend>Generate random numbers</legend>
                <div class="form-group">
                    <asp:Label Text="Min" AssociatedControlID="InputMin" runat="server" CssClass="col-md-4 control-label" />
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="InputMin" TextMode="Number" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Max" AssociatedControlID="InputMax" runat="server" CssClass="col-md-4 control-label" />
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="InputMax" TextMode="Number" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label Text="Count" AssociatedControlID="InputCount" runat="server" CssClass="col-md-4 control-label" />
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="InputCount" TextMode="Number" CssClass="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <asp:Button Text="Generate numbers" runat="server" OnClick="Generate_Click" CssClass="btn btn-primary pull-right" />
                    </div>
                </div>
            </fieldset>
        </div>
        <div class="panel panel-default col-md-4 col-md-offset-1">
            <div class="form-group">
                <asp:Label Text="Results" runat="server" AssociatedControlID="Results" CssClass="col-lg-2 control-label" />
                <div class="col-lg-10">
                    <asp:TextBox runat="server" ID="Results" TextMode="MultiLine" Columns="50" Rows="9" CssClass="form-control" ReadOnly="true" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
