resize();
getExamResult(0);
getKeyword(0);
initialize();
window.onresize = function () { resize(); }

function resize() {

    var height = document.documentElement.clientHeight;
    $("#divRecent").height(height - 485);
    $("#divKeyword").height(height - ($("#divRecent").height() + 245));
    $("#divSummary").height(height - 532);
}
$(".history").each(function (i) {
    $(this).dblclick(function () {
        templateInfo.ExamInfoID = jsonExamResultList[i].ExamInfoID;
        window.external.Run(JSON.stringify(templateInfo));
    })
});


function initialize() {

    if (jsonStatisticList.length > 0) {
        for (var s in jsonStatisticList) {
            $("#divStatisticList").append("<li>" + jsonStatisticList[s].DisplayText + "</li>");
        }
    }
}
function getExamResult(number) {

    if (jsonExamResultList.length == 0) {
        $("#divRecent").append("<li>尊敬的同学您好</li>");
        $("#divRecent").append("<li>这里是您的考试历史记录</li>");
        return;
    }

    for (var er in jsonExamResultList) {
        $("#divRecent").append("<li class=\"history\" >" + jsonExamResultList[er].Name + " <i>" + jsonExamResultList[er].JsonPubDate + "</i> </li>");
    }
}

function getKeyword(number) {
    var hasKeyword = false;
    for (var k = 0; k < jsonExamInfoListWithoutCategory.length; k++) {

        var keyword = jsonExamInfoListWithoutCategory[k].Keyword == "" ? "" : jsonExamInfoListWithoutCategory[k].Keyword.split(' ');
        if (keyword == "")
            continue;


        hasKeyword = true;

        for (var key in keyword) {
            if ($.trim(keyword[key]) == "")
                continue;

            $("#divKeyword").append("<span class=\"keyExam\" title=\" " + jsonExamInfoListWithoutCategory[k].Name + " \">" + keyword[key] + "</span>");
        }
    }

    for (var o in jsonOutlineList) {

        if (jsonOutlineList[o].Keyword == "")
            continue;

        hasKeyword = true;

        var keyword = jsonOutlineList[o].Keyword.split(' ');

        for (var key in keyword) {
            if ($.trim(keyword[key]) == "")
                continue;

            $("#divKeyword").append("<span class=\"keyOutline\" title=\" " + jsonOutlineList[o].Title + " \">" + keyword[key] + "</span>");
        }

    }
    if (!hasKeyword) {
        $("#divKeyword").append("<span class=\"keyOutline\" >您目前尚无 </span>");
        $("#divKeyword").append("<span class=\"keyExam\" >设置</span>");
        $("#divKeyword").append("<span class=\"keyOutline\" >关键字</span>");
        $("#divKeyword").append("<span class=\"keyExam\" >高亮的关键字</span>");
        $("#divKeyword").append("<span class=\"keyExam\" >有助于</span>");
        $("#divKeyword").append("<span class=\"keyExam\" >加深</span>");
        $("#divKeyword").append("<span class=\"keyExam\" >印象记忆</span>");
        $("#divKeyword").append("<span class=\"keyOutline\" >关键字就相当于</span>");
        $("#divKeyword").append("<span class=\"keyExam\" >荧光笔</span>");
        $("#divKeyword").append("<span class=\"keyExam\" >使用方法</span>");
        $("#divKeyword").append("<span class=\"keyExam\" >在试题列表里面加注</span>");
        $("#divKeyword").append("<span class=\"keyExam\" >在大纲资料里面加注</span>");

    }
}
$(".guide>img").each(function (i) {
    $(this).click(function () {

        window.external.Play("playitem");
        $("#spanGuide").text($(this).attr("alt"));
    });
    $(this).dblclick(function () {
        window.external.Navigate($(this).attr("id"));
    });
});
$(".history").click(function (i) {
    //声音
    window.external.Play("playitem");
});
$("li").mouseout(function () {
    $("li").css("borderStyle", "none");
});
$("li").each(function (i) {
    $(this).mouseover(function () {
        $(this).css("borderWidth", "1px");
        $(this).css("borderColor", "black");
        $(this).css("borderStyle", "solid");
    });
});