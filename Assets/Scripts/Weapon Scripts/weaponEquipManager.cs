using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponEquipManager : MonoBehaviour
{
    /*
     * This script manages the player's currently equipped weapon based on their input
     */
    public float currentWeapon = 0;
    public float numOfWeapons;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject grenade;
    private playerLifeManager healthGetter;
    void Start()
    {
        healthGetter = GameObject.Find("Player").GetComponent<playerLifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthGetter.isAlive)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (currentWeapon == numOfWeapons - 1)
                {
                    currentWeapon = 0f;
                }
                else
                {
                    currentWeapon += 1f;
                }
                handleEquipped();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (currentWeapon == 0)
                {
                    currentWeapon = numOfWeapons - 1;
                }
                else
                {
                    currentWeapon -= 1f;
                }
                handleEquipped();
            }
            if (Input.GetKeyDown("1"))
            {
                currentWeapon = 0;
                handleEquipped();
            }
            else if (Input.GetKeyDown("2"))
            {
                currentWeapon = 1;
                handleEquipped();
            }
            else if (Input.GetKeyDown("3"))
            {
                currentWeapon = 2;
                handleEquipped();
            }
        }
    }

    void handleEquipped()
    {
        switch (currentWeapon)
        {
            case 0:
                pistol.SetActive(true);
                shotgun.SetActive(false);
                grenade.SetActive(false);
                break;
            case 1:
                pistol.SetActive(false);
                shotgun.SetActive(true);
                grenade.SetActive(false);
                break;
            case 2:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                grenade.SetActive(true);
                break;
        }
    }
}
