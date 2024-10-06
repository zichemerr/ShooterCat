using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private Player _player;
	[SerializeField] private EnemyArmy _enemyArmy;

    private void Start()
    {
		_player.Init();
		_enemyArmy.Init(_player);
	}

	private void OnEnable()
	{
		_player.Died += OnDied;
	}

	private void OnDisable()
	{
		_player.Died -= OnDied;
	}

	private void OnDied()
	{
		SceneManager.LoadScene(0);
	}
}
