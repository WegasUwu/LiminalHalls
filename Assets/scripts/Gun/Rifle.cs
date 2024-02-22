using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    public Transform muzzle;
    private override void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(muzzle.position, muzzle.forward,out hit,1000))
        {
            print(hit.transform.name);
            IDamageble damageble = hit.transform.GetComponent<IDamageble>();
            if(damageble != null)
            {
                damageble.GetDamage(damage);
            } 
        }
    }
    public override void Reloading()
    {
        
    }
    public override void Scope()
    {
        
    }
}
