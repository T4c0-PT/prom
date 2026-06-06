using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

public class GetUpdateController : MonoBehaviour
{
    private string URL = "http://localhost/Promerdio2/php/Update.php";

    public void Send(string name, int score, Action callback)
    {
        StartCoroutine(SendRequest(name, score, callback));
    }

    private IEnumerator SendRequest(string name, int score, Action callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
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
