using UnityEngine;
using System.Collections;

public class SpawnTube : MonoBehaviour
{
    [SerializeField]private GameObject tubePrefab;

    void Start()
    {
        StartCoroutine(SpawnTubeRoutine());
    }

    private IEnumerator SpawnTubeRoutine()
    {
        while(true)
        {
            transform.position = new Vector3(transform.position.x, Random.Range(-1.5f, 1f), transform.position.z);
            Instantiate(tubePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
