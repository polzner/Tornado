using UnityEngine;

public class Mover : MonoBehaviour
{
	[SerializeField] private Transform _camera;
	[SerializeField] private Rigidbody _body;
	[SerializeField, Range(0f, 100f)] float maxSpeed = 10f;
	[SerializeField, Range(0f, 100f)] float maxAcceleration = 10f;
	[SerializeField] Rect allowedArea = new Rect(-5f, -5f, 10f, 10f);

	Vector3 velocity;

	public void Move(Vector2 input)
	{
		Vector2 playerInput = input;

		playerInput = Vector2.ClampMagnitude(playerInput, 1f);

		Vector3 desiredVelocity = (_camera.forward * playerInput.y + _camera.right * playerInput.x) * maxSpeed;

		float maxSpeedChange = maxAcceleration * Time.deltaTime;
		velocity.x =
			Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
		velocity.z =
			Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

		Vector3 displacement = velocity * Time.deltaTime;
		Vector3 newPosition = transform.localPosition + displacement;

		if (newPosition.x < allowedArea.xMin)
		{
			newPosition.x = allowedArea.xMin;
			velocity.x = 0f;
		}
		else if (newPosition.x > allowedArea.xMax)
		{
			newPosition.x = allowedArea.xMax;
			velocity.x = 0f;
		}
		if (newPosition.z < allowedArea.yMin)
		{
			newPosition.z = allowedArea.yMin;
			velocity.z = 0f;
		}
		else if (newPosition.z > allowedArea.yMax)
		{
			newPosition.z = allowedArea.yMax;
			velocity.z = 0f;
		}

		_body.MovePosition(newPosition);
	}
}
