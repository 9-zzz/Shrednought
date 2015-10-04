using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))] // Require GUIText component so we can display a text
public class NoteFinder : MonoBehaviour
{
    public static NoteFinder S;

    public GameObject audioInputObject;
    public float threshold = 1.0f;
    MicrophoneInput micIn;

    private GUIText gui_text;

    public bool dPlay = false;
    public bool gPlay = false;
    public bool bPlay = false;
    public bool ePlay = false;

    public bool lightning = false;

    public int count = 0;

    void Awake()
    {
        S = this;
    }

    // Use this for initialization
    void Start()
    {
        gui_text = this.GetComponent<GUIText>();
        if (audioInputObject == null)
            audioInputObject = GameObject.Find("MicMonitor");
        micIn = (MicrophoneInput)audioInputObject.GetComponent("MicrophoneInput");
    }

    // Update is called once per frame
    void Update()
    {
        int f = (int)micIn.frequency; // Get the frequency from our MicrophoneInput script

        Debug.Log(f);

        if (f >= 200 && f <= 205) // Compare the frequency to known value, take possible rounding error in to account
        {
            dPlay = true;
            Debug.Log("D played, count: " + dPlay);
        }
        else
        {
            dPlay = false;
        }

        if (f >= 225 && f <= 229) // Compare the frequency to known value, take possible rounding error in to account
        {
            bPlay = true;
            Debug.Log("B played, count: " + bPlay);
        }
        else
        {
            bPlay = false;
        }


        if (f >= 175 && f <= 185) // Compare the frequency to known value, take possible rounding error in to account
        {
            gPlay = true;
            Debug.Log("G played, count: " + gPlay);
        }
        else
        {
            gPlay = false;
        }

        if (f >= 300 && f <= 325) // Compare the frequency to known value, take possible rounding error in to account
        {
            ePlay = true;
            Debug.Log("E played, count: " + ePlay);
        }
        else
        {
            ePlay = false;
        }

        if(f >= 460 && f <= 500) // going to check if powerup is enabled - if playing between 400-500 and powerup is met - cast lightning
        {
            // needs corouting
            // cant do lighning for a while after... set monster count to zero
            lightning = true;
            Debug.Log("lightning played, count: " + lightning);
        }







        /*
        if (f >= 261 && f <= 262) // Compare the frequency to known value, take possible rounding error in to account
        {
            gui_text.text = "Middle-C played!";
        }
        else
        {
            gui_text.text = "Play another note...";
        }
        */
    }
}
