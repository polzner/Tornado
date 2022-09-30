using System.Collections;
using UnityEngine;

public class SpiralMover : MonoBehaviour
{
    [SerializeField] private AnimationCurve _radiusCurve;
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxHeight;

    public void Move(Rigidbody tornadoMovable)
    {
        StartCoroutine(MoveRoutine(_maxHeight, tornadoMovable));
    }

    private IEnumerator MoveRoutine(float targetYPosition, Rigidbody tornadoMovable)
    {
        float angle = GetStartAngle(tornadoMovable.position);
        float y = tornadoMovable.position.y;
        Vector3 currentPosition;

        while (tornadoMovable.position.y < targetYPosition)
        {
            float normalizedHeight = Mathf.Clamp(transform.position.y / _maxHeight, 0, 1f);
            float radius = _radius * _radiusCurve.Evaluate(normalizedHeight);
            angle += _rotationSpeed * Time.deltaTime;

            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float z = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            y += _speed * Time.deltaTime;

            currentPosition = transform.position + new Vector3(x, y, z);
            tornadoMovable.MovePosition(currentPosition);
            yield return null;
        }        
    }

    private float GetStartAngle(Vector3 itemPosition)
    {
        Vector3 direction = itemPosition - transform.position;
        float dotProduction = Vector3.Dot(transform.InverseTransformVector(transform.right), direction);
        float sideDetectionDotProduction = Vector3.Dot(transform.InverseTransformVector(transform.forward), direction);
        float angle = Mathf.Acos(dotProduction / direction.magnitude) * Mathf.Rad2Deg;
        angle = sideDetectionDotProduction < 0 ? -angle : angle;
        return angle;
    }
}
