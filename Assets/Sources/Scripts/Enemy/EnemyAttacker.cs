using UnityEngine;
using System.Collections;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _damage;

    private bool _isAttacking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _isAttacking = true;
            StartCoroutine(Attack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _isAttacking = false;
    }

    private IEnumerator Attack()
    {
        if (_isAttacking == false)
            yield break;

         _player.TakeDamage(_damage);
        yield return new WaitForSeconds(2);
        StartCoroutine(Attack());
    }
}