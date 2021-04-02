<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediaList.aspx.cs" Inherits="Publish.MediaList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>媒体库列表</title>
    <script src="Js/jquery-1.4.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="dlMediaList" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
            <ItemTemplate>
                <%# Eval("HtmlTag")%>
                <br />
                <span style="border: 1px solid gray" id="spanFileName<%# Container.ItemIndex + 1 %>" onclick="selectMedia(<%# Container.ItemIndex + 1 %>)">
                    <%# Eval("FileName") %></span>
                <input id="hidFileExten<%# Container.ItemIndex + 1 %>" type="hidden" value="<%# Eval("FileExten") %>" />
                <input id="hidFileName<%# Container.ItemIndex + 1 %>" type="hidden" value="<%# Eval("FileName") %>" />
                <input id="hidfullFileName<%# Container.ItemIndex + 1 %>" type="hidden" value="<%# Eval("fullFileName") %>" />
                <input id="hidServerFileName<%# Container.ItemIndex + 1 %>" type="hidden" value="<%# Eval("ServerFileName") %>" />
                <input id="hidFileNameWithoutExten<%# Container.ItemIndex + 1 %>" type="hidden" value="<%# Eval("FileNameWithoutExten") %>" />
                <input id="hidSImagePostion<%# Container.ItemIndex + 1 %>" type="hidden" value="<%# Eval("SImagePostion") %>" />
                <input id="hidAImagePostion<%# Container.ItemIndex + 1 %>" type="hidden" value="<%# Eval("AImagePostion") %>" />
            </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
    <script type="text/javascript">

        function selectMedia(seed) {
            var id = '<%= Request.QueryString["ID"] %>';
            var eid = '<%= Request.QueryString["EID"] %>';
            var mid = '<%= Request.QueryString["Mid"] %>';
 
            var tableInfo = "<table><tr>"
            tableInfo += "<td id=\"tdSubjectID\">" + id + "</td>";
            tableInfo += "<td id=\"tdMid\">" + mid + "</td>";
            tableInfo += "<td id=\"tdEid\">" + eid + "</td>";
            tableInfo += "<td id=\"tdFileExten\">" + $("#hidFileExten" + seed).val() + "</td>";
            tableInfo += "<td id=\"tdFileName\">" + $("#hidFileName" + seed).val() + "</td>";
            tableInfo += "<td id=\"tdFullFileName\">" + $("#hidfullFileName" + seed).val() + "</td>";
            tableInfo += "<td id=\"tdServerFileName\">" + $("#hidServerFileName" + seed).val() + "</td>";
            tableInfo += "<td id=\"tdFileNameWithoutExten\">" + $("#hidFileNameWithoutExten" + seed).val() + "</td>";
            tableInfo += "<td id=\"tdSImagePostion\">" + $("#hidSImagePostion" + seed).val() + "</td>";
            tableInfo += "<td id=\"tdAImagePostion\">" + $("#hidAImagePostion" + seed).val() + "</td>";
            tableInfo += "</tr></table>";

            window.returnValue = tableInfo;
            self.close();
        }
    </script>
</body>
</html>
