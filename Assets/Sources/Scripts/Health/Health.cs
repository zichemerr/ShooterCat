using System;

public class Health
{
	public event Action ValueChanged;

	public Health(int value)
	{
		Value = value;
	}

	public int Value { get; private set; }

	public void TakeDamage(int damage)
	{
		if (damage <= 0)
			return;

		Value -= damage;
		ValueChanged?.Invoke();
	}
}