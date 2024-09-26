using UnityEngine;

public class TurellRotation : MonoBehaviour
{
    private const float DeadZone = 0.3f;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _offset;

    private float _forwardRotation;

    private void Update()
    {
        if (CanRotate(_joystick.Vertical) || CanRotate(_joystick.Horizontal))
            _forwardRotation = Mathf.Atan2(_joystick.Vertical, _joystick.Horizontal) * Mathf.Rad2Deg;

        if (_joystick.Horizontal > DeadZone)
            _renderer.flipY = false;
        else if (_joystick.Horizontal < -DeadZone)
            _renderer.flipY = true;

        transform.rotation = Quaternion.Euler(0, 0, _forwardRotation + _offset);
    }

    private bool CanRotate(float direction)
    {
        if (Mathf.Abs(direction) > DeadZone)
            return true;

        return false;
    }
}
