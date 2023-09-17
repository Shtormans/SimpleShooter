using System;
using System.Collections.Generic;

public class BulletPool
{
    private List<Bullet> _bullets;

    public BulletPool()
    {
        _bullets = new List<Bullet>();
    }

    public Bullet GetBulletOfType(BulletType bulletType)
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (!_bullets[i].isActiveAndEnabled 
                && _bullets[i].Type == bulletType)
            {
                return _bullets[i];
            }
        }

        var bullet = BulletFactory.CreateBulletOfType(bulletType);
        _bullets.Add(bullet);

        return bullet;
    }
}
