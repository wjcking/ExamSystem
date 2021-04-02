<%@ Page    Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="MaterialList.aspx.cs" Inherits="Publish.MaterialList"  Title="编辑文档库"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <%--  左边--%>
        <div id="materialLeft" class="materialLeft" style="">             
            文档标题：<br />
            <br />
            <br />
            <asp:TextBox runat="server" ID="txtTitle" Width="180px"  ></asp:TextBox>
            <br />
            <p>
                文档内容：
                <br />
                <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" Width="220px" 
                    Height="273px" />
            </p>
            
      
            <div style="text-align: right">
                <input type="reset" id="btnReset" value="重新填写" />
                <asp:Button ID="btnGenerate" runat="server" Text="添加题目" CssClass="TextButton" 
           onclick="btnGenerate_Click" />
            </div>
        </div>
    </div>
    <%--   右边   --%>
    <div id="materialRight" class="materialRight"> 
  
        <div style="text-align: right">
       
                <asp:GridView ID="dgList" BorderWidth="0px" runat="server" 
                    AutoGenerateColumns="false" onrowdeleting="dgList_RowDeleting">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <input type="hidden" runat="server" value='<%#Eval("ID") %>' id="hidIndex" />
                            <asp:LinkButton runat="server" ID="btnDel" CommandName="Delete"
                             OnClientClick="return confirm('该分类下的题目一起删除，确定吗？')">
                            <img alt="del" src="/images/del.gif" style="vertical-align:middle;" /> </asp:LinkButton>
                            <asp:CheckBox runat="server" ID="chk" />
                            #<%# Eval("ID") %><asp:TextBox ID="txtTitle" runat="server" Text='<%# Eval("Title")%>' Width="180px" />
                         
                      <asp:TextBox ID="txtContentType" runat="server" Text='<%# Eval("ContentType")%>' Width="10px" />
                            
                             <a href="#<%# Eval("ID") %>" onclick="IsDisplayDiv('div_Panel_<%# Eval("ID") %>')">
                                <img alt="modify" id='imgDisplay' src="/images/add.gif" />
                            </a>
                            
                            <div style="background-color: #FFFFE8; display: none; margin: 5px 0 5px 0; padding: 0 0 4px 30px;"
                                id='div_Panel_<%# Eval("ID") %>'>
                                主要内容：
                                <br />
                                <asp:TextBox runat="server" ID="txtContent" Text='<%# Eval("Content") %>' TextMode="MultiLine" Height="300px" Width="80%" />
                         
                            </div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnRemoveAll" runat="server" Text="删除选中" Visible="false" 
                 OnClientClick="return confirm('确定要全部删除吗？(分类下所有子题目全部删除)')" />
            <asp:Button ID="btnUpdate" runat="server" Text="更新" onclick="btnUpdate_Click"  />
        </div>
    </div>
     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
