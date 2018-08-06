using System;
using System.Collections.Generic;
using UnityEngine;

public class FackbookListener : MonoBehaviour
{
    private Dictionary<string, Action<string>> jsSdkCallbackDicts;

    void Awake()
    {
        jsSdkCallbackDicts = new Dictionary<string, Action<string>>(15);
    }

    public void RegisterListener(string InEventName, Action<string> InCallback)
    {
        jsSdkCallbackDicts[InEventName] += InCallback;
    }

    private void JsSdkCallbackListener(string InKey, string InValue)
    {
        Action<string> callback;
        if (jsSdkCallbackDicts.TryGetValue(InKey, out callback))
        {
            callback.Invoke(InValue);

            jsSdkCallbackDicts.Remove(InKey);
        }
        else
        {
            Debug.LogError("Js sdk callback not register listener.\nkey = " + InKey + "\nvalue = " + InValue);
        }
    }
}