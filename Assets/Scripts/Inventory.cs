using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    [SerializeField] private List<Weapon> weapons = new List<Weapon>();

    public void AddWeapon(Weapon w)
    {
        weapons.Add(w);
    }

    public Weapon GetWeapon(int index)
    {
        return weapons[index];
    }
}
