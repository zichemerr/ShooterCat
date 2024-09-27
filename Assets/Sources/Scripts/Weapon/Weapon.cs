using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField, Min(1)] private float _frequency = 1;

    private float _lastShootTime;

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
