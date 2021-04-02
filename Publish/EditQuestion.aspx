<%@ Page Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="EditQuestion.aspx.cs"
    Inherits="Publish.EditQuestion" Title="编辑简答或论述题" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .questItem
        {
            padding: 2px 0 2px 40px;
            background-color: #FFFFE8;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <%--  左边--%>
        <div id="materialLeft" class="materialLeft" style="">
      <%--      大题题目：<br />--%>
            <asp:DropDownList ID="drpMainSubject" runat="server" Width="260px" Visible="false">
            </asp:DropDownList>
            <div style="text-align: right; display:none;">
                <input type="button" value="定位" onclick="LocateModel()" />
                <asp:Button ID="btnCategory" runat="server" Text="更新选中分类" CssClass="TextButton" OnClick="btnUpdate_Click" />
            </div>
            <div>
                单个问题：
                <br />
                <asp:TextBox runat="server" ID="txtSubject" TextMode="MultiLine" Width="260px" Height="32px" />
            </div>
            <div>
                单个答案：<br />
                <asp:TextBox runat="server" ID="txtKey" Width="260px" TextMode="MultiLine" Height="35px" />
            </div>
            <div style="text-align: right">
                <asp:Button ID="btnGenerate" runat="server" Text="添加题目" CssClass="TextButton" OnClick="btnGenerate_Click"
                    OnClientClick="return IsValid()" />
            </div>
            <p>
                批量问题添加（每个换行符为一个）<br />
                <asp:TextBox runat="server" ID="txtBatchSubject" Width="260px" Height="60px" TextMode="MultiLine" />
            </p>
            <div style="text-align: right">
                <asp:Button ID="btnBatchAdd" runat="server" Text="批量添加" CssClass="TextButton" OnClientClick="return IsValid()"
                    OnClick="btnBatchAdd_Click" />
            </div>
            <p>
                批量答案添加<br />
                <asp:TextBox runat="server" ID="txtBatchKey" Width="260px" Height="50px" TextMode="MultiLine" />
            </p>
            <object id="player" height="45px" width="260px" classid="clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6">
                <param name="URL" value="" />
                <param name="autostart" value="false" />
            </object>
            <div style="text-align: right">
                <div id="divMediaFile">
                </div>
                <input type="button" onclick="getMediaFile()" value="打开媒体文件" id="btnMediaFile" />
                <asp:Button ID="btnBatchAddKey" runat="server" Text="批量答案更新" CssClass="TextButton"
                    OnClick="btnBatchAddKey_Click" />
            </div>
        </div>
    </div>
    <%--   右边   --%>
    <div id="materialRight" class="materialRight">
        总数：<span style="font-weight: bold"><%= dgList.Rows.Count.ToString() %></span>
        <br />
        图库：
        <asp:DropDownList ID="drpFolders" runat="server">
        </asp:DropDownList>
        <div style="text-align: right">
            <asp:GridView ID="dgList" BorderWidth="0px" runat="server" AutoGenerateColumns="false"
                OnRowDeleting="dgList_RowDeleting">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <div style="background-color: #FFFFE8; vertical-align: top;">
                                <asp:LinkButton runat="server" ID="btnDel" CommandName="Delete"><img alt="del" src="/images/del.gif"  /> </asp:LinkButton>
                                <asp:CheckBox ID="chk" runat="server" />
                                <input type="hidden" value='<%# Eval("ID") %>' id="hidIndex" runat="server" />
                                <%#Container.DataItemIndex +1%>：
                                <asp:TextBox ID="txtSubject" TextMode="MultiLine" runat="server" Text='<%# Eval("Subject")%>'
                                    Width="250px" />
                                答案：
                                <asp:TextBox runat="server" ID="txtKey" Width="260px" Text='<%# Eval("Key") %>' TextMode="MultiLine" />
                                <br />
                            </div>
                            <div class="questItem">
                                题目图片：
                                <input type="hidden" id="hidSubjectExten<%# Eval("ID") %>" name="hidSubjectExten<%# Eval("ID") %>"
                                    value="<%# Eval("Simage") %>" />
                                <input type="button" id="btnSubjectImage<%# Eval("ID") %>" onclick="getSubjectImage(<%# Eval("ID") %>)"
                                    value="<%# Eval("Simage").ToString() == "" ? "选择图片" : PrefixSubjectImage + Eval("ID").ToString() +  Eval("Simage").ToString() %>" />
                                <input type="button" id="btnClearSubject" onclick="$('#hidSubjectExten<%# Eval("ID") %>').val(''); $('#btnSubjectImage<%# Eval("ID") %>').val('选择图片')"
                                    value="重置" />

                           
                                <input type="hidden" name="hidSubjectServerFileName<%# Eval("iD") %>" id="hidSubjectServerFileName<%# Eval("iD") %>" />
                                <input type="hidden" name="hidSubjectDest<%# Eval("iD") %>" id="hidSubjectDest<%# Eval("iD") %>" />
                                答案图片：
                                <input type="hidden" id="hidAnswerExten<%# Eval("ID") %>" name="hidAnswerExten<%# Eval("ID") %>"
                                    value="<%# Eval("Aimage") %>" />
                                <input type="button" id="btnAnswerImage<%# Eval("ID") %>" onclick="getAnswerImage(<%# Eval("ID") %>)"
                                    value="<%# Eval("Aimage").ToString() == "" ? "选择图片" : PrefixAnswerImage + Eval("ID").ToString() +  Eval("Aimage").ToString() %>" />
                                <input type="button" id="btnClearAnswer" onclick="$('#hidAnswerExten<%# Eval("ID") %>').val(''); $('#btnAnswerImage<%# Eval("ID") %>').val('选择图片')"
                                    value="重置" />
                                    
                                    <%--详细信息--%>
                              <input type="button" id="btnSubjectDetail<%# Eval("ID") %>" value='<%# String.IsNullOrEmpty(Eval("SubjectDetail").ToString()) ? "添加详细" : Eval("SubjectDetail")%>' onclick="setSubjectDetail(<%# Eval("ID") %>)" />
                            <input type="hidden" id="hidSubjectDetail<%# Eval("ID") %>" value='<%#  Eval("SubjectDetail") %>' onclick="setSubjectDetail(<%# Eval("ID") %>)" />
                           
                                <input type="hidden" name="hidAnswerServerFileName<%# Eval("iD") %>" id="hidAnswerServerFileName<%# Eval("iD") %>" />
                                <input type="hidden" name="hidAnswerDest<%# Eval("iD") %>" id="hidAnswerDest<%# Eval("iD") %>" />
                                <br />
                                开始位置：<input type="text" id="txtStartPosition<%# Eval("ID") %>" value="" size="12" />
                                结束位置：<input type="text" id="txtEndPosition<%# Eval("ID") %>" size="12" />
                                <input type="button" id="btnStart<%# Eval("ID") %>" value="开始" onclick="getPosition('txtStartPosition<%# Eval("ID") %>')" />
                                <input type="button" id="btnEnd<%# Eval("ID") %>" value="结束" onclick="getPosition('txtEndPosition<%# Eval("ID") %>')" />
                                <input type="button" id="btnPlay<%# Eval("ID") %>" value="播放" onclick="playMedia($('#txtStartPosition<%# Eval("ID") %>').val(),$('#txtEndPosition<%# Eval("ID") %>').val());" />
                            </div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <span style="display: none">
                <asp:Button ID="btnDel" runat="server" Text="删除所选" OnClientClick="return confirm('确定要删除吗？')" />
            </span>
            <input id="checkAll" type="checkbox" onclick="CheckAll(this.checked, 'chk')" />全选
            <input id="checkAdv" type="checkbox" onclick="AdvCheck('chk')" />反选&nbsp;
            <asp:Button ID="btnDeleteByCategory" runat="server" Text="删除选中试题" CssClass="TextButton"
                OnClick="btnDeleteByCategory_Click" OnClientClick="return confirm('确定吗')" />
            <asp:Button ID="btnUpdate" runat="server" Text="更新试题" OnClick="btnUpdate_Click" />
        </div>
    </div>

    
     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <div style="display: none;" id="divDialogRet">
    </div>
    <script src="Js/MediaPlayer.js" type="text/javascript"></script>
    <script type="text/javascript">

        function IsValid() {
            return true;
        }
        function setSubjectDetail(id) {

            var examInfoID = Number("<%= ExamInfoID %>");
            var mid = Number("<%= Mid %>");
            var hidSubjectDetail = $("#hidSubjectDetail" + id).val();

           // if (hidSubjectDetail == "")
                window.open("AddSubjectDetail.aspx?ExamInfoID=" + examInfoID + "&mid=" + mid + "&id=" + id + "&qt=4", "SubjectDetail", "");
//            else
//                window.open("UpdateSubjectDetail.aspx?ExamInfoID=" + examInfoID + "&mid=" + mid + "&id=" + id + "&qt=4", "SubjectDetail", "");
        }
        var mediaDialogFeature = "dialogHeight:500px; dialogWidth:800px;";
        var imageDialogFeature = "dialogHeight:580px; dialogWidth:734px;"

        var mediaOpenFeature = "height=200,width=400,status=yes,toolbar=no,menubar=no,location=no";
        var imageOpenFeature = "height=200,width=400,status=yes,toolbar=no,menubar=no,location=no";

        function getMediaFile() {

            var ret = window.showModalDialog("MediaList.aspx?root=Media", "", mediaDialogFeature);
            //              var ret = window.open("MediaList.aspx?root=MediaLib", null, mediaDialogFeature);
            $("#divDialogRet").html(ret);
            openMediaFile($("#tdServerFileName").text());

        }
        //    tdSubjectID
        //    tdMid
        //    tdEid
        //    tdFileExten
        //    tdFullFileName
        //    tdServerFileName
        //    tdFileNameWithoutExten
        //    tdSImagePostion
        //    tdAImagePostion
        function getSubjectImage(id) {

            var ret = window.showModalDialog("MediaList.aspx?root=" + $("#<%= drpFolders.ClientID %>").val() + "&ID=" + id, "", imageDialogFeature);

            //    var ret = window.open("MediaList.aspx?root=Library&ID=" + id, null, imageOpenFeature);
            if (ret == null)
                return;

            $("#divDialogRet").html(ret);

            $("#btnSubjectImage" + id).val($("#tdFileName").text());
            //                   $("#drpSubjectTag"+id).val($("#tdSImagePostion").text());
            $("#hidSubjectServerFileName" + id).val($("#tdServerFileName").text());
            $("#hidSubjectExten" + id).val($("#tdFileExten").text());
            $("#hidSubjectDest" + id).val("<%= PrefixSubjectImage %>" + id + $("#tdFileExten").text());

        }

        function getAnswerImage(id) {
            var ret = window.showModalDialog("MediaList.aspx?root=" + $("#<%= drpFolders.ClientID %>").val() + "&ID=" + id, "", imageDialogFeature);
            //  var ret = window.open("MediaList.aspx?root=Library&ID=" + id, null, imageOpenFeature);

            if (ret == null)
                return;

            $("#divDialogRet").html(ret);

            $("#btnAnswerImage" + id).val($("#tdFileName").text());
            //                   $("#drpAnswerTag"+id).val($("#tdAImagePostion").text());
            $("#hidAnswerServerFileName" + id).val($("#tdServerFileName").text());
            $("#hidAnswerExten" + id).val($("#tdFileExten").text());
            $("#hidAnswerDest" + id).val("<%= PrefixAnswerImage %>" + id + $("#tdFileExten").text())
        }
    </script>
</asp:Content>
