<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Web.Master" CodeBehind="Figures.aspx.cs"
    Inherits="Publish.Figures" Title="统计题库资料数目" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <p>
        试题价格估算：</p>
    <p>
    </p>
    <table border="1" cellpadding="0" cellspacing="0" style="width: 70%;">
        <thead>
            <tr>
                <th>
                    数据库(题库名称)
                </th>
                <th>
                    试卷总数
                </th>
                <th>
                    每卷价格
                </th>
                <th>
                    系统成本价格
                </th>
                <th>
                    易方得系统价
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td id="tdName">
                    <%= Publish.EasyConfig.DBNameWithoutExtension %>
                </td>
                <td id="tdExamInfoCount">   
                    <input type="text" style="width: 49px;" value="<%= examInfoCount %>" id="txtExamInfoCount" onkeyup="calculatePrice()" />
              
                    
                </td>
                <td>
                    <input type="text" style="width: 49px;" value="0.4" id="txtSinglePrice" onkeyup="calculatePrice()" />
                </td>
                <td>
                    <input type="text" style="width: 49px;" value="2" id="txtSystemCost" onkeyup="calculatePrice()" />
                </td>
                <td style="color: Red;" id="tdTotal">
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <textarea id="txtContent" rows="10" cols="100">
试卷总数：<%= examInfoCount %> 卷
试题总数： <%= sumup %> 个
试卷大题名称包括：<%= mainSubjects %>
系统大纲资料总数：<%=outlineCount%> 篇
    </textarea>
    <br />
    <input type="button" onclick="copy()" value="复制" />
    <a href="<%= UrlAddProductRedirect %>">转向产品添加页</a>
    <script type="text/javascript">
        function copy() { window.clipboardData.setData('text', $("#txtContent").val()); }

        function calculatePrice() {

            var examInfoCount = parseInt($("#txtExamInfoCount").val());
            var systemCost = parseFloat($("#txtSystemCost").val());
            var singlePrice = parseFloat($("#txtSinglePrice").val());
            var totalPrice = Math.round(examInfoCount * singlePrice + systemCost)
            $("#tdTotal").text(totalPrice);
        }

        window.onload = calculatePrice;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
