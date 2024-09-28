using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _player;

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
        _agent.SetDestination(_player.position);
    }
}
