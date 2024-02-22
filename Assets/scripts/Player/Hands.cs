using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    public Gun[] guns;
    public int EquipedGun = 0;

    private void Start()
    {
        SelectGun(EquipedGun);
    }

    private void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SelectUp();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SelectDown();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void SelectUp()
    {
        if (EquipedGun + 1 >= guns.Length) EquipedGun = 0;
        else EquipedGun++;
        SelectGun(EquipedGun);
    }

    private void SelectDown()
    {
        if (EquipedGun - 1 < 0) EquipedGun = guns.Length-1;
        else EquipedGun--;
        SelectGun(EquipedGun);
    }
    public void SelectGun(int WeaponToEquip)
    {
       for(int i = 0; i < guns.Length; i++)
       {
            guns[i].gameObject.SetActive(false);
       }
       guns[WeaponToEquip].gameObject.SetActive(true);
    }

    public void Shoot()
    {
        guns[EquipedGun].Shoot();
    }
}
