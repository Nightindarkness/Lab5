<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="Teacher.Teacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" style="z-index: 1; top: 95px; position: absolute; height: 30px; width: 83px; left: 119px" Text="Button" />
        <asp:Button ID="Button2" runat="server" style="z-index: 1; left: 22px; top: 95px; position: absolute; height: 30px; width: 82px" Text="Button" />
        <asp:DropDownList ID="students" runat="server" Height="93px" style="z-index: 1; top: 100px; position: absolute; left: 239px">
        </asp:DropDownList>
    
    </div>
    </form>
</body>
</html>
