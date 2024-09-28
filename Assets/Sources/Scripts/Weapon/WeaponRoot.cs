﻿using UnityEngine;

public class WeaponRoot : MonoBehaviour
{
    [SerializeField] private WeaponInput _weaponInput;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private WeaponSounds _sound;
    [SerializeField] private BulletPool _bulletPool;

    public void Init()
    {
        _weapon.Init(_bulletPool);
    }

    private void OnEnable()
    {
        _weaponInput.Shooted += OnShooted;
    }

    private void OnDisable()
    {
        _weaponInput.Shooted -= OnShooted;
    }

    private void OnShooted()
    {
        if (_weapon.CanShoot() == false)
            return;

        _weapon.Shoot();
        _sound.PlayShoot();
    }
}
