<%@ Page Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="EditFill.aspx.cs"
    Inherits="Publish.EditFill" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <%--  左边--%>
        <div id="materialLeft" class="materialLeft" style="width: 288px">
       <%--     大题题目：<br />--%>
            <asp:DropDownList ID="drpMainSubject" runat="server" Width="260px" Visible="false">
            </asp:DropDownList>
            <div style="text-align: right;display:none;">
                <br />
                <input type="button" value="定位" onclick="LocateModel()" />
                <asp:Button ID="btnCategory" runat="server" Text="更新勾选分类" 
                    CssClass="TextButton" onclick="btnCategory_Click" />
            </div>
            <p>
                单个问题：
                <br />
                <asp:TextBox runat="server" ID="txtSubject" TextMode="MultiLine" Width="260px" />
            </p>
            <p>
                单个答案：<br />
                <asp:TextBox runat="server" ID="txtKey" Width="260px" />
            </p>
            <div style="text-align: right">
                <asp:Button ID="btnBefore" runat="server" Text="勾选试题前" CssClass="TextButton" OnClick="btnGenerate_Click"
                    OnClientClick="return IsValid()" />
                <asp:Button ID="btnAfter" runat="server" Text="勾选试题后" CssClass="TextButton" OnClick="btnGenerate_Click"
                    OnClientClick="return IsValid()" />
            </div>
            <p>
                批量问题添加（每个换行符为一个）<br />
                <asp:TextBox runat="server" ID="txtBatchSubject" Width="260px" Height="67px" 
                    TextMode="MultiLine" />
            </p>
            <div style="text-align: right">
                &nbsp;<asp:Button ID="btnBatchAdd" runat="server" Text="批量添加" CssClass="TextButton" OnClientClick="return IsValid()"
                    OnClick="btnBatchAdd_Click" />
            </div>
            
                 <p>
            批量答案添加<br />
             <asp:TextBox runat="server" ID="txtBatchKey" Width="260px"  Height="50px" TextMode="MultiLine" />
            </p>
             <div style="text-align: right">
              
                <asp:Button ID="btnBatchAddKey" runat="server" Text="批量答案更新" 
                     CssClass="TextButton" onclick="btnBatchAddKey_Click"    />
            </div> 
        </div>
    </div>
    <%--   右边   --%>
    <div id="materialRight" class="materialRight">
    　填空题总数：<%= dgList.Rows.Count.ToString() %>
        <div style="text-align: right">
            <asp:GridView ID="dgList" BorderWidth="0px" runat="server" AutoGenerateColumns="false"
                OnRowDeleting="dgList_RowDeleting">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDel" CommandName="Delete">
                            <input type="hidden" runat="server" value='<%#Eval("ID") %>' id="hidIndex" />
                            <img alt="del" src="/images/del.gif" style="vertical-align:middle;" /> </asp:LinkButton>
                            <asp:CheckBox runat="server" ID="chk" />
                            <%#Container.DataItemIndex +1%>：
                            <asp:TextBox ID="txtSubject" runat="server" Text='<%# Eval("Subject")%>' Width="260px" />
                            答案：
                            <asp:TextBox runat="server" ID="txtKey" Width="130px" Text='<%# Eval("Key") %>' />
                       
                   
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <input id="checkAll" type="checkbox" onclick="CheckAll(this.checked, 'chk')" />全选
            <input id="checkAdv" type="checkbox" onclick="AdvCheck('chk')" />反选&nbsp;
                <asp:Button ID="btnDeleteByCategory" runat="server" Text="删除所选分类" 
                    CssClass="TextButton" onclick="btnDeleteByCategory_Click" OnClientClick="return confirm('确定吗？')" />
            <asp:Button ID="btnUpdate" runat="server" Text="更新试题" OnClick="btnUpdate_Click"   CssClass="TextButton"/>
        </div>
    </div>
     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">

    <script type="text/javascript">
//window.onload =  ResetInputText();
function IsValid()
{
//    var txtSubject  = document.getElementById('<%= drpMainSubject.ClientID %>');
//    var txtContent  = document.getElementById('<%= txtSubject.ClientID %>');
//    
//    
//    if (txtSubject.value == "")
//    {
//        alert("请输入大题题目。");
//        txtSubject.focus();
//        return false;
//    }
//    
//    if (txtContent.value == "")
//    {
//        alert("请输入大题主要内容。");
//        txtContent.focus();
//        return false;
//    }
//    
    return true;
    
}
    </script>

</asp:Content>
