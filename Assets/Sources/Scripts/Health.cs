using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField, Min(1)] private int _health;

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            return;

        _health -= damage;
        Debug.Log(_health);

        if (_health <= 0)
            gameObject.SetActive(false);
    }
}
