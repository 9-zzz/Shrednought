using UnityEngine;
using System.Collections;

public class DestroyCol : MonoBehaviour
{

    public GameObject redDeathps;

    // Use this for initialization
    void Start()
    {
        Debug.Log("dsfkadsf");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("greenObst"))
        {
            Instantiate(redDeathps, transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }
    }

}
