using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IDamagable
{
    [SerializeField] private int _startHealth;

	private Health _health;
    private ISounds _sounds;

    public event Action Died;

	protected void Init(ISounds sounds)
	{
		_health = new Health(_startHealth);
		_health.ValueChanged += OnValueChanged;
		_sounds = sounds;
	}

	private void OnDisable()
	{
		_health.ValueChanged -= OnValueChanged;
	}

	private void OnValueChanged()
	{
		if (_health.Value <= 0)
			Died.Invoke();
	}

	public void TakeDamage(int damage)
    {
		_health.TakeDamage(damage);
		_sounds.PlayHit();
	}
}
