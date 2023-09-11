using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] deleteThese;
    [SerializeField] private AudioSource castleMusic;
    public static bool hasPlayed = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Altar.numAltars == 6)
        {
            
            if (!hasPlayed)
                StartCoroutine("doorAudio");

            int length = deleteThese.Length;
            for (int i = 0; i < length; i++)
            {
                Destroy(deleteThese[i]);
            }
        }
    }
    IEnumerator doorAudio()
    {
        hasPlayed = true;
        Altar.numAltars = 0;
        castleMusic.Stop();
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4);
        castleMusic.Play();
    }
}
