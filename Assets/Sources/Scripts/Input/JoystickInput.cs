using UnityEngine;

public class JoystickInput : MonoBehaviour, IInput
{
	[SerializeField] private Joystick _joystick;

	public Vector2 GetDirection
	{
		get
		{
			return new Vector2(_joystick.Horizontal, _joystick.Vertical);
		}
	}

	public void Disable()
	{
		gameObject.SetActive(false);
	}
}