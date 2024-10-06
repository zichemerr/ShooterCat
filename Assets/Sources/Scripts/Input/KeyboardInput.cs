using UnityEngine;

public class KeyboardInput : IInput
{
	private const string Horizontal = nameof(Horizontal);
	private const string Vertical = nameof(Vertical);

	public Vector2 GetDirection
	{
		get
		{
			return new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
		}
	}
}
