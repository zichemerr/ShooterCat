using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Player _player;
    [SerializeField] private int _startHealth;
    [SerializeField] private int _damage;

    private Health _health;
    private bool _isWalking = true;

    public void Init()
    {
        _health = new Health(_startHealth);
        _health.Died += OnDied;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void OnDied()
    {
        Destroy(this);
    }

    private void FixedUpdate()
    {
        if (_isWalking)
            _agent.destination = _player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _isWalking = false;
            StartCoroutine(Attack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
            _isWalking = true;
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);

        if (_isWalking)
            yield break;

        _player.TakeDamage(_damage);
        StartCoroutine(Attack());
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}