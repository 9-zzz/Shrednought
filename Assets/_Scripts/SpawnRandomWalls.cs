using UnityEngine;
using System.Collections;

public class SpawnRandomWalls : MonoBehaviour
{

    public GameObject[] obstacles;
    public float waitTime;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(WaitAndSpawn());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacles[Random.Range(0, 4)], transform.position, transform.rotation);
        }
    }

}
