using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
	[SerializeField] private Enemy[] _enemies;
	[SerializeField] private Sounds _sounds;

	public void Init(Player player)
	{
		foreach (var enemies in _enemies)
			enemies.Init(player, _sounds);
	}
}
