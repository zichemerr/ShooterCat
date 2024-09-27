using UnityEngine;
using System;
using System.Collections;

public class WeaponInput : MonoBehaviour
{
    private const float DeadZone = 0.3f;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _inputDelay;

    public event Action Shooted;

    private void Update()
    {
        if (CanShoot(_joystick.Horizontal) || CanShoot(_joystick.Vertical))
            StartCoroutine(InputDelay());
    }

    private IEnumerator InputDelay()
    {
        yield return new WaitForSeconds(_inputDelay);
        Shooted?.Invoke();
    }

    private bool CanShoot(float direction)
    {
        if (Mathf.Abs(direction) > DeadZone)
            return true;

        return false;
    }
}