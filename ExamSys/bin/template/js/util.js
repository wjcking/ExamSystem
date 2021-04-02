
var templateInfo = {
    "Keyword": "",
    "ExamHistoryList": "",
    "TemplateContent": "",
    "IsCreatedByQuery": false,
    "RecordCount": 0,
    "PagingQuery": "",
    "MainSubjectQuery": "",
    "WindowSize": null,
    "Title": "",
    "BasePath": null,
    "LimitedTime": -1,
    "IsShowSelection": true,
    "IsShowJudgement": true,
    "IsShowFill": true,
    "IsShowQuestion": true,
    "ExamInfoID": -1,
    "PlatformStyle": "customs",
    "DisplayStyle": 0,
    "FileName": "",
    "TemplatPath": "",
    "TestWay": 1
};

String.format = function (src) {
    if (arguments.length == 0) return null;
    var args = Array.prototype.slice.call(arguments, 1);
    return src.replace(/\{(\d+)\}/g, function (m, i) {
        return args[i];
    });
};

////关键字高亮
function highword(nWord, highlightStyle) {
    if (nWord.length < 2) {
        //alert("关键字不少于2个字符");
        return;
    }
    nWord = nWord + " ";
    //用空格区分查找多关键字 也可用符号等
    var array = nWord.split(" ");

    for (var i = 0; i < array.length; i++) {
        var word = array[i];

        if (word != '') {
            var keyword = document.body.createTextRange();
            try {
                while (keyword.findText(word)) {

                    // if (word.text.length < 2)
                    //      continue; 

                    keyword.pasteHTML("<span style='background-Color:darkblue; color:white;'>" + keyword.text + "</span>");

                    keyword.moveStart('character', 1);
                }
            } catch (e) {

            }
        }
    }

} 