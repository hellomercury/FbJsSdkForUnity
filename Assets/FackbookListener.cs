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
        if (jsSdkCallbackDicts.ContainsKey(InEventName))
            jsSdkCallbackDicts[InEventName] += InCallback;
        else
            jsSdkCallbackDicts[InEventName] = InCallback;
    }

    private void JsSdkCallbackListener(string InParam)
    {
        string[] values = InParam.Split('^');
        if (values.Length == 2)
        {
            Action<string> callback;
            if (jsSdkCallbackDicts.TryGetValue(values[0], out callback))
            {
                callback.Invoke(values[1]);

                jsSdkCallbackDicts.Remove(values[0]);
            }
            else
            {
                Debug.LogError("Js sdk callback not register listener.\nkey = " + values[0] + "\nvalue = " + values[1]);
            }
        }
        else
        {
            Debug.LogError("Js sdk callback param error.");
        }
    }
}
