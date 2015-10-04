using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointLoss : MonoBehaviour {

    public Image fader1;

    public int lives = 3;

	// Use this for initialization
	void Start () {
        fader1.color = Color.red;
        fader1.CrossFadeAlpha(0, 0, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        // if anything for now
        StartCoroutine(flash());
        lives--;
    }

    IEnumerator flash()
    {
        fader1.CrossFadeAlpha(1, 0.25f, true);
        yield return new WaitForSeconds(0.25f);
        fader1.CrossFadeAlpha(0, 0.25f, true);
    }

}
