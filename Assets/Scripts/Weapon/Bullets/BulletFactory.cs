using System;
using UnityEngine;

public class BulletFactory
{
    private static GameObject _bulletPrefab;

    static BulletFactory()
    {
        _bulletPrefab = Resources.Load<GameObject>(ResourcesPaths.ToBulletPrefabsFolder);
    }

    public static Bullet CreateBulletOfType(BulletType type)
    {
        var bulletPrefab = GetBullet(type);

        var bulletObject = UnityEngine.Object.Instantiate(bulletPrefab);
        bulletObject.SetActive(false);

        var bullet = bulletObject.GetComponent<Bullet>();

        return bullet;
    }

    private static GameObject GetBullet(BulletType type)
    {
        var path = $@"{ResourcesPaths.ToBulletPrefabsFolder}/{type}";
        
        return Resources.Load<GameObject>(path);
    }
}
