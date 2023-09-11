using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private float health;
    public Sprite death;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        health = GetComponent<Damage>().health;
        if (health <= 0)
        {
            if (dead == false)
            {
                dead = true;
                GetComponent<EnemyAwareness>().player.gameObject.GetComponent<PlayerLevel>().addXP(10);
            }
            //StartCoroutine("deathStart");
            gameObject.GetComponent<Animator>().SetBool("dead", true);
            GetComponent<Animator>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().sprite = death;
            GetComponent<GoblinBehaviour>().enabled = false;
            GetComponent<GoblinMove>().enabled = false;
            GetComponent<Damage>().enabled = false;
            // GetComponent<Rigidbody2D>().freezeRotation = true;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            gameObject.transform.position = gameObject.transform.position;
            Destroy(gameObject, 20);
        }
    }

    IEnumerator deathStart()
    {
        yield return new WaitForSeconds(1);
    }
}
