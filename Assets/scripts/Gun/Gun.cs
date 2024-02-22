using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    //Fields
    public int damage;
    public float fireRate;
    public int curretAmmo;
    public int totalAmmo;

    //Methods
    protected abstract void Shoot();
    public virtual void TryToShoot()
    {

    }
    public abstract void Reloading();
    public abstract void Scope();
}
