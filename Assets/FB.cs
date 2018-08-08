using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public static class FB
{
    public static bool IsLoggedIn = true;
    public static string AccessToken { get; private set; }
    public static string UserId { get; private set; }


    private static FackbookListener listener;
    public static void Init(Action InInitFinAction)
    {
        string fbCallbackGoName = "FackbookListener";
        GameObject fbCallbackGo = new GameObject(fbCallbackGoName);
        listener = fbCallbackGo.AddComponent<FackbookListener>();
        string key = "getFbInfo";
        listener.RegisterListener(key, result =>
        {
            JsonData jd = JsonMapper.ToObject(result);

            AccessToken = (string)jd["accessToken"];
            UserId = (string)jd["userId"];

            InInitFinAction.Invoke();
        });

        Application.ExternalCall("init", fbCallbackGoName, "JsSdkCallbackListener", key);
    }

    public static void GetPlayerInfo(Action<string> InCallback)
    {
        string key = "PlayerInfo";

        listener.RegisterListener(key, InCallback);

        Application.ExternalCall("getPlayerInfo", key);
    }

    public static void LogAppEvent(string InEventKey)
    {
        Application.ExternalCall("logAppEventWithKey", InEventKey);
    }

    public static void LogAppEvent(string InEventKey, float? InNumOfEvents)
    {
        Application.ExternalCall("logAppEventWithKeyAndNum", InEventKey, InNumOfEvents);
    }

    public static void LogAppEvent(string InEventKey, Dictionary<string, object> InParams)
    {
        int len = InParams.Count;
        object[] arguments = new object[len * 2];
        int index = -1;
        foreach (KeyValuePair<string, object> itor in InParams)
        {
            arguments[++index] = itor.Key;
            arguments[++index] = itor.Value;
        }

        Application.ExternalCall("logAppEventWithKeyAndParam", InEventKey, arguments);
    }

    public static void LogAppEvent(string InEventKey, float? InNumOfEvents, Dictionary<string, object> InParams)
    {
        int len = InParams.Count;
        object[] arguments = new object[len * 2];
        int index = -1;
        foreach (KeyValuePair<string, object> itor in InParams)
        {
            arguments[++index] = itor.Key;
            arguments[++index] = itor.Value;
        }

        Application.ExternalCall("logAppEventWithAll", InEventKey, InNumOfEvents, arguments);
    }

    public static void ShareLink(string InShareLink, Action<string> InCallbakcAction)
    {
        string key = "ShareLink";

        listener.RegisterListener(key, InCallbakcAction);

        Application.ExternalCall("share", InShareLink, key);
    }

    public static void GetFriends(Action<string> InCallbakcAction)
    {
        string key = "Friends";

        listener.RegisterListener(key, InCallbakcAction);

        Application.ExternalCall("getFriends", key);
    }

    public static void AppRequest(string InMsg, string InFriendId, Action<string> InCallbakcAction)
    {
        string key = "AppRequest";

        listener.RegisterListener(key, InCallbakcAction);

        Application.ExternalCall("appRequest", key);
    }

    public static void ActivateApp()
    {
        Application.ExternalCall("activateApp");
    }

    public static void SpentCoins(int InCoins, string InParam)
    {
        Application.ExternalCall("spentCreditsEvent", InCoins, InParam);
    }

    public static void AchievedLevel(string InLevelNum)
    {
        Application.ExternalCall("achievedLevelEvent", InLevelNum);
    }
}
