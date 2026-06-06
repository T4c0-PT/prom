using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

public class GetRankingController : MonoBehaviour
{
    private string URL = "http://localhost/Promerdio2/php/Ranking.php";

    public void Send(Action<UserResultData> callback)
    {
        StartCoroutine(SendRequest(callback));
    }

    private IEnumerator SendRequest(Action<UserResultData> callback)
    {

        using (UnityWebRequest www = UnityWebRequest.Get(URL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback.Invoke(JsonUtility.FromJson<UserResultData>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }

}
