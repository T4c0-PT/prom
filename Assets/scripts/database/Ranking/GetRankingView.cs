using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetRankingView : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private Transform post;
    [SerializeField] private Button button;
    [SerializeField] private GetRankingController controller;


    void Awake()
    {
        controller = GetComponent<GetRankingController>();
        button.onClick.AddListener(Send);
    }

    public void Send()
    {
        controller.Send(OnResult);
    }

    void OnResult(UserResultData result)
    {

        if (result != null && result.data != null && result.data.Length > 0)
        {
            foreach (UserData user in result.data)
            {
                GameObject textObj = Instantiate(text, post);
                textObj.GetComponent<TextMeshProUGUI>().text = $"{user.name}: {user.score}";
            }
        }

        Debug.Log("Total Score Updated");

    }
}
