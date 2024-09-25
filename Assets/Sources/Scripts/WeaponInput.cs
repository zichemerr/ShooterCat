using UnityEngine;
using System;

public class WeaponInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    public event Action Shooted;

    private void Update()
    {
        if (Mathf.Abs(_joystick.Vertical) > 0.3f || Mathf.Abs(_joystick.Horizontal) > 0.3f)
            Shooted?.Invoke();
    }
}