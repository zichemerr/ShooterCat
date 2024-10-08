using UnityEngine;

public class Player : Unit
{
	[SerializeField] private PlayerMovement _playerMovement;
	[SerializeField] private WeaponInput _weaponInput;
	[SerializeField] private Weapon _weapon;
	[SerializeField] private BulletPool _bulletPool;
	[SerializeField] private Sounds _sounds;

	public void Init()
	{
		Init(_sounds);
		_playerMovement.Init();
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
	}
}
