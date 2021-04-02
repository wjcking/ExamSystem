<%@ Page Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="EditChoices.aspx.cs"
    Inherits="Publish.EditChoices" %>

<asp:Content ContentPlaceHolderID="body" runat="server" ID="AddSelection">
    <div style="margin: 20px 40px 40px 40px; width: 90%">
        <div>
            <div style="float: left">
                <h4>
                    选择题总数为：<%=dgChoiceList.Rows.Count.ToString() %></h4>
            </div>
            <div style="float: right">
                <input id="checkAll" type="checkbox" onclick="CheckAll(this.checked, 'chk')" />全选
                <input id="checkAdv" type="checkbox" onclick="AdvCheck('chk')" />反选&nbsp;
                <asp:DropDownList ID="drpMainSubject" runat="server" Width="300px">
                </asp:DropDownList>
              
                <asp:Button ID="btnCategory" runat="server"  Text="更新选中试题分类" 
                    onclick="btnCategory_Click" />
                <asp:Button ID="btnDeleteByCategory" runat="server" OnClick="btnDeleteByCategory_Click"
                    Text="删除已选试题" OnClientClick="return confirm('确定吗？')" />
                <asp:Button ID="btnKeyUpdate" runat="server" OnClick="btnKeyUpdate_Click" Text="更新试题以及答案" />
       
            </div>
            <div style="float:right">图片库：
            <asp:DropDownList ID="drpFolders" runat="server">
        </asp:DropDownList>
        </div>
        </div>
        <p>
        </p>

        <div style="  width: 100%">
            <asp:GridView ID="dgChoiceList" BorderWidth="0px" runat="server" AutoGenerateColumns="false"
                Width="100%" OnRowDeleting="dgChoiceList_RowDeleting">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDel" CommandName="Delete"><img alt="del" src="/images/del.gif" style="vertical-align:middle;" /> 
                            </asp:LinkButton>
                            <asp:CheckBox ID="chk" runat="server" />
                        <%#Container.DataItemIndex +1%>

                            <input type="hidden" value='<%# Eval("MainSubject") %>' id="hidCurrentID" runat="server" />
                            <input type="hidden" value='<%# Eval("ID") %>' id="hidIndex" runat="server" />
                            <span onmouseup="IsDisplayDiv('div_Panel_<%# Eval("Index") %>')">
                                <asp:TextBox Text='<%# Eval("Subject") %>' ID="txtSubject" runat="server" Width="65%"></asp:TextBox>
                                (单/多)
                                <asp:CheckBox ID="cbMultiple" runat="server" Checked='<%# Eval("Multiple")%>' />
                            </span>
                            <asp:DropDownList runat="server" ID="drpBreak">
                                <asp:ListItem Value="0">不换行</asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">每选项一换</asp:ListItem>
                                <asp:ListItem Value="3">两选项一换</asp:ListItem>
                            </asp:DropDownList>

                            <%--详细信息--%>
                                  <input type="button" id="btnSubjectDetail<%# Eval("ID") %>" value='<%# String.IsNullOrEmpty(Eval("SubjectDetail").ToString()) ? "添加详细" : Eval("SubjectDetail")%>' onclick="setSubjectDetail(<%# Eval("ID") %>)" />
                            <input type="hidden" id="hidSubjectDetail<%# Eval("ID") %>" value='<%#  Eval("SubjectDetail") %>' onclick="setSubjectDetail(<%# Eval("ID") %>)" />
                           

                            <br />
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
                                <input type="hidden" name="hidAnswerServerFileName<%# Eval("iD") %>" id="hidAnswerServerFileName<%# Eval("iD") %>" />
                                <input type="hidden" name="hidAnswerDest<%# Eval("iD") %>" id="hidAnswerDest<%# Eval("iD") %>" />
                           
                                开始位置：<input type="text" id="txtStartPosition<%# Eval("ID") %>" value="" size="12" />
                                结束位置：<input type="text" id="txtEndPosition<%# Eval("ID") %>" size="12" />
                                <input type="button" id="btnStart<%# Eval("ID") %>" value="开始" onclick="getPosition('txtStartPosition<%# Eval("ID") %>')" />
                                <input type="button" id="btnEnd<%# Eval("ID") %>" value="结束" onclick="getPosition('txtEndPosition<%# Eval("ID") %>')" />
                                <input type="button" id="btnPlay<%# Eval("ID") %>" value="播放" onclick="playMedia($('#txtStartPosition<%# Eval("ID") %>').val(),$('#txtEndPosition<%# Eval("ID") %>').val());" />
                           <div style="background-color: #FFFFE8; display: none; width: 90%" id='div_Panel_<%# Eval("Index") %>'>   
                           试题分析：
                                <textarea name="txtAnalysis<%# Eval("ID") %>"  cols="160" rows="2" ><%# Eval("Analysis") %></textarea>
                                <br />
                                <%# Eval("ChoiceHtml")%>
                               <br />
                                    正确答案:<span id='userAnswerID<%# Eval("MainSubjectID") %><%# Eval("ID") %>' name='userAnswerID<%# Eval("MainSubjectID") %><%# Eval("ID") %>'
                                        style="color: Red; font-weight: bold;"><%# Eval("Key") %></span><input type="hidden" name="hidChoice<%# Eval("MainSubjectID") %><%# Eval("ID") %>"
                                        id="hidChoice<%# Eval("MainSubjectID") %><%# Eval("ID") %>" value='<%# Eval("Key") %>' /> 
                         
                            </div>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
        </div>
        <!--contol-->
        <div>
    
        <div style="float: left">
            批量更新选择题答案：<br />
            <asp:TextBox ID="txtChoiceKey" runat="server" TextMode="MultiLine" Width="299px"
                Height="81px"></asp:TextBox>
            <asp:Button runat="server" ID="btnBatchKeyUpdate" Text="批量更新答案" OnClick="btnBatchKeyUpdate_Click" />
        </div>
        <div style="float:right">
        选择多媒体文件：<br />

                    <object id="player" height="45px" width="260px" classid="clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6">
                <param name="URL" value="" />
                <param name="autostart" value="false" />
            </object>
            <br />
                     <input type="button" onclick="getMediaFile()" value="打开媒体文件" id="btnMediaFile" />
            </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="footer" ContentPlaceHolderID="foot" runat="server">
  <div style="display: none;" id="divDialogRet">
    </div>
    <script src="Js/MediaPlayer.js" type="text/javascript"></script>
    <script type="text/javascript">

        function setSubjectDetail(id) {

            var examInfoID = Number("<%= ExamInfoID %>");
            var mid = Number("<%= Mid %>");
            var hidSubjectDetail = $("#hidSubjectDetail" + id).val();

          //  if (hidSubjectDetail == "")
                window.open("AddSubjectDetail.aspx?ExamInfoID=" + examInfoID + "&mid=" + mid + "&id=" + id + "&qt=1", "SubjectDetail", "");
//            else
//                window.open("UpdateSubjectDetail.aspx?ExamInfoID=" + examInfoID + "&mid=" + mid + "&id=" + id + "&qt=1", "SubjectDetail", "");
        }

        var mediaDialogFeature = "dialogHeight:500px; dialogWidth:800px;";
        var imageDialogFeature = "dialogHeight:580px; dialogWidth:734px;"

        var mediaOpenFeature = "height=200,width=400,status=yes,toolbar=no,menubar=no,location=no";
        var imageOpenFeature = "height=200,width=400,status=yes,toolbar=no,menubar=no,location=no";

        function getMediaFile() {

            var ret = window.showModalDialog("MediaList.aspx?root=MediaLib", "", mediaDialogFeature);
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
