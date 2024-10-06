using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private Transform _player;

    public void Init(Transform player)
    {
		_player = player;
		_agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
        _agent.SetDestination(_player.position);
    }
}
