using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class Test : MonoBehaviour
{

    void Start()
    {
 
    }

    void OnGUI()
    {
        if (GUILayout.Button("Init"))
        {
            FB.Init(() =>
            {
                Debug.LogError("Init finished.");
                Debug.LogError("Access token = " + FB.AccessToken);
                Debug.LogError("user id = " + FB.UserId);
            });
        }

        if (GUILayout.Button("Player Info"))
        {
            FB.GetPlayerInfo(playerInfo =>
            {
                JsonData jd = JsonMapper.ToObject(playerInfo);
                Debug.LogError("player info id = " + (string)jd["id"]);
                Debug.LogError("name = " + (string)jd["name"]);
                Debug.LogError("url = " + (string)jd["picture"]["data"]["url"]);

            });
        }

        if (GUILayout.Button("LogAppEvent key"))
        {
            FB.LogAppEvent("FbJsSdk_Web_Event_Key1");
        }

        if (GUILayout.Button("LogAppEvent key num"))
        {
            FB.LogAppEvent("FbJsSdk_Web_Event_Key1", 1.0f);
        }

        if (GUILayout.Button("LogAppEvent key  params"))
        {
            FB.LogAppEvent("FbJsSdk_Web_Event_Key1", new Dictionary<string, object>()
            {
                {"p0", 0 },
                {"p1", 0.1f },
                {"p2", "string" }
            });
        }

        if (GUILayout.Button("LogAppEvent key num params"))
        {
            FB.LogAppEvent("FbJsSdk_Web_Event_Key1", 1.0f, new Dictionary<string, object>()
            {
                {"p0", 0 },
                {"p1", 0.1f },
                {"p2", "string" }
            });
        }

        if (GUILayout.Button("Share"))
        {
            FB.ShareLink("http://dl.xyz.akamaized.net/mypage/WordWebGLFbShare/Normal/Guide.php",
                result =>
                {
                    Debug.LogError("share result = " + result);
                });
        }

        if (GUILayout.Button("Get Friends"))
        {
            FB.GetFriends(friends =>
            {
                JsonData jd = JsonMapper.ToObject(friends);
                JsonData friendArray = jd["data"];
                int count = friendArray.Count;

                if (count > 0)
                {
                    string log = string.Empty;
                    for (int i = 0; i < count; ++i)
                    {
                        JsonData itemJd = friendArray[i];
                        log += "\"id\":" +(string)itemJd["id"] + ", ";
                        log += "\"name\":" + (string)itemJd["name"] + ", ";
                        log += "\"url\":" + (string)itemJd["picture"]["data"]["url"];
                        log += "\n";
                    }
                    
                    Debug.LogError(log);
                }
            });
        }

        if (GUILayout.Button("App Request"))
        {
            FB.AppRequest("Invite friends test.", "", result =>
            {
                Debug.LogError("App Request result = " + result);
            });
        }
    }
}
