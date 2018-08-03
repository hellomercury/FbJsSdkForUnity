using System.Collections.Generic;
using UnityEngine;

public class FbManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnGUI () {
	    if (GUILayout.Button("GetFbAccessToken"))
	    {
	        Application.ExternalCall("getAccessToken");
	    }

        if (GUILayout.Button("LogAppEvent key"))
        {
            LogAppEvent("FbJsSdk_Web_Event_Key1");
        }

        if (GUILayout.Button("LogAppEvent key num"))
        {
            LogAppEvent("FbJsSdk_Web_Event_Key1", 1.0f);
        }

        if (GUILayout.Button("LogAppEvent key  params"))
        {
            LogAppEvent("FbJsSdk_Web_Event_Key1", new Dictionary<string, object>()
            {
                {"p0", 0 },
                {"p1", 0.1f },
                {"p2", "string" }
            });
        }

        if (GUILayout.Button("LogAppEvent key num params"))
        {
            LogAppEvent("FbJsSdk_Web_Event_Key1", 1.0f, new Dictionary<string, object>()
            {
                {"p0", 0 },
                {"p1", 0.1f },
                {"p2", "string" }
            });
        }
    }

    void SetFbAccessToken(string InFbAccessToken)
    {
        Debug.LogError(InFbAccessToken);
    }


    void LogAppEvent(string InEventKey)
    {
        Application.ExternalCall("logAppEventWithKey", InEventKey);
    }

    void LogAppEvent(string InEventKey, float? InNumOfEvents)
    {
        Application.ExternalCall("logAppEventWithKeyAndNum", InEventKey, InNumOfEvents);
    }

    void LogAppEvent(string InEventKey, Dictionary<string, object> InParams)
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

    void LogAppEvent(string InEventKey, float? InNumOfEvents, Dictionary<string, object> InParams)
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

}
