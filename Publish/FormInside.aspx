<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormInside.aspx.cs" Inherits="Publish.FormInside" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="styles/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .editLink
        {
            border: solid 1px gray;
        }
    </style>
</head>
<body style="margin: 0 0 0 0;">
    <form id="form1" runat="server">
    <p style="font-weight: bold">
        <span id="spanPathType" runat="server"></span><a style="color: red" runat="server"
            id="hrefSelectedItem" target="_blank"></a>
    </p>
    <div id="divUpdatePanel" runat="server">
        试题名称：
        <asp:TextBox runat="server" ID="txtMaterialName" EnableViewState="false"></asp:TextBox>
        <br />
        <div style="display:none;">
        考试时间：
        <asp:TextBox runat="server" ID="txtTime" Text="120" EnableViewState="false" MaxLength="65535"></asp:TextBox>
        <br />
        考试内容：
        <asp:TextBox runat="server" ID="txtContent" EnableViewState="false"></asp:TextBox>
        <br /></div>
        其他选项：
        <asp:CheckBox ID="chkCanRandom" runat="server" Checked="true" Text="是否推荐随机" />
        <asp:CheckBox ID="chkIsMaterial" runat="server" Checked="true" Text="是否为试卷" />
        <asp:CheckBox ID="chkRecDisplay" runat="server" Checked="true" Text="是否推荐逐个显示" />
        <div style="text-align: right">
            <br />
            <asp:Button runat="server" ID="btnDel" Text="删除" OnClientClick="return confirm('确定吗??');"
                CssClass="TextButton" OnClick="btnDel_Click" />
            <asp:Button runat="server" ID="btnEdit" Text="更新" OnClick="btnEdit_Click" CssClass="TextButton" />
        </div>
       
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table cellpadding="4" cellspacing="4" style="width: 100%;   border:1px solid;">
            </HeaderTemplate>
            <ItemTemplate>
                <tr >
                    <td>
                        <input type="hidden" runat="server" value='<%#Eval("ID") %>' id="hidIndex" />
                        <span style="color: Red; font-weight: bold;">#<%# Eval("ID")%></span></td>
                    <td>
                        <%# Eval("Subject")%>
                    </td>
                    <td>
                        Point:
                        <%# Eval("EachPoint")%>
                    </td>
                    <td>
                        Number: <span style="font-weight: bold" runat="server" id="spanCount"></span>
                    </td>
                    <td>
                        <asp:Literal runat="server" ID="txtType" Text='<%# Eval("TopicTypeID") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div>
            <div>
                <p>
                </p>
                <a class="editLink" href='Export.aspx'  target="_blank">
                    导出试题图片/数据库       </a>
                    
                     <a class="editLink" href='EditMainSubject.aspx?ExamInfoID=<%= ExamInfoID %>'
                        target="_blank">试卷大题</a>
                        
                         <a class="editLink" href="Figures.aspx?title=" target="_blank">
                            统计试题数目</a> <a class="editLink" href="MaterialList.aspx" target="_blank">编辑文档库</a>
                            
                            
                            <a class="editLink" href="Command.aspx" target="_blank"> 正则与命令</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
