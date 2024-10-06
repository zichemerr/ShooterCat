using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Device _device;
    [SerializeField] private JoystickInput _joystickInput;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Movement _movement;
    private IInput _input;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        if (_device == Device.Desktop)
        {
            _joystickInput.Disable();
            _input = new KeyboardInput();
		}
        else
        {
            _input = _joystickInput;
        }

		_movement = new Movement(_rigidbody, _speed);
	}

    private void FixedUpdate()
    {
        _movement.Move(_input.GetDirection);
	}
}
