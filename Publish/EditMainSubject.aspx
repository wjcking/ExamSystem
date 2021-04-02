<%@ Page Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="EditMainSubject.aspx.cs"
    Inherits="Publish.EditMainSubject" Title="编辑大题" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <%--  左边--%>
        <div id="materialLeft" class="materialLeft" style="">
          
            大题题目：<br />
            <asp:TextBox runat="server" ID="txtSubject" Width="180px"></asp:TextBox>
        
            <br />
              <%--  hidden--%>
            <div style="display:none;">
            做题时间：<br />
            <asp:TextBox runat="server" ID="txtLimitTime" Width="180px" MaxLength="65535">30</asp:TextBox>
            <br />
            试题分数：<br />
            <asp:TextBox runat="server" ID="txtScore" Width="180px" MaxLength="65535">15</asp:TextBox>
         
            <br />
            </div>
            试题类型：<br />
            <asp:DropDownList ID="drpType" runat="server" Height="" Width="180px">
                <asp:ListItem Value="1">选择题</asp:ListItem>
                <asp:ListItem Value="2">判断题</asp:ListItem>
                <asp:ListItem Value="3">填空题</asp:ListItem>
                <asp:ListItem Value="4">简答或论述题</asp:ListItem>
            </asp:DropDownList>
            <br />
            单个分数：<br />
            <asp:TextBox runat="server" ID="txtEachPoint" Width="180px" MaxLength="65535">1</asp:TextBox>
            <br />
            <p>
                主要内容：
                <br />
                <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" Width="180px" 
                    Height="73px" />
            </p>
            
                  <%--  hidden--%>
            <p style="display:none;">
                记录摘要：
                <br />
                <asp:TextBox runat="server" ID="txtNote" TextMode="MultiLine" Width="180px" />
            </p>
            <p>
                试题分析：
                <br />
                <asp:TextBox runat="server" ID="txtAnalysis" TextMode="MultiLine" Width="180px" 
                    Height="90px" />
            </p>
            <div style="text-align: right">
                <input type="reset" id="btnReset" value="重新填写" />
                <asp:Button ID="btnGenerate" runat="server" Text="添加题目" CssClass="TextButton" OnClick="btnGenerate_Click"
                    OnClientClick="return IsValid()" />
            </div>
        </div>
    </div>
    <%--   右边   --%>
    <div id="materialRight" class="materialRight"> 
    
      　　 试题总数：<%=  subjectSum %>
         目前总分：<% =scoreSum %> 
        <div style="text-align: right">
       
                <asp:GridView ID="dgList" BorderWidth="0px" runat="server" AutoGenerateColumns="false"
                OnRowDeleting="dgList_RowDeleting" >
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <input type="hidden" runat="server" value='<%#Eval("ID") %>' id="hidIndex" />
                            <asp:LinkButton runat="server" ID="btnDel" CommandName="Delete"
                             OnClientClick="return confirm('该分类下的题目一起删除，确定吗？')">
                            <img alt="del" src="/images/del.gif" style="vertical-align:middle;" /> </asp:LinkButton>
                            <asp:CheckBox runat="server" ID="chk" />
                            题目：(#<%# Eval("ID") %>)
                            <asp:TextBox ID="txtSubject" runat="server" Text='<%# Eval("Subject")%>' Width="180px" />
                              每分：
                            <asp:TextBox ID="txtEachPoint" runat="server" Text='<%# Eval("EachPoint")%>' Width="20px"
                                MaxLength="65535" /> 
                                          排序：
                            <asp:TextBox ID="txtSort" runat="server" Text='<%# Eval("Sort")%>' Width="20px"
                                MaxLength="65535" /> 
                                子题总数：
                            <span style="font-weight:bold" runat="server" id="spanCount"></span>
                        
                       <input type="hidden" runat="server" value='<%# Eval("TopicTypeID") %>' id="hidType" />
                            <asp:Literal runat="server" ID="txtType" Text='' />
                            
                             <a href="#<%# Eval("ID") %>" onclick="IsDisplayDiv('div_Panel_<%# Eval("ID") %>')">
                                <img alt="modify" id='imgDisplay' src="/images/add.gif" />
                            </a>
                            
                            <div style="background-color: #FFFFE8; display: none; margin: 5px 0 5px 0; padding: 0 0 4px 30px;"
                                id='div_Panel_<%# Eval("ID") %>'>
                                主要内容：
                                <br />
                                <asp:TextBox runat="server" ID="txtContent" Text='<%# Eval("Content") %>' TextMode="MultiLine"
                                    Width="80%" />
                                <p>
                                    记录摘要：
                                    <br />
                                    <asp:TextBox runat="server" ID="txtNote" Text='<%# Eval("Note") %>' TextMode="MultiLine"
                                        Width="80%" />
                                </p>
                                <p>
                                    试题分析：
                                    <br />
                                    <asp:TextBox runat="server" ID="txtAnalysis" Text='<%# Eval("Analysis") %>' TextMode="MultiLine"
                                        Width="80%" />
                                </p>
                            </div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnRemoveAll" runat="server" Text="删除选中" Visible="false" 
                OnClick="btnRemoveAll_Click" OnClientClick="return confirm('确定要全部删除吗？(分类下所有子题目全部删除)')" />
            <asp:Button ID="btnUpdate" runat="server" Text="更新" OnClick="btnUpdate_Click" />
        </div>
    </div>
     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">

    <script type="text/javascript">

function IsValid()
{
    var txtSubject  = document.getElementById('<%= txtSubject.ClientID %>');
    var txtContent  = document.getElementById('<%= txtContent.ClientID %>');
    
    
    if (txtSubject.value == "")
    {
        alert("请输入大题题目。");
        txtSubject.focus();
        return false;
    }
    
//    if (txtContent.value == "")
//    {
//        alert("请输入大题主要内容。");
//        txtContent.focus();
//        return false;
//    }
    
    
    return true;
}


    </script>

</asp:Content>
