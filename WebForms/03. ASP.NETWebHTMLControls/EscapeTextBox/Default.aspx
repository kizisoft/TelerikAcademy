<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EscapeTextBox.Default" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <form id="form1" runat="server">
        <h1 class="text-center">Move the text</h1>
        <hr />
        <div class="row">
            <div class="col-md-4 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">Source</div>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:Label Text="Input a text" AssociatedControlID="InputText" runat="server" CssClass="col-md-12 control-label" />
                            <asp:TextBox runat="server" ID="InputText" TextMode="MultiLine" Columns="40" Rows="10" CssClass="form-control" />
                        </div>
                        <div class="form-group pull-right">
                            <asp:Button Text="Submit" runat="server" CssClass="btn btn-primary" OnClick="Submit_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">Target</div>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:Label Text="Text Box Control" AssociatedControlID="TextBoxResult" runat="server" CssClass="col-md-12 control-label" />
                            <asp:TextBox runat="server" ID="TextBoxResult" TextMode="MultiLine" Columns="40" Rows="10" CssClass="form-control" ReadOnly="true" />
                        </div>
                        <div class="form-group">
                            <asp:Label Text="Label Control" runat="server" AssociatedControlID="LabelResult" CssClass="col-md-12 control-label" />
                            <div class="form-control" style="overflow-x: hidden; overflow-y: auto; word-wrap: break-word; height: 200px;">
                                <asp:Literal Text="" runat="server" ID="LabelResult" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
