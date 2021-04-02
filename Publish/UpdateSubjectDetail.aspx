<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateSubjectDetail.aspx.cs" Inherits="Publish.UpdateSubjectDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>更新主题详细内容</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="color:Red; border: dashed 1px red;">#<%= Request.QueryString["ID"] %></div>
           标题：
        <br />
        <input type="text" name="txtTitle" value="<%# sdi.Title %>" />  <br />
        内容：
        <br />
        <textarea name="txtSubjectDetail" cols="120" rows="10"><%# sdi.Content %></textarea>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="更新当前主题详细信息" 
            onclick="btnAdd_Click" />
        <input type="hidden" value="" id="hidResult" runat="server"/>
            <input id="Button1" type="button" value="退出"  onclick="set();"/>
    </div>
    <script type="text/javascript">
        function set() {

//            var id = '<%= Request.QueryString["ID"] %>';
//            var btn = "btnSubjectDetail" + id;
//            var hid = "hidSubjectDetail" + id;
//            var hidResult = document.getElementById("<%= hidResult.ClientID %>").value;

//            if (hidResult != "") {
//                opener.document.getElementById(btn).value = "更新详细";
//                opener.document.getElementById(hid).value = "Update";
//            }
            self.close();
        }
    </script>
    </form>
</body>
</html>
