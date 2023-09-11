using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerAction : MonoBehaviour
{
    public int playerClass;
    public int state = 0; //(0=dead, 1=idle, 2=attacking, 3=shielding, 4=evading)
    public bool paused;
    public GameObject spellScreen, fade, inputHints, txtInfo;

    private void Start()
    {
        fade.SetActive(true);
        paused = false;
    }
    void Update()
    {
        
    }
    public void OnPrimary(InputValue value)
    {
        GetComponent<FighterAttack>().Attack();
    }

    public void OnSecondary(InputValue value)
    {
        GetComponent<WizardAttack>().Spell();
    }

    public void OnClassSelect(InputValue value)
    {
        GetComponent<WizardAttack>().SelectSpell(int.Parse(value.Get().ToString()));
    }
    public void OnWeaponSelect(InputValue value)
    {
        //Debug.Log(value.Get().ToString());
    }


    public void OnPause(InputValue value)
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            spellScreen.SetActive(false);
            inputHints.SetActive(true);
            txtInfo.SetActive(true);
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            spellScreen.SetActive(true);
            inputHints.SetActive(false);
            txtInfo.SetActive(false);
        }
    }
}
