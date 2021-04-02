<%@ Page Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="EditSelection.aspx.cs"
    Inherits="Publish.EditSelection" %>

<asp:Content ContentPlaceHolderID="body" runat="server" ID="AddSelection">
    <div>
        <%--  左边--%>
        <div id="materialLeft" class="materialLeft" style="width: 30%">
          <%--  大题题目：<br />
  --%>
                <asp:DropDownList ID="drpMainSubject" runat="server" Width="250px" Visible="false">
                </asp:DropDownList>
                <input type="button" value="定位" onclick="LocateModel()" style="display:none" />
         
            <p>
                是否多选：<br />
                <asp:CheckBox ID="chkChoiceType" Text="多项选择" runat="server" />
            </p>
            <p>
                选项换行：
                <asp:RadioButtonList runat="server" ID="radBreakType" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">不换行</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">每选项一换</asp:ListItem>
                    <asp:ListItem Value="3">两选项一换</asp:ListItem>
                </asp:RadioButtonList>
            </p>
            试题内容：
            <br />
            <asp:TextBox runat="server" ID="txtSelection" Height="155px" TextMode="MultiLine"
                Width="300px">
            </asp:TextBox>
            <br />
            <div style="text-align: right">
                <input type="reset" id="btnReset" value="重新填写" />
                <asp:Button ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Text="生成试题"
                    CssClass="TextButton" />
            </div>
        </div>
        <%--   右边   --%>
        <div id="materialRight" class="materialRight" style="width: 60%">
            当前所添加选择题总数：<%=  dgChoiceList.Rows.Count.ToString() %>
            <asp:GridView ID="dgChoiceList" BorderWidth="0px" runat="server" AutoGenerateColumns="false"
                Width="80%">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div onmouseup="IsDisplayDiv('div_Panel_<%# Eval("Index") %>')">
                                <img src="/images/del.gif" alt="del" />
                                <%# Eval("Subject") %>
                            </div>
                            <div style="background-color: #FFFFE8; display: none;" id='div_Panel_<%# Eval("Index") %>'>
                                <%# Eval("ChoiceHtml")%>
                                <div style="float: right;">
                                    正确答案:<span id='userAnswerID<%# Eval("MainSubject") %><%# Eval("Index") %>' style="color: Red;
                                        font-weight: bold;"><%# Eval("Key") %></span>
                                    <input type="hidden" name="hidChoice<%# Eval("MainSubject") %><%# Eval("Index") %>"
                                        id="hidChoice<%# Eval("MainSubject") %><%# Eval("Index") %>" />
                                </div>
                            </div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <div style="text-align: right">
                <a href='EditChoices.aspx?ExamInfoID=<%=Request["ExamInfoID"] %>&Mid=<%=Request["Mid"] %>'
                    class="TextButton">编辑添加的选择题</a>
                <asp:Button ID="btnKeyUpdate" runat="server" OnClick="btnKeyUpdate_Click" Text="添加试题" />
            </div>
            <div style="clear: both">
            </div>
        </div>
    </div>
    <div style="clear: both">
            </div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="foot" runat="server">

    

</asp:Content>
