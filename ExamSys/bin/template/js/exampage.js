

document.oncontextmenu = new Function('event.returnValue=false');
document.onselectstart = new Function('event.returnValue=false;');

var tv = new treeview("treeview", "tree", true, true);


treeview.prototype.onnodeclick = function (sender) {
    //声音
    window.external.Play("playitem");
    for (var i = 0; i < tv.nodes.length; i++) {
        if (tv.nodes.items[i].tag != sender.parent.tag)
            tv.nodes.items[i].collapse();
    }

    sender.toggle();

    var taffy = TAFFY(jsonExamInfoListWithoutCategory);
    var examList = taffy({ PID: sender.tag }).get();
    //     categoryList.orderBy(["type", { "price": "asce" }, { "quantity": "asce"}]);
    if (examList.length == 0)
        return false;

    $("#spanExamCategory").html(sender.caption);
    bindExamList(examList);

    return false;
}


function bindNode(pid, nn) {

    var taffy = TAFFY(jsonExamInfoCategoryList);
    var categoryList = taffy({ PID: pid }).get();
    for (var category in categoryList) {

        var n = new node(categoryList[category].Name, "", "#", null, categoryList[category].ID);
        nn.add(n);

        bindNode(categoryList[category].ID, n);
    }
}
function bindExamList(list) {


    $("#tbExamList").html("");
    var item = "";
    var index = 0;

    for (var ei in list) {
        var testLevel = "t.gif";
        var testLevelDetial = "没有考过的试卷";
        var imgFavorite = list[ei].FavCount == 0 ? " " : String.format("<img src=\"images/fav.gif\" style=\"width:18px; height:18px;\" alt=\"收藏：{0}个\" />", list[ei].FavCount);


        var examName = list[ei].Name;

        if (list[ei].TestTimes > 0) {
            testLevel = "t1.gif";
            testLevelDetial = "考过的试卷";
        }

        if (list[ei].TestTimes > 10) {
            testLevel = "t2.gif";
            testLevelDetial = "考的最多的试卷";
        }

        if (list[ei].IncorrectCount > list[ei].TotalCount / 2) {
            testLevel = "incorrect.gif";
            testLevelDetial = "错题数目最多的";
        }

        item += "<tr>";
        item += "<td>";
        item += String.format("<img src=\"images/{0}\" style=\"width:16px; height:18px;\" id=\"img{1}\" alt=\"{2}\"></img> ", testLevel, list[ei].ID, testLevelDetial);
        item += " </td>";
        item += String.format("<td  class=\"item\">[{0}]{1}</td>",list[ei].ID, examName + imgFavorite);
        item += String.format("<td>{0}</td>", list[ei].LastTestTime);
        item += String.format("<td>{0}</td>", list[ei].TestTimes);
        item += String.format("<td style=\"width:100px;\">");

        var floatCorrect = parseFloat(list[ei].CorrectCount);
        var floatTotal = parseFloat(list[ei].TotalCount);

        var percent = floatCorrect <= 0 ? "0%" : Math.round(100 * (floatCorrect / floatTotal)) + "%";

        var progressInfo = "测试次数： " + list[ei].TestTimes;
        progressInfo += "\r\n试题总数： " + list[ei].TotalCount;
        progressInfo += "\r\n正确： " + list[ei].CorrectCount;
        progressInfo += "\r\n错误： " + list[ei].IncorrectCount;
        progressInfo += "\r\n没做： " + list[ei].EmptyCount;

        item += "<div class=\"progressbar_3\"> ";
        item += String.format("<div class=\"text\" title=\"{0}\">{1}</div> ", progressInfo, percent);
        item += String.format("<div class=\"bar\" style=\"width: {0};\"></div> ", percent);
        item += "</div>";
        item += "</td>";

        //       item += String.format("<td class=\"memo\"><img src=\"images/view.gif\" alt=\"{0}\" id=\"imgMemo{1}\"></td>", "浏览" + list[ei].Name, list[ei].ID);
        item += "</tr>";
    }
    $("#tbExamList").html(item);

    $("#tbExamList>tr>td").click(function () {
        //声音
        window.external.Play("playitem");
        $("#tbExamList>tr>td").css("font-weight", "normal");
        $(this).css("font-weight", "bold");
    });


    $(".item").each(function (i) {
        $(this).dblclick(function () {

            templateInfo.ExamInfoID = list[i].ID;

            templateInfo.Title = list[i].Name;

            templateInfo.IsShowSelection = $("#chkIsSelection").attr("checked") == "checked" ? true : false;
            templateInfo.IsShowJudgement = $("#chkIsJudge").attr("checked") == "checked" ? true : false;
            templateInfo.IsShowFill = $("#chkIsFill").attr("checked") == "checked" ? true : false;
            templateInfo.IsShowQuestion = $("#chkIsQuestion").attr("checked") == "checked" ? true : false;
            templateInfo.TestWay = $("#hidTestway").val();
            templateInfo.DisplayStyle = $("#hidDisplayStyle").val();

            window.external.Run(JSON.stringify(templateInfo));

        });
    });


}


//生成节点
bindNode(0, tv);
//填充树div
tv.create(document.getElementById("tree"));
//所有试题列表
bindExamList(jsonExamInfoListWithoutCategory);


$("input[name='TestWay']").each(function (i) {
    $(this).change(function () {
        //声音
        window.external.Play("playitem");
        $("#hidTestway").val($(this).val());
        $("#hidTestway").attr("id");
    });
});
// $("#spanTestWay").html();
//                $("#spanFilter").html( );
//                $("#spanDisplayStyle").html();
$("input[name='rbDisplayStyle']").each(function (i) {
    $(this).click(function () {
        //声音
        window.external.Play("playitem");
        $("#hidDisplayStyle").val($(this).val());
    });
});
$("#divAllExam").click(function () {
    bindExamList(jsonExamInfoListWithoutCategory)
});


$("body").mousedown(function (e) {
    if (e.button == 2) {
        window.external.Play("playtoggle");
        $("#divOption").toggle();
        $("#divExamContent").toggle();
        $("#tbTitle").toggle();
        $("#divTitleBar").toggle();
    }
});


//设置高度, 滚动条自动出现

$("#divExamContent").height($("body").height() - 150);
$("#divExamContent").css("overflow-y", "auto");


$(window).resize(function () {
    $("#divExamContent").height($("body").height() - 150);
});
