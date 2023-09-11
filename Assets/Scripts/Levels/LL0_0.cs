using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LL0_0 : MonoBehaviour
{
    public GameObject player, walls, mobs, camera;

    void Start()
    {
        //player = GetComponent<PlayerGenerator>().NewPlayer(PlayerPrefs.GetInt("Class"));
        //GetComponent<PlayerGenerator>().player.gameObject.transform.position = new Vector2(0, 0);
        walls.GetComponent<WallBuildScript>().StartBuild();
        Debug.Log("WALLS BUILT");
        mobs.GetComponent<MonsterSpawner>().player = player;
        mobs.GetComponent<MonsterSpawner>().StartSpawn();
        Debug.Log("MOBS SPAWNED");
        //Debug.Log(PlayerPrefs.GetInt("Class").ToString());
        //player.SetActive(true);
        camera.GetComponent<CameraMovement>().player = player;
    }
}
