using UnityEngine;

public class TurellRotation : MonoBehaviour
{
    private const float _deadZone = 0.3f;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _offset;

    private float _forwardRotation;

    private void Update()
    {
        if (Mathf.Abs(_joystick.Vertical) > _deadZone || Mathf.Abs(_joystick.Horizontal) > _deadZone)
            _forwardRotation = Mathf.Atan2(_joystick.Vertical, _joystick.Horizontal) * Mathf.Rad2Deg;

        if (_joystick.Horizontal > _deadZone)
            _renderer.flipY = false;
        else if (_joystick.Horizontal < -_deadZone)
            _renderer.flipY = true;

        transform.rotation = Quaternion.Euler(0, 0, _forwardRotation + _offset);
    }
}
