using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private const int _oneMinute = 60;

    [SerializeField] private Transform _point;
    [SerializeField] private Counter _counter;
    [SerializeField] private float _frequency = 1;
    [SerializeField] private int _ammo;
    [SerializeField] private float _reloadDelay;

	private BulletPool _bulletPool;
	private IWeaponSounds _weaponSounds;
    private float _lastShootTime;
    private int _currentAmmo;

    public void Init(BulletPool bulletPool, IWeaponSounds weaponSounds)
    {
        _bulletPool = bulletPool;
        _bulletPool.Init();
        _weaponSounds = weaponSounds;
        _currentAmmo = _ammo;
        _counter.ShowDisplay(_currentAmmo);
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadDelay);
        _currentAmmo = _ammo;
        _counter.ShowDisplay(_currentAmmo);
    }

    public bool CanShoot()
    {
        if (Time.time - _lastShootTime > _oneMinute / _frequency && _currentAmmo > 0)
            return true;
        else
            return false;
    }

    public void Shoot()
    {
        _bulletPool.GetBullet().Activate(_point);
        _weaponSounds.PlayShoot();

        _currentAmmo--;
        _counter.ShowDisplay(_currentAmmo);
        _lastShootTime = Time.time;

        if (_currentAmmo == 0)
            StartCoroutine(Reload());
    }
}
