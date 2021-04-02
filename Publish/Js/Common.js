
function SinCheck(control)
{

	if(control.checked == true)
	{
		var checkboxList = document.getElementsByTagName("input");	
		for (var i=0; i<checkboxList.length; i++)
		{
			if((checkboxList[i].name == control.name && checkboxList[i].checked == true) && (checkboxList[i] != control))
			{				
				checkboxList[i].checked = false;	
			}
		}
	}
}

function CheckAll(checked ,controlName)
{
	var checkboxList = document.getElementsByTagName("input");
	for (var i=0; i<checkboxList.length; i++)
	{
		if(!checkboxList[i].disabled && (checkboxList[i].name.indexOf(controlName) >= 0))
		{
			checkboxList[i].checked = checked;
		}
	}
}

function AdvCheck(controlName)
{
	var checkboxList = document.getElementsByTagName("input");
	var flag = false;
	
	for (var i=0; i<checkboxList.length; i++)
	{
		if(checkboxList[i].name.indexOf(controlName) >= 0)
		{
		    checkboxList[i].checked = checkboxList[i].checked ? false : true;
		}
	}
}

function NoCheck(controlName)
{
	var checkboxList = document.getElementsByTagName("input");
	var flag = false;
	
	for (var i=0; i<checkboxList.length; i++)
	{
		if(checkboxList[i].name.indexOf(controlName) >= 0)
		{
			flag = (flag)?true:checkboxList[i].checked;
		}
	}
	
	

	return true;
}

 document.getElementsByClassName = function(clsName)
 {
        var retVal = new Array();
        var elements = document.getElementsByTagName("*");
        for(var i = 0;i < elements.length;i++){
            if(elements[i].className.indexOf(" ") >= 0){
                var classes = elements[i].className.split(" ");
                for(var j = 0;j < classes.length;j++){
                    if(classes[j] == clsName)
                        retVal.push(elements[i]);
                }
            }
            else if(elements[i].className == clsName)
                retVal.push(elements[i]);
        }
        return retVal;
}
 