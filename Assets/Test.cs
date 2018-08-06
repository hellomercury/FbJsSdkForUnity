using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class Test : MonoBehaviour
{

    void Start()
    {
        FB.Init();
    }

    void OnGUI()
    {
        if (GUILayout.Button("GetFbAccessToken"))
        {
            FB.GetAccessToken(accessToken =>
            {
                Debug.LogError("FB access token = " + accessToken);
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

        if (GUILayout.Button("Player Info"))
        {
            //FB.GetPlayerInfo(playerInfo =>
            //{
            //    JsonData jd = JsonMapper.ToObject(playerInfo);

            //});

            //string json = "{\"id\":\"118265425774845\",\"name\":\"Dave Albggdafdheeb Valtchanovman\",\"email\":\"ionxmyiywq_1533543562 @tfbnw.net\",\"picture\":{\"data\":{\"height\":120,\"is_silhouette\":true,\"url\":\"https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=118265425774845&height=120&width=120&ext=1536141642&hash=AeRNlBZ5gDKGSZRR\",\"width\":120}}}";
            //JsonData jd = JsonMapper.ToObject(json);
            //Debug.LogError(jd["id"]);
            //Debug.LogError(jd["name"]);
            //if(jd["picture1"] == null) Debug.LogError("2222");
            //Debug.LogError(jd["picture"]["data"]["url"]);


            string json1 = "{\"data\":[]}";
            JsonData jd = JsonMapper.ToObject(json1);
            Debug.LogError(jd["data"].Count);
        }
    }
}
