window.fbAsyncInit = function(){
    FB.init({
        appId:'2053885664881566',
        autoLogAppEvents:true,
        xfbml:true,
        version:'v3.1'
    });

    FB.getLoginStatus(function(response) {
        statusChangeCallback(response);
      });
};

(function(d, s, id){
    var js, fjs = d.getElementsByTagName(s)[0];
    if(d.getElementById(id)) {return;}
    js = d.createElement(s);
    js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));


//{
//    status: 'connected',
//    authResponse: {
//        accessToken: '...',
//        expiresIn:'...',
//        signedRequest:'...',
//        userID:'...'
//    }
//}

var accessToken;
function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);

    if (response.status === 'connected') {
		accessToken = response.authResponse.accessToken;
    } else {
        FB.login(function(response){
            statusChangeCallback(response);
        });
    }
  }
  
var objectName = "FbMgr";
function getAccessToken(){
	console.log("js getAccessToken");
	gameInstance.SendMessage(objectName, "SetFbAccessToken", accessToken);
}

function logAppEventWithKey(eventName){
    console.log("logAppEvent event key = " + eventName);
    FB.AppEvents.logEvent(eventName);
}

function logAppEventWithKeyAndNum(eventName, valueToSum){
    console.log("logAppEvent event key = " + eventName + "\nnumeric value for this event = " + valueToSum);
    FB.AppEvents.logEvent(eventName, valueToSum, null);
}

function logAppEventWithKeyAndParam(eventName, parameterArray){
    console.log("logAppEvent event key = " + eventName + "\n params = " + parameterArray);
    var len = parameterArray.length;
    var parameters = {};
    for (var i = 0; i < len; i += 2){
        parameters[parameterArray[i]] = parameterArray[i + 1];
    }
    FB.AppEvents.logEvent(eventName, null, parameters);
}

function logAppEventWithAll(eventName, valueToSum, parameterArray){
    console.log("logAppEvent event key = " + eventName + "\nnumeric value for this event = " + valueToSum + "\n params = " + parameterArray);
    var len = parameterArray.length;
    var parameters = {};
    for (var i = 0; i < len; i += 2){
        parameters[parameterArray[i]] = parameterArray[i + 1];
    }
    FB.AppEvents.logEvent(eventName, valueToSum, parameters);
}