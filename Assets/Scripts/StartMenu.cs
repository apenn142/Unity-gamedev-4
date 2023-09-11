using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Text txtTitle, txtMenu;
    public Button btn1, btn2, btn3, btn4;
    public int state;

    void Start()
    {
        SetGUI(0);
        state = 0;
    }

    public void ButtonPress(int num)
    {
        if (state == 0)
        {
            SetGUI(1);
            state = 1;
        }
        else if (state == 1)
        {
            PlayerPrefs.SetInt("Class", num);
            SetGUI(2);
            state = 2;
        }
        else if (state == 2)
        {
            PlayerPrefs.SetInt("Weapon", num);
            SceneManager.LoadScene("0.0");
        }
    }

    void SetGUI(int set)
    {
        switch (set)
        {
            case 0:
                txtTitle.gameObject.SetActive(true);
                txtMenu.gameObject.SetActive(false);

                btn1.gameObject.SetActive(false);
                btn2.gameObject.SetActive(false);
                btn3.gameObject.SetActive(false);
                btn4.gameObject.SetActive(true);
                btn4.GetComponentInChildren<Text>().text = "START GAME";

                break;

            case 1:
                txtTitle.gameObject.SetActive(false);
                txtMenu.gameObject.SetActive(true);
                btn4.GetComponentInChildren<Text>().text = "SELECT CLASS";

                btn1.gameObject.SetActive(true);
                btn2.gameObject.SetActive(true);
                btn3.gameObject.SetActive(true);
                btn4.gameObject.SetActive(true);
                btn1.GetComponentInChildren<Text>().text = "FIGHTER";
                btn2.GetComponentInChildren<Text>().text = "WIZARD";
                btn3.GetComponentInChildren<Text>().text = "ROGUE";
                btn4.GetComponentInChildren<Text>().text = "CLERIC";

                break;

            case 2:
                txtTitle.gameObject.SetActive(false);
                txtMenu.gameObject.SetActive(true);

                btn1.gameObject.SetActive(true);
                btn2.gameObject.SetActive(true);
                btn3.gameObject.SetActive(true);
                btn4.gameObject.SetActive(true);

                if (PlayerPrefs.GetInt("Class") == 1)
                {
                    btn4.GetComponentInChildren<Text>().text = "FIGHTER: SELECT WEAPON";
                    btn1.GetComponentInChildren<Text>().text = "SWORD";
                    btn2.GetComponentInChildren<Text>().text = "SPEAR";
                    btn3.GetComponentInChildren<Text>().text = "AXE";
                    btn4.GetComponentInChildren<Text>().text = "HAMMER";
                }

                if (PlayerPrefs.GetInt("Class") == 2)
                {
                    btn4.GetComponentInChildren<Text>().text = "MAGE: SELECT MAGIC";
                    btn1.GetComponentInChildren<Text>().text = "COMBAT"; //fire ball, cone of frost
                    btn2.GetComponentInChildren<Text>().text = "SUPPORT"; //water gun, wind heal
                    btn3.GetComponentInChildren<Text>().text = "ORDER"; //blinding light, earth wall 
                    btn4.GetComponentInChildren<Text>().text = "CHAOS"; //dark tentacle, lightning strike
                }

                if (PlayerPrefs.GetInt("Class") == 3)
                {
                    btn4.GetComponentInChildren<Text>().text = "ROGUE: SELECT EQUIPMENT";
                    btn1.GetComponentInChildren<Text>().text = "LONGBOW AND DAGGER";
                    btn2.GetComponentInChildren<Text>().text = "LONGBOW AND RAPIER";
                    btn3.GetComponentInChildren<Text>().text = "CROSSBOW AND DAGGER";
                    btn4.GetComponentInChildren<Text>().text = "CROSSBOW AND RAPIER";
                }

                if (PlayerPrefs.GetInt("Class") == 4)
                {
                    btn4.GetComponentInChildren<Text>().text = "CLERIC: SELECT DIETY";
                    btn1.GetComponentInChildren<Text>().text = "SUN";   //light and fire
                    btn2.GetComponentInChildren<Text>().text = "SKY";   //lightning and air
                    btn3.GetComponentInChildren<Text>().text = "LAND";  //ice and earth
                    btn4.GetComponentInChildren<Text>().text = "SEAS";  //water and darkness
                }

                break;
        }
    }
}
