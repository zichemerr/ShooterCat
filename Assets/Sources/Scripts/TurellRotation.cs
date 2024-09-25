using UnityEngine;

public class TurellRotation : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _offset;

    private float _forwardRotation;

    private void Update()
    {
        if (Mathf.Abs(_joystick.Vertical) > 0.3f || Mathf.Abs(_joystick.Horizontal) > 0.3f)
            _forwardRotation = Mathf.Atan2(_joystick.Vertical, _joystick.Horizontal) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, _forwardRotation + _offset);
    }
}
