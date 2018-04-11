using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float bulletSpeed;
    public Color bulletColor;
    public float fireRate;
    public string layer;
    bool canFire = true;

    public List<GameObject> firepoints;

    public void Shoot()
    {
        if (canFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        foreach (var item in firepoints)
        {
            Bullet bullet = ServiceManager.bulletManager.GetBullet().GetComponent<Bullet>();
            bullet.Fire();
            bullet.Setup(item.transform.position, item.transform.up * bulletSpeed, layer, bulletColor);
            canFire = false;
            Invoke("CanFire", fireRate);
        }
    }

    void CanFire()
    {
        canFire = true;
    }


}
