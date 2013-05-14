var _countDowncontainer=0;
var _currentSeconds=0;

function ActivateCountDown(strContainerID, initialValue) {
	_countDowncontainer = document.getElementById(strContainerID);
	
	if (!_countDowncontainer) {
		alert("count down error: container does not exist: "+strContainerID+
			"\nmake sure html element with this ID exists");
		return;
	}
	
	SetCountdownText(initialValue);
	window.setTimeout("CountDownTick()", 1000);
}

function CountDownTick() {
	if (_currentSeconds <= 0) {
		alert("Time's up!");
		//Button lbDelete = (e.Row.FindControl(<Button3>) as Button);
		  top.location="../ces/ExamRedirect.aspx";
		return;
	}
	
	SetCountdownText(_currentSeconds-1);
	window.setTimeout("CountDownTick()", 1000);
}

function SetCountdownText(seconds) {
	//store:
	_currentSeconds = seconds;
	
	//get minutes:
	var minutes=parseInt(seconds/60);
	
	//shrink:
	seconds = (seconds%60);
	
	//get hours:
	var hours=parseInt(minutes/60);
	
	//shrink:
	minutes = (minutes%60);
	
	//build text:
	var strText = AddZero(hours) + ":" + AddZero(minutes) + ":" + AddZero(seconds);
	
	//apply:
	_countDowncontainer.innerHTML = strText;
}

function AddZero(num) {
	return ((num >= 0)&&(num < 10))?"0"+num:num+"";
}



//////////////////

var _countDowncontainer2=0;
var _currentSeconds2=0;
function ActivateCountDown2(strContainerID2, initialValue2) {
	_countDowncontainer2 = document.getElementById(strContainerID2);
	
	if (!_countDowncontainer2) {
		alert("count down error: container does not exist: "+strContainerID2+
			"\nmake sure html element with this ID exists");
		return;
	}
	
	SetCountdownText2(initialValue2);
	window.setTimeout("CountDownTick2()", 1000);
}

function CountDownTick2() {
	if (_currentSeconds2 <= 0) {
		alert("Time's up!");
		//Button lbDelete = (e.Row.FindControl(<Button3>) as Button);
		  top.location="../ces/ExamRedirect.aspx";
		return;
	}
	
	SetCountdownText2(_currentSeconds2-1);
	window.setTimeout("CountDownTick2()", 1000);
}

function SetCountdownText2(seconds2) {
	//store:
	_currentSeconds2 = seconds2;
	
	//get minutes:
	var minutes2=parseInt(seconds2/60);
	
	//shrink:
	seconds2 = (seconds2%60);
	
	//get hours:
	var hours2=parseInt(minutes2/60);
	
	//shrink:
	minutes2 = (minutes2%60);
	
	//build text:
	var strText2 = AddZero2(hours2) + ":" + AddZero2(minutes2) + ":" + AddZero2(seconds2);
	
	//apply:
	_countDowncontainer2.innerHTML = strText2;
}

function AddZero2(num2) {
	return ((num2>= 0)&&(num2 < 10))?"0"+num2:num2+"";
}