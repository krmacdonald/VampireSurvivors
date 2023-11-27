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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(currentWeapon == numOfWeapons - 1)
            {
                currentWeapon = 0f;
            }
            else
            {
                currentWeapon += 1f;
            }
        }else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWeapon == 0)
            {
                currentWeapon = numOfWeapons - 1;
            }
            else
            {
                currentWeapon -= 1f;
            }
        }
        if (Input.GetKeyDown("1"))
        {
            currentWeapon = 0;
        }else if (Input.GetKeyDown("2"))
        {
            currentWeapon = 1;
        }else if (Input.GetKeyDown("3"))
        {
            currentWeapon = 2;
        }
        handleEquipped();
    }

    void handleEquipped()
    {
        if(currentWeapon == 0)
        {
            pistol.SetActive(true);
        }
        else
        {
            pistol.SetActive(false);
        }
    }
}
