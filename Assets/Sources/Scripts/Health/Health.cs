using System;

public class Health
{
    private int _health;

    public event Action Died;

    public Health(int health)
    {
        _health = health;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            return;

        _health -= damage;

        if (_health <= 0)
            Died?.Invoke();
    }
}

