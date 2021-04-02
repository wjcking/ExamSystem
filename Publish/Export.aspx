<%@ Page Title="导出试题图片，数据库" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true"
    CodeBehind="Export.aspx.cs" Inherits="Publish.Export" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="materialLeft">
        当前数据库
        <div style="color: #EE0000">
            <%= Publish.EasyConfig.DBName%></div>
        当前图库目录<br />
        <%= Publish.EasyConfig.ImageLibraryPath%>
        <br />
        重新命名后的图库路径<br />
        <%= Publish.EasyConfig.ImageRenamedLibraryPath%>
        <br />
        <br />
        备份试题图片路径
        <br />
        <%=  ImageBackupPath %>
        <br />
        试题图片路径到debug
        <br />
        <%=  ImageDebugPath %>
        <br />
        试题图片路径到Release
        <br />
        <%=  ImageReleasePath %>
        <br />
        试题图片路径到EFD
        <br />
        <%=  ImageEFDPath %>
        <br />
        <br />
        数据库复制到 debug 项目 扩展名为.dll
        <br />
        <%=  DataBaseDebugPath %>
        <br />
        数据库复制到 EFD 宇宙版项目中 扩展名为.dll
        <br />
        <%=  DataBaseEFDPath %>
        <br />
        <br />
        生成Cid文件到debug
        <br />
        <%=  CidDebugPath %>
        <br />
        生成Cid文件到Release
        <br />
        <%=  CidReleasePath  %>
        <br />
        生成Cid文件到EFD
        <br />
        <%=  CidEFDPath  %>
        <br />
        备份Cid文件到
        <br />
        <%=  CidBackupPath  %>
        <br />
        <br />
    </div>
    <div class="materialRight">
        <asp:TextBox runat="server" ID="txtEfdTitle" Width="200px"></asp:TextBox>
        <asp:Button runat="server" ID="btnCopy" CssClass="TextButton" Text="备份,导出试题图库" OnClick="btnCopy_Click" />
        <br />
        <asp:DropDownList runat="server" ID="drpDatabase" Visible="false">
        </asp:DropDownList>
        <br />
        EFD产品名/产品ID
        <br />
        <input name="txtProductTitle" id="txtProductTitle" type="text" value="<%#  vc.Title %>"
            size="32" />
        <input name="txtProductID" id="txtProductID" type="text" size="8" value="<%#  vc.ProductID %>" />
        <br />
        分类名/Cid
        <br />
        <input name="txtCategory" id="txtCategory" type="text" value="<%#  vc.Category %>"
            size="32" />
        <input name="txtCid" id="txtCid" type="text" size="8" value="<%#  vc.Cid %>" />

        <br />
        机器号：<br />

        <input type="text" name="txtMachineCode" />
        <a href="#" onclick="getCategory();">选择</a>
        <br />
        <asp:Button ID="btnCid" runat="server" CssClass="TextButton" Text="生产Cid文件" OnClick="btnCid_Click" />
        <asp:Button runat="server" ID="btnExportDatabase" CssClass="TextButton" Text="导出数据库(*.dll)"
            OnClick="btnExportDatabase_Click" />
    </div>
    <div id="divCategory">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">

        function getCategory() {
            var result = window.showModalDialog("CidList.htm", null, " dialogHeight=280px; dialogWidth=600px; ");

            if (result == null)
                return;

            $("#divCategory").html(result);

            $("#txtProductTitle").val($("#hidProductTitle").val());
            $("#txtProductID").val($("#hidProductID").val());
            $("#txtCategory").val($("#hidCategory").val());
            $("#txtCid").val($("#hidCid").val());
        }

        function validCid() {

            if ($("#txtProductTitle").val() == "")
                return false;
            if ($("#txtProductID").val() == "")
                return false;
            if ($("#txtCategory").val() == "")
                return false;
            if ($("#txtCid").val() == "")
                return false;
            return true;
        }  
    </script>
</asp:Content>
