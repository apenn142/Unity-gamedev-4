using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room0 : MonoBehaviour
{
    public GameObject player, goblin, monsterSpawn, wallBuilder;
    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < 22; i++)
        {
            wallBuilder.GetComponent<WallBuildScript>().Square(i, 0);
            wallBuilder.GetComponent<WallBuildScript>().Square(i, 9);
        }
        for (int i = 1; i < 9; i++)
        {
            wallBuilder.GetComponent<WallBuildScript>().Square(0, i);
            wallBuilder.GetComponent<WallBuildScript>().Square(21, i);
        }
        wallBuilder.GetComponent<WallBuildScript>().BuildRoom(24, 16);
        wallBuilder.GetComponent<WallBuildScript>().Brazier(5, 3);
        wallBuilder.GetComponent<WallBuildScript>().Brazier(16, 3);
        wallBuilder.GetComponent<WallBuildScript>().Brazier(5, 5);
        wallBuilder.GetComponent<WallBuildScript>().Brazier(16, 5);
        */
        //monsterSpawn.GetComponent<MonsterSpawner>().StartSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
