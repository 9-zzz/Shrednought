using UnityEngine;
using System.Collections;

public class SpawnByLoudness : MonoBehaviour
{

    public GameObject audioInputObject;
    public float threshold = 1.0f;
    public GameObject objectToSpawn;
    MicrophoneInput micIn;
    void Start()
    {
        if (objectToSpawn == null)
            Debug.LogError("You need to set a prefab to Object To Spawn -parameter in the editor!");
        if (audioInputObject == null)
        {
            audioInputObject = this.gameObject;
        }
            //audioInputObject = GameObject.Find("AudioInputObject");
        micIn = (MicrophoneInput)audioInputObject.GetComponent<MicrophoneInput>();
    }

    void Update()
    {
        float l = micIn.loudness;
        if (l > threshold)
        {
            //GameObject newObject = (GameObject)Instantiate(objectToSpawn, this.transform.position, Quaternion.identity);
            this.GetComponent<Rigidbody>().AddRelativeForce(0, 50, 0);
        }
    }
}
