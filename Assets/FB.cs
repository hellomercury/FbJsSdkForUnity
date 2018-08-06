using System;
using System.Collections.Generic;
using UnityEngine;

public static class FB
{
    private static FackbookListener listener;
    public static void Init()
    {
        string fbCallbackGoName = "FackbookListener";
        GameObject fbCallbackGo = new GameObject(fbCallbackGoName);
        listener = fbCallbackGo.AddComponent<FackbookListener>();
        Application.ExternalCall("init", fbCallbackGoName, "JsSdkCallbackListener");
    }

    public static void GetAccessToken(Action<string> InCallback)
    {
        string key = "AccessToken";

        listener.RegisterListener(key, InCallback);

        Application.ExternalCall("getAccessToken", key);
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


}
