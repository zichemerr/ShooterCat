using UnityEngine;
using System;
using System.Collections;

public class WeaponInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _inputDelay;

    public event Action Shooted;

    private void Update()
    {
        if (Mathf.Abs(_joystick.Vertical) > 0.3f || Mathf.Abs(_joystick.Horizontal) > 0.3f)
            StartCoroutine(InputDelay());
    }

    private IEnumerator InputDelay()
    {
        yield return new WaitForSeconds(_inputDelay);
        Shooted?.Invoke();
    }
}