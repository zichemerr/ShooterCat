using UnityEngine;

public class Enemy : Health
{
	[SerializeField] private EnemyMovement _enemyMovement;
	[SerializeField] private EnemyAttacker _enemyAttacker;

	public void Init(Player player)
	{
		_enemyMovement.Init(player.transform);
		_enemyAttacker.Init(player);
	}

	private void OnEnable()
	{
		Died += OnDied;
	}

	private void OnDisable()
	{
		Died -= OnDied;
	}

	private void OnDied()
	{
		Destroy(gameObject);
	}
}
