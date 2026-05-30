using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

public class GetUpdateController : MonoBehaviour
{
    private string URL = "http://localhost/porom/Update.php";

    public void Send(string username, int score, Action callback)
    {
        StartCoroutine(SendRequest(username, score, callback));
    }

    private IEnumerator SendRequest(string username, int score, Action callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("score", score);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke();
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
}
