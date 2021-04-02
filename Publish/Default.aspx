<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web.Master" CodeBehind="Default.aspx.cs"
    Inherits="Publish._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="materialLeft" style="width: 20%; height: 90%;">
        <asp:TreeView ID="treeFileView" runat="server" OnSelectedNodeChanged="treeFileView_SelectedNodeChanged"
            Font-Size="12px">
        </asp:TreeView>
    </div>
    <div class="materialRight" style="width: 70%;">
      
            <br />
            <div>
                新建题库：
                <input type="text" name="txtNewDB" id="txtNewDB" style="width: 255px;" /><asp:Button
                    ID="btnNewDB" CssClass="TextButton" runat="server" Text="新建数据库" OnClick="btnNewDB_Click" />
            </div>
            <div>
                选择题库：
                <asp:DropDownList ID="drpDatabase" runat="server" Width="255px">
                </asp:DropDownList>
                <asp:Button ID="btnSelectDB" runat="server" Text="选择数据库" CssClass="TextButton" OnClick="btnSelectDB_Click" />
            </div>
            <br />
            <div>
                添加试卷：
                <asp:TextBox ID="txtPaperName" runat="server" Width="250px"></asp:TextBox>
                <asp:Button runat="server" ID="btnAddPaper" Text="添加试卷分类" CssClass="TextButton" OnClick="btnAddPaper_Click">
                </asp:Button>
                <br />
                <asp:Literal runat="server" ID="litInfo" EnableViewState="false"></asp:Literal>
                <iframe id="frame" runat="server" frameborder="0" style="border: 0px; height: 580px;
                    width: 100%;"></iframe>
            </div>
            <div>
            </div>
         
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
