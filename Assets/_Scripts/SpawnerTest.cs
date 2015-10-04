using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnerTest : MonoBehaviour
{
    public Image faderwhite;

    public static SpawnerTest S;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;

    public int enemiesKilled = 0;

    void Awake()
    {
        S = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NoteFinder.S.dPlay)
            Instantiate(obj1, transform.position, transform.rotation); //red - D

        if (NoteFinder.S.gPlay)
            Instantiate(obj2, transform.position, transform.rotation); //green - B

        if (NoteFinder.S.bPlay)
            Instantiate(obj3, transform.position, transform.rotation); //blue - G

        if (NoteFinder.S.ePlay)
            Instantiate(obj4, transform.position, transform.rotation); //yellow - low E

        if (enemiesKilled >= 5)
        {
            if (NoteFinder.S.lightning)
            {
                StartCoroutine(Thunder());
                enemiesKilled = 0;
            }
        }
    }

    IEnumerator Thunder()
    {
        faderwhite.color = Color.white;
        faderwhite.CrossFadeAlpha(1, 0.34f, true);
        DestroyAllObjects("walls");
        yield return new WaitForSeconds(0.35f);
        faderwhite.CrossFadeAlpha(0, 0.34f, true);
    }

    void DestroyAllObjects(string tag)
    {
        var gameObjects = GameObject.FindGameObjectsWithTag(tag);

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
            //gameObjects[i].GetComponent<WallEnemyAI>().health = 0;
        }
    }

}
