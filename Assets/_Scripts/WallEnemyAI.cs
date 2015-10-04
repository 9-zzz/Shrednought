using UnityEngine;
using System.Collections;

public class WallEnemyAI : MonoBehaviour
{
    public GameObject deathParticle;

    public int health = 100;
    public float speed;
    public float deathTime;
    public string tagCheck;
    
    public Material orig;
    public Material hurt;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, deathTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagCheck)
        {
            Destroy(col.gameObject);

            health--;

            if (health == 0)
            {
                // Incrememnt on some  other script
                SpawnerTest.S.enemiesKilled++;
                Instantiate(deathParticle, transform.position, transform.rotation);
                Destroy(gameObject);
                //
            }
        }
    }

    IEnumerator hurtFlash()
    {
        this.GetComponent<Renderer>().material = hurt;
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Renderer>().material = orig;
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Renderer>().material = hurt;
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Renderer>().material = orig;
    }

}
