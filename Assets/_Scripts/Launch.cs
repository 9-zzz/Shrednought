using UnityEngine;
using System.Collections;

public class Launch : MonoBehaviour
{

    public float speed;
    public float bDeathTime = 4.0f;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, bDeathTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

}
