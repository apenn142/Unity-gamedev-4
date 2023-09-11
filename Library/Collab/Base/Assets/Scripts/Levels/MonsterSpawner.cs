using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject goblin, player;
    private int roomShiftX, roomShiftY;
    // Start is called before the first frame update

    private void Start()
    {
        StartSpawn();
    }
    public void StartSpawn()
    {
        roomShiftX = 22;
        roomShiftY = 10;
        //roomx roomy floorx floory
        
        //[0, 1]
        SpawnGoblin(0, 1, -3, 4);
        SpawnGoblin(0, 1, -2, 1);
        SpawnGoblin(0, 1, -3, -1);
        //[-1, 0]
        SpawnGoblin(-1, 0, -8, 3);
        SpawnGoblin(-1, 0, -2, 2);
        SpawnGoblin(-1, 0, -3, -3);
        //[1, 0]
        SpawnGoblin(1, 0, 1, 3);
        SpawnGoblin(1, 0, 7, 3);
        SpawnGoblin(1, 0, 2, -1);
        SpawnGoblin(1, 0, -5, -2);
        SpawnGoblin(1, 0, 9, -2);
        //[0, 2]
        SpawnGoblin(0, 2, 3, 3);
        SpawnGoblin(0, 2, -2, 1);
        SpawnGoblin(0, 2, 2, 1);
        SpawnGoblin(0, 2, 1, 0);
        SpawnGoblin(0, 2, -5, -1);
        //[-1, 2]
        SpawnGoblin(-1, 2, 4, 3);
        SpawnGoblin(-1, 2, -4, 1);
        SpawnGoblin(-1, 2, -9, 0);
        SpawnGoblin(-1, 2, -4, -1);
        SpawnGoblin(-1, 2, -8, -2);
        SpawnGoblin(-1, 2, 4, -3);
        //[1, 2]
        SpawnGoblin(1, 2, -4, 3);
        SpawnGoblin(1, 2, 7, 2);
        SpawnGoblin(1, 2, 1, 1);
        SpawnGoblin(1, 2, 4, 1);
        SpawnGoblin(1, 2, 1, -1);
        SpawnGoblin(1, 2, 4, -1);
        SpawnGoblin(1, 2, 9, 0);
        SpawnGoblin(1, 2, 8, -2);
        //[-1, 3]
        SpawnGoblin(-1, 3, -1, 2);
        SpawnGoblin(-1, 3, -1, -2);
        SpawnGoblin(-1, 3, -4, 0);
        //[0, 3]
        SpawnGoblin(0, 3, -5, 3);
        SpawnGoblin(0, 3, -2, 3);
        SpawnGoblin(0, 3, -3, 1);
        SpawnGoblin(0, 3, 3, 1);
        SpawnGoblin(0, 3, -4, -2);
        //[0, 4]
        SpawnGoblin(0, 4, -6, 2);
        SpawnGoblin(0, 4, 7, 2);
        SpawnGoblin(0, 4, -4, 0);
        //[0, 5]
        SpawnGoblin(0, 5, 2, 3);
        SpawnGoblin(0, 5, 1, 1);
        SpawnGoblin(0, 5, 5, -1);
    }

    public void SpawnGoblin(int roomX, int roomY, int floorX, int floorY)
    {
        GameObject temp = Instantiate(goblin, new Vector2( ((roomX * roomShiftX) + floorX), ((roomY * roomShiftY) + floorY) ), Quaternion.identity);
        temp.GetComponent<GoblinBehaviour>().target = player;
        temp.GetComponent<EnemyAwareness>().player = player;
        temp.GetComponent<GoblinMove>().player = player;
        temp.SetActive(true);
    }
    private void Start()
    {
        StartSpawn();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
