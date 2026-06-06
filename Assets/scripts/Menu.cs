using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button button;
    GameObject but;

    private void Awake()
    {
        Time.timeScale =0f;
        button.onClick.AddListener(Play);
    }

    void Play()
    {
        Time.timeScale = 1f;
        
    }
}
