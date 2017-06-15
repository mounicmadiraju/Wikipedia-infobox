<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="wikicontent.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            width: 726px;
            height: 136px;
            }
   
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p>
            <textarea id="TextArea1" runat="server" name="S1"></textarea></p>
        <p>
            &nbsp;</p>
        <p>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 202px" Text="Export" Width="180px" />
        </p>
        <table width="100%">
            <thead>
                <tr>
                    <th width="20%">Title</th>
                    <th>Description</th>
                </tr>
            </thead>
            <tbody id="result" runat="server">
                
            </tbody>
        </table>
    </form>
</body>
</html>
