using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]private float Jump = 5;
    private Rigidbody rb;
    public int points = 0;
    [SerializeField]private TextMeshProUGUI pointsText;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(Vector3.up * Jump, ForceMode.Impulse);
        }
        pointsText.text = points.ToString();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tubo"))
            points++;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
            SceneManager.LoadScene("score");
    }
}
