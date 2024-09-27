using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Player _player;

    private void Start()
    {
        _player.Init();

        foreach (var enemies in _enemies)
            enemies.Init();
    }
}
