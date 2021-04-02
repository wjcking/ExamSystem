<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSubjectDetail.aspx.cs"
    Inherits="Publish.AddSubjectDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加主题详细内容</title>
    <style type="text/css">
        body
        {
        	font-size:15px;
        }
        ul
        {
            margin: 0 0 0 0;
        }
        li
        {
            list-style: none;
            list-style-type: none; 
        }
        .title
        {
            border: 1px solid black;
        }
        input
        {
    /*        background-color: White;            border: 1px solid black;*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="hidden" runat="server" name="hidHandle" id="hidHandle" />
    <input type="hidden" runat="server" name="hidID" id="hidID" />
        <div style="color: Red">
         当前试题编号为：<%= Request.QueryString["ID"] %>
         <br />
         当前试题类型为： 
            <asp:Literal ID="litQuestType" runat="server"></asp:Literal>    <br />
        当前大题编号为： <%= Request.QueryString["mid"] %>
         </div>

        <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
            
                <li title='<%# Eval("Content") %>'>
                    <span class="title">
                    所属试题编号：<%# Eval("SubjectID") %>
                    所属大题编号：<%# Eval("MainSubjectID") %>
                    <%# Eval("Title") %>
                    </span>
                    <input type="button"  name="btnDel<%# Container.ItemIndex %>" id="DEL" value="删除题目详细"  onclick='handle(this.id,<%# Eval("ID") %>)'/>
                    <input type="button" name="btnFirst<%# Container.ItemIndex %>" id="FIRST" value="设置为第一个题目详细"  onclick='handle(this.id,<%# Eval("ID") %>)' />
                    <input type="button" name="btnSubjectID<%# Container.ItemIndex %>" id="SUBJECT" value="设定为主题详细"   onclick='handle(this.id,<%# Eval("ID") %>)'/>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div>  <br />
        标题：
        <br />
        <input type="text" id="txtTitle" name="txtTitle" value="" size="80" />
        <br />
        内容：<br />
        <textarea id="txtSubjectDetail" name="txtSubjectDetail" cols="100" rows="5"     onmouseup="setTitle()" onmouseover="setTitle()"
            onkeyup="setTitle()"></textarea>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="添加当前主题详细信息" OnClick="btnAdd_Click" />
        <input type="hidden" value="" id="hidResult" runat="server" />
        <input id="Button1" type="button" value="退出" onclick="set();" />
    </div>
    <script type="text/javascript">
        var txtSubjectDetail = document.getElementById("txtSubjectDetail");
        var txtTitle = document.getElementById("txtTitle");

        function handle(arg, id) {

            if (arg == "DEL") {

                if (!confirm("确定要删除吗？"))
                    return;
            }
            document.getElementById("hidHandle").value = arg;
            document.getElementById("hidID").value = id;

            document.getElementById("form1").submit();
           
        }

        function setTitle() {

            if (txtSubjectDetail.value.length < 23)
                txtTitle.value = txtSubjectDetail.value;
            else
                txtTitle.value = txtSubjectDetail.value.substring(0, 22);
        }

        function set(val) {

            var id = '<%= Request.QueryString["ID"] %>';
            var btn = "btnSubjectDetail" + id;
            var hid = "hidSubjectDetail" + id;
     //       var hidResult = document.getElementById("<%= hidResult.ClientID %>").value;
      
        //    if (hidResult != "") {
            opener.document.getElementById(btn).value = "##" + val + "##";
            opener.document.getElementById(hid).value = "##" + val + "##";
            opener.document.getElementById(btn).style.BackGroundColor = 'red';
       //     }
             self.close();
        }
    </script>
    </form>
</body>
</html>
