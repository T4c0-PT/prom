using UnityEngine;

public class moveTube : MonoBehaviour
{
    [SerializeField]private Transform pointB;
    private float speed = 5f;

    void Start()
    {
        pointB = GameObject.Find("pointB").transform;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        if(transform.position.x < pointB.position.x)
            Destroy(gameObject);
    }
}
