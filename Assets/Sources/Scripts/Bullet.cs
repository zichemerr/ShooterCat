using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public event Action<Bullet> Deactivated;

    public void Activate(Transform transform)
    {
        _transform.SetPositionAndRotation(transform.position, transform.rotation);
        gameObject.SetActive(true);
        _rigidbody.velocity = transform.up * _speed;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        _rigidbody.velocity = Vector2.zero;
        Deactivated?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>())
            return;

        if (collision.TryGetComponent(out IDamagable damagable))
            damagable.TakeDamage(_damage);

        Deactivate();
    }
}