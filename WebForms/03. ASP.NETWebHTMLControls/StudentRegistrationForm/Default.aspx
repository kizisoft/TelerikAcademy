<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentRegistrationForm.Default" ValidateRequest="false" %>

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
    <form id="studentRegistrationform" runat="server" class="form-horizontal">
        <h1 class="text-center">Student Registration Form</h1>
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label Text="First name" runat="server" AssociatedControlID="TextBoxFirstName" CssClass="col-md-4 control-label" />
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="TextBoxFirstName" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Last name" runat="server" AssociatedControlID="TextBoxLastName" CssClass="col-md-4 control-label" />
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="TextBoxLastName" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Faculty number" runat="server" AssociatedControlID="TextBoxFacultyNumber" CssClass="col-md-4 control-label" />
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="TextBoxFacultyNumber" CssClass="form-control" TextMode="SingleLine" MaxLength="15" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="University" runat="server" AssociatedControlID="DropDownUniversity" CssClass="col-md-4 control-label" />
                        <div class="col-md-8">
                            <asp:DropDownList runat="server" ID="DropDownUniversity" CssClass="form-control">
                                <asp:ListItem Text="" Value="default" />
                                <asp:ListItem Text="Sofia University" Value="uni1" />
                                <asp:ListItem Text="Technical University" Value="uni2" />
                                <asp:ListItem Text="Free University" Value="uni3" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Specialty" runat="server" AssociatedControlID="DropDownSpecialty" CssClass="col-md-4 control-label" />
                        <div class="col-md-8">
                            <asp:DropDownList runat="server" ID="DropDownSpecialty" CssClass="form-control">
                                <asp:ListItem Text="" Value="default" />
                                <asp:ListItem Text="Computer Sciences" Value="spec1" />
                                <asp:ListItem Text="Telecommunications" Value="spec2" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Courses" runat="server" AssociatedControlID="ListBoxCourses" CssClass="col-md-4 control-label" />
                        <div class="col-md-8">
                            <asp:ListBox runat="server" ID="ListBoxCourses" CssClass="form-control" SelectionMode="Multiple">
                                <asp:ListItem Text="Web Forms" Value="course1" />
                                <asp:ListItem Text="C# Part I" Value="course2" />
                                <asp:ListItem Text="C# Part II" Value="course3" />
                                <asp:ListItem Text="Web Api" Value="course4" />
                            </asp:ListBox>
                        </div>
                    </div>
                    <div class="pull-right">
                        <asp:Button Text="Clear" runat="server" OnClick="ButtonClear_Click" CssClass="btn btn-default" />
                        <asp:Button Text="Create student" runat="server" OnClick="ButtonCreateStudent_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <asp:PlaceHolder runat="server" ID="PlaceHolderResult" Visible="false" />
        </div>
    </form>
</body>
</html>
