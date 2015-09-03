<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SearchCarsWebForm.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Cars</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/styles.css" rel="stylesheet" />
</head>
<body>
    <br />
    <form id="SearchCarsForm" runat="server" class="form-horizontal">
        <fieldset>
            <legend>Search Cars Form</legend>
            <div class="col-md-5">
                <div class="form-group">
                    <label class="col-md-3 control-label">Car producer</label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DropDownListProducers" DataTextField="Name" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Model</label>
                    <div class="col-md-9">
                        <asp:DropDownList ID="DropDownListModels" DataTextField="Name" OnPreRender="DropDownListModels_PreRender" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Extras</label>
                    <asp:CheckBoxList ID="CheckBoxListExtras" DataTextField="Name" runat="server" CssClass="col-md-9 checkbox"></asp:CheckBoxList>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Engine</label>
                    <asp:RadioButtonList ID="RadioButtonListEngine" runat="server" CssClass="col-md-9 radio" RepeatDirection="Horizontal"></asp:RadioButtonList>
                </div>
                <div class="pull-right">
                    <asp:Button Text="Submit" OnClick="ButtonSubmit_Click" runat="server" CssClass="btn btn-primary" />
                </div>
            </div>
            <asp:Panel ID="PanelResult" runat="server" CssClass="col-md-4 col-md-offset-1" Visible="false">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Your selection
                    </div>
                    <div class="panel-body">
                        <asp:Literal Text="" ID="LiteralResult" runat="server" />
                    </div>
                </div>
            </asp:Panel>
        </fieldset>
    </form>

    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
