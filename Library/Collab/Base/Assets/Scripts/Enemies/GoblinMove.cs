using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class GoblinMove : MonoBehaviour
{
    public GameObject player;
    public float baseSpeed;
    public float speed;
    private bool ret;
    private bool charge;
    public Vector3 target;
    public float targetDist;
    public float targetAngle;
    public float followDist;
    public float attackDist;
    public float tempDist;
    public float followDir;

    // Start is called before the first frame update
    void Start()
    {
        speed = baseSpeed;
        ret = false;
        charge = true;
        tempDist = followDist;
        player = GetComponent<EnemyAwareness>().player;
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position - transform.position;
        targetDist = Mathf.Sqrt(Mathf.Pow(target.x, 2) + Mathf.Pow(target.y, 2));
        targetAngle = Mathf.Atan2(-target.x, target.y) * Mathf.Rad2Deg;

        followDir = (targetDist - tempDist) / Mathf.Abs(targetDist - tempDist);
        if (Mathf.Abs(targetDist - tempDist) < .2f)
            followDir = 0;

        Vector3 oldPos = transform.position;

        if (speed != 0)
        {
            transform.rotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
            transform.Translate(speed * Vector3.up * Time.deltaTime);
            GetComponent<Animator>().SetBool("moving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("moving", false);
        }

        Vector3 newPos = transform.position;
        if (oldPos.x - newPos.x > 0)
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
        if (oldPos.x - newPos.x < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        // gameObject.GetComponent<SpriteRenderer>().flipX.Equals(false);

        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    public void Follow()
    {
        //speed = baseSpeed * followDir / 2;
        speed = baseSpeed;
    }
    public void Retreat()
    {
        speed = -baseSpeed;
    }

    public void Charge()
    {
        speed = baseSpeed * 1.5f;
    }
    public void Still()
    {
        speed = 0;
    }
}
