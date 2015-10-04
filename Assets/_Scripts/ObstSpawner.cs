using UnityEngine;
using System.Collections;

public class ObstSpawner : MonoBehaviour
{

    public GameObject[] obstacles;

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
            yield return new WaitForSeconds(2.0f);

            Instantiate(obstacles[Random.Range(0, 2)], transform.position, transform.rotation); }
    }

}
