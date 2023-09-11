using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class towerManager : MonoBehaviour
{
    public static int numEnemiesDead;
    public int numEnemiesExist;
    private bool did = false;
    // Start is called before the first frame update
    void Start()
    {
        numEnemiesDead = 0;
    }

    // Update is called once per frame
    void Update()
    {
        print(numEnemiesExist);
        print(numEnemiesDead);
        print(Altar.numAltars);
       if(numEnemiesDead == numEnemiesExist && !did)
        {
            did = true;
            Altar.numAltars = 6; //triggers the locked door script to open the door
        } 
    }

   
}
