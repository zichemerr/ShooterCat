using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int _health;

    public event Action Died;

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            return;

        _health -= damage;

        if (_health <= 0)
			Died?.Invoke();
	}
}
