using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour
{

    public float speed = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (NoteFinder.S.rotL)
            transform.Rotate(0, -speed * Time.deltaTime, 0);

        if (NoteFinder.S.rotR)
            transform.Rotate(0, speed * Time.deltaTime, 0);

    }
}
