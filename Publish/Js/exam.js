
    function GetSingleSelected(keySingleName, currentInput)
    {
  
        for (var i = 0; i < document.getElementsByName(keySingleName).length;i++)
        {
            if (document.getElementsByName(keySingleName).item(i).checked)
            {
                var current = document.getElementsByName(keySingleName).item(i).value;
         
                var labelID ="Label_" + document.getElementsByName(keySingleName).item(i).id;
                var label = document.getElementById(labelID);
                      
               document.getElementById("userAnswerID"+currentInput).innerHTML = current;
               document.getElementById("hidChoice"+currentInput).value = current;
             //  alert( current);
            }
        }
    }

    function GetMultipleSelected(keyMultiName, currentInput)
    {
           
          var temp = "";
          
          for (var i = 0; i < document.getElementsByName(keyMultiName).length;i++)
          {
                if (document.getElementsByName(keyMultiName).item(i).checked)
                {
                   var current = document.getElementsByName(keyMultiName).item(i).value;
                    
                   temp += current;
                }
           }
           
           document.getElementById("userAnswerID"+currentInput).innerHTML = temp;
           document.getElementById("hidChoice"+currentInput).value = temp;
          //  alert(keyName+"|" + currentInput +"|" + isMulti);
    }
function GetSelectedKey(keyName, currentInput, isMulti)
{ 
 
    if (isMulti == "False")
         GetSingleSelected(keyName, currentInput)
   else
        GetMultipleSelected(keyName, currentInput)
}



/*

//-----------------------------------------------

var multi_max = 2; //the maximum number of multiple choice questions.
var multi_answer = "Multi_Answer_";
var multi_Label_Choice = "Label_Multi_";
var multi_rec = "Multi_Rec_";

function MutliSubmit()
{
    var correct = 0; 
    var result = "";
    
    for (var i = 1;  i <= multi_max; i++)
        {     
              
                var selectedKey = ""; 
                var currentAnswer = document.getElementById(multi_answer + i).value;
                var multiRecValue = document.getElementById(multi_rec + i).value;
                var multiName = "Multi_" + i;  //To get every multiple choice name. 
                var multChoiceCount = document.getElementsByName(multiName).length;      //To calculate the maximum number of every multiple choice.
                
                //alert(currentAnswer);
                
                for (var m =0; m < currentAnswer.length;m++)
                {
                    var next = m+1;
                    var letter = currentAnswer.substring(m, next);
                   
                     if (letter  == "")
                        continue;
                        
                        //To calculate every choice's label ID.
                     var multiLabelID = multi_Label_Choice + i + "_" + letter;
                      //alert(multiLabelID); 
                     document.getElementById(multiLabelID).style.fontWeight = "Bold";    
                       //alert(multChoiceCount); 
                   }
                   
                   for (var c = 0; c < multChoiceCount; c++)
                   {
                         if (document.getElementsByName(multiName).item(c).checked)
                        { 
                             selectedKey += document.getElementsByName(multiName).item(c).value;
                        } 
                   }
                   
                   
                if (selectedKey ==  currentAnswer)
                      correct++;
       
                result += i + ".   正确答案：" + currentAnswer;
                result += " 我选的答案：" + ((selectedKey == null) ? "空" :selectedKey); 
                result += " 笔记：" + multiRecValue + "<br />";
                
                   //alert(currentAnswer);
                   //alert(selectedKey);
       }   
       
                       result += "<p style='color:red; font-weight:bold;'>"; 
         result += "　总共："+ multi_max +" 一共做对了：" + correct;
         result += "</p>";
         
         document.getElementById("multiResult").innerHTML = result;  
}
*/
