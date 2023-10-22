using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float weaponIndicator;
    public GameObject[] weapons;

    void Start()
    {
        SwitchWeapons(0);

    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        SwitchWeapons(1);

        if(Input.GetKeyDown(KeyCode.Alpha2))
        SwitchWeapons(2);

        if(Input.GetKeyDown(KeyCode.Alpha3))
        SwitchWeapons(0);
        
    }

    public void SwitchWeapons(int index)
    {
        for(int i = 0; i < weapons.Length; i++)
        //Disables all weapons
        weapons[i].SetActive(false);

        weapons[index].SetActive(true);

        weaponIndicator = index;

        print("Current weapon: " + weaponIndicator);

    }

    
}
