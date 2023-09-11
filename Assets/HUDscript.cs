using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDscript : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    //[SerializeField] private GameObject manaBar;
    [SerializeField] private GameObject xpBar;
    [SerializeField] private Text leveltxt;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        leveltxt.text = "Level: " + player.GetComponent<PlayerLevel>().lvl;
        healthBar.transform.localScale = new Vector3(player.GetComponent<Damage>().health / 6f, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        //  healthBar.transform.localScale = new Vector3(player.GetComponent<Damage>().health / 50f, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        xpBar.transform.localScale = new Vector3((player.GetComponent<PlayerLevel>().xp % 100) / 6f, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        
    }
}
