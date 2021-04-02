<%@ Page Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="EditJudgement.aspx.cs" Inherits="Publish.EditJudgement" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <%--  左边--%>
        <div id="materialLeft" class="materialLeft" style="">
         <%--   大题题目：<br />    --%>  
            <asp:DropDownList ID="drpMainSubject" runat="server" Width="300px"  Visible="false">
            </asp:DropDownList>
            <div style="text-align: right;display:none;">
                <br />
                <input type="button" value="定位" onclick="LocateModel()" />
                <asp:Button ID="btnCategory" runat="server" Text="更新勾选试题分类" 
                    CssClass="TextButton" onclick="btnCategory_Click" />
            </div>
            <p>
               单个问题：
                <br />
                <asp:TextBox runat="server" ID="txtSubject" TextMode="MultiLine" Width="300px" 
                    EnableViewState="False" />
            </p>
            <p>
            
           <asp:CheckBox runat="server" ID="chkKey"  Text="当前判断题答案（选中为正确)" />
            </p>
        
            <div style="text-align: right">
                &nbsp;<asp:Button ID="btnGenerate" runat="server" Text="添加题目" CssClass="TextButton" OnClick="btnGenerate_Click" EnableViewState="false" OnClientClick="return IsValid()" />
            </div>
            
                     <p>
            批量问题添加（每个换行符为一个）<br />
             <asp:TextBox runat="server" ID="txtBatchSubject" Width="300px" Height="100px" TextMode="MultiLine" />
            </p>
             <div style="text-align: right">
                <input type="reset"  value="重新填写" />
                <asp:Button ID="btnBatchAdd" runat="server" Text="批量添加" CssClass="TextButton"  OnClientClick="return IsValid()" onclick="btnBatchAdd_Click" />
            </div> 
        </div>
    </div>
    <%--   右边   --%>
    <div id="materialRight" class="materialRight">
        <div style="text-align: right">
            <asp:GridView ID="dgList" BorderWidth="0px" runat="server" AutoGenerateColumns="false"
                OnRowDeleting="dgList_RowDeleting" >
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <input type="hidden" value='<%# Eval("ID") %>' id="hidIndex" runat="server" />
                            <asp:LinkButton runat="server" ID="btnDel" CommandName="Delete"><img alt="del" src="/images/del.gif" style="vertical-align:middle;" /> </asp:LinkButton>
                                  <asp:CheckBox runat="server" ID="chk"  />
                            <%#Container.DataItemIndex +1%>：
                            <asp:TextBox ID="txtSubject" runat="server" Text='<%# Eval("Subject")%>' Width="340px"/>
                            答案：
                          <asp:CheckBox runat="server" ID="myKey"  />
                           <span style="color:gray"> [<%# Eval("CurrentMainSubject.Subject")%>]</span>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
             <input id="checkAll" type="checkbox" onclick="CheckAll(this.checked, 'chk')" />全选
            <input id="checkAdv" type="checkbox" onclick="AdvCheck('chk')" />反选&nbsp;
                <asp:Button ID="btnDeleteByCategory" runat="server" Text="删除所选试题" 
                    CssClass="TextButton"   OnClientClick="return confirm('确定吗？')" 
                    onclick="btnDeleteByCategory_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="更新试题"     CssClass="TextButton"  
                onclick="btnUpdate_Click" />
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
