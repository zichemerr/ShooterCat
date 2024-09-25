using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField, Min(1)] private int _damage = 1;

    private WeaponRaycast _weaponRaycast;

    [Space(10)]
    [Header("Shoot settings")]
    [SerializeField, Min(1)] private float _frequency = 1;

    private float _lastShootTime;

    private void Start()
    {
        _weaponRaycast = new WeaponRaycast();
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
        RaycastHit2D hitInfo = Physics2D.Raycast(_point.position, _point.up);

        if (hitInfo.collider != null)
            if (hitInfo.collider.TryGetComponent(out IDamagable damagable))
                damagable.TakeDamage(_damage);

        _lastShootTime = Time.time;
    }
}
