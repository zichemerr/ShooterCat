using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private int _startHealth;

    private Health _health;

    public void Init()
    {
        _health = new Health(_startHealth);
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
