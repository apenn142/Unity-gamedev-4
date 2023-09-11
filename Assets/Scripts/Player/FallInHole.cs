using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FallInHole : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnLocation;
    [SerializeField] GameObject fallAudio;
    private Vector3 originalScale;
    [SerializeField] private Animator transition;
    //public static Vector3 loadScenePos;
    
   
    // Start is called before the first frame update
    void Start()
    {
       // if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 6)
      //  {
      //
       // }
       // Vector3 v = new Vector3(0, 0, 0);
        originalScale = player.transform.localScale;    
       // if(loadScenePos != v)
       // {
        //    player.transform.position = loadScenePos;
            //player.transform.position = spawnLocation.position;
            
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("collided with fall zone");
        if (other.gameObject.tag == "fallZone")
        {
            StartCoroutine("fallDown");
        }
        if (other.gameObject.tag == "correctHole")
        {

            StartCoroutine("fallDownC");
        }
        if (other.gameObject.tag == "doorWayForward")
        {
            StartCoroutine("LoadNext");
        }
        if (other.gameObject.tag == "doorWayBackwards")
        {
            StartCoroutine("LoadLast");
        }
    }

    IEnumerator fallDown()
    {
        fallAudio.GetComponent<AudioSource>().Play();
        float xScale = 0;
        float yScale = 0;
        float minScale = Vector3.one.y * .2f;
        xScale = player.transform.localScale.x;
        yScale = player.transform.localScale.y;
        player.GetComponent<Movement>().moveSpeed = 0;
        player.GetComponent<Movement>().speed = 0;
        while (yScale > minScale)
        {
            yScale -= .3f * Time.deltaTime;
            xScale -= .3f * Time.deltaTime;
            Vector3 scale = player.transform.localScale;
            scale.y = yScale;
            scale.x = xScale;
            gameObject.transform.localScale = scale;
            yield return null;
        }
       
        if(SceneManager.GetActiveScene().buildIndex > 1)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Cave2");

        }

        yield return new WaitForSeconds(1);

        player.GetComponent<Movement>().moveSpeed = 0;
        player.GetComponent<Movement>().speed = 5;
        player.transform.localScale = originalScale;   
        player.transform.position = spawnLocation.position;
        player.GetComponent<Damage>().health -= 20;

        
        yield break;

    }

    IEnumerator fallDownC()
    {
        fallAudio.GetComponent<AudioSource>().Play();
        float xScale = 0;
        float yScale = 0;
        float minScale = Vector3.one.y * .2f;
        xScale = player.transform.localScale.x;
        yScale = player.transform.localScale.y;
        player.GetComponent<Movement>().moveSpeed = 0;
        player.GetComponent<Movement>().speed = 0;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        while (yScale > minScale)
        {
            yScale -= .3f * Time.deltaTime;
            xScale -= .3f * Time.deltaTime;
            Vector3 scale = player.transform.localScale;
            scale.y = yScale;
            scale.x = xScale;
            gameObject.transform.localScale = scale;
            yield return null;
        }
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
             
        

        yield break;

    }
    IEnumerator LoadLast()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    IEnumerator LoadNext()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
