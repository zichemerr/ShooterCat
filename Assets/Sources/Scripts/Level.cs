using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private WeaponRoot _weaponRoot;

    private void Start()
    {
        _weaponRoot.Init();
    }
}
