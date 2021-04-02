<%@ Page Title="正则、命令" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true"
    CodeBehind="Command.aspx.cs" Inherits="Publish.Command"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <%--  左边--%>
        <div id="materialLeft" class="materialLeft" style="">
            <textarea id="txtContent" name="txtContent" style="width: 304px; height: 131px;"><%= Request.Form["txtContent"]%></textarea>
            <br />  
            正则：   <br />  
            <textarea id="txtKeyExpression" name="txtKeyExpression" style="width: 304px; height: 32px;"><%= String.IsNullOrEmpty(Request.Form["txtKeyExpression"]) ? "正确答案:.*?故选[A-D]。" : Request.Form["txtKeyExpression"]%></textarea>
        
            <asp:Button ID="btnGetkey" runat="server" Text="获得答案"   onclick="btnGetkey_Click" />
            <br />
            <textarea id="txtAnalysisExpression" name="txtAnalysisExpression" style="width: 304px; height: 32px;"><%= String.IsNullOrEmpty(Request.Form["txtAnalysisExpression"]) ? "正确答案:.*?故选[A-D]。" : Request.Form["txtAnalysisExpression"]%></textarea>
        
            <asp:Button ID="btnGetAnalysis" runat="server" Text="获得分析"  onclick="btnGetkey_Click" />    
            <br />
            <textarea id="txtClearExpression" name="txtClearExpression" style="width: 304px; height: 32px;"><%= String.IsNullOrEmpty(Request.Form["txtClearExpression"]) ? "正确答案:.*?故选[A-D]。" : Request.Form["txtClearExpression"]%></textarea>       
       
            <asp:Button ID="btnClearQuestion" runat="server" Text="清理试题"  onclick="btnGetkey_Click" /> 
                <br />       
            <br />
     <textarea id="txtQuery" name="txtQuery" style="width: 304px; height: 32px;"><%= Request.Form["txtQuery"]%></textarea>
             <asp:Button ID="btnExecuteQuery" runat="server" Text="执行SQL" 
                onclick="btnExecuteQuery_Click"   /> 
        </div>
    </div>
    <%--   右边   --%>
    <div id="materialRight" class="materialRight">
        <div  id="divResult" ondblclick="window.clipboardData.setData('TEXT', this.innerText);">
        <asp:Literal runat="server" ID="litResult"></asp:Literal>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">
        
    </script>
</asp:Content>
