using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField, Min(1)] private float _frequency = 1;

    private BulletPool _bulletPool;
    private float _lastShootTime;

    public void Init(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
        _bulletPool.Init();
    }

    public bool CanShoot()
    {
        if (Time.time - _lastShootTime > 60 / _frequency)
            return true;
        else
            return false;
    }

    public void Shoot()
    {
        _bulletPool.GetBullet().Activate(_point);

        _lastShootTime = Time.time;
    }
}
