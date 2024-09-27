using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private Joystick _joystick;
    [SerializeField] private DeviceInput DeviceInput;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if (DeviceInput == DeviceInput.Desktop)
            _joystick.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {   
        if (DeviceInput == DeviceInput.Mobile)
            SetInput(_joystick.Horizontal, _joystick.Vertical);
        else
            SetInput(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

        _rigidbody.velocity = _movementInput * _speed;
    }

    private void SetInput(float horizontal, float vertical)
    {
        _movementInput = new Vector2(horizontal, vertical);
    }
}

public enum DeviceInput
{
    Desktop,
    Mobile
}
