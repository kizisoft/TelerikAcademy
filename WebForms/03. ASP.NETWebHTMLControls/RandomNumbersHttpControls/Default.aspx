<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RandomNumbersHttpControls.Default" %>

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
    <div class="panel panel-default col-md-4 col-md-offset-1">
        <form id="RandomNumbersForm" runat="server" class="form-horizontal panel-body">
            <fieldset>
                <legend>Generate random numbers</legend>
                <div class="form-group">
                    <label for="inputMin" class="col-md-4 control-label">Min</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="inputMin" placeholder="Min number" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputMax" class="col-md-4 control-label">Max</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="inputMax" placeholder="Max number" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputCount" class="col-md-4 control-label">Count</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="inputCount" placeholder="Count" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <button class="btn btn-primary pull-right" runat="server" id="ButtonGenerate" onserverclick="Generate_Click">Generate numbers</button>
                    </div>
                </div>
            </fieldset>
        </form>
    </div>
    <div class="panel panel-default col-md-4 col-md-offset-1">
        <div class="form-group">
            <label for="Results" class="col-lg-2 control-label">Results</label>
            <div class="col-lg-10">
                <textarea class="form-control" runat="server" disabled="disabled" rows="11" id="Results" style="resize: none"></textarea>
            </div>
        </div>
    </div>
</body>
</html>
