using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            return;

        _health -= damage;
        Debug.Log(_health);

        if (_health <= 0)
            SceneManager.LoadScene(0);
    }
}
