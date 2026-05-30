using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetUpdateView : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInput;

    [SerializeField] private Button button;

    [SerializeField] private GetUpdateController controller;

    private int score = 0; //referencia

    void Awake()
    {
        controller = GetComponent<GetUpdateController>();
        button.onClick.AddListener(Send);
    }

    private void Send()
    {
        string username = usernameInput.text;
        controller.Send(username, score, OnResult);
    }

    void OnResult()
    {
        Debug.Log("exito");

    }
}
