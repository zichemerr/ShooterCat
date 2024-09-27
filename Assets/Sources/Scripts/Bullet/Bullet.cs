using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public event Action<Bullet> Deactivated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(_damage);
            Deactivate();
        }
    }

    private IEnumerator StatDelay()
    {
        yield return new WaitForSeconds(_delay);
        Deactivate();
    }

    public void Activate(Transform transform)
    {
        _transform.SetPositionAndRotation(transform.position, transform.rotation);
        gameObject.SetActive(true);
        _rigidbody.velocity = transform.up * _speed;
        StartCoroutine(StatDelay());
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        _rigidbody.velocity = Vector2.zero;
        Deactivated?.Invoke(this);
    }
}
