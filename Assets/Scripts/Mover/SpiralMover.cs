using System.Collections;
using UnityEngine;

public class SpiralMover : MonoBehaviour
{
    [SerializeField] private float _speed; 
    [SerializeField] private float _radius;
    [SerializeField] private float _radiusDecreaseSpeed;
    [SerializeField] private float _rotationMaxSpeed;
    [SerializeField] private float _rotationMinSpeed;

    public void Move(Rigidbody tornadoMovable)
    {
        tornadoMovable.velocity = Vector3.zero;
        StartCoroutine(MoveRoutine(tornadoMovable, Random.Range(_rotationMinSpeed, _rotationMaxSpeed)));
    }

    private IEnumerator MoveRoutine(Rigidbody tornadoMovable, float rotationSpeed)
    {
        float currentRadius = (transform.Vector3YZeroAxisPosition() - tornadoMovable.transform.Vector3YZeroAxisPosition()).magnitude;
        float angle = GetStartAngle(tornadoMovable.position);
        float y = tornadoMovable.position.y;
        Vector3 nextPosition;

        while (enabled)
        {

            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * currentRadius;
            float z = Mathf.Sin(angle * Mathf.Deg2Rad) * currentRadius;
            angle -= rotationSpeed * Time.deltaTime;
            y += _speed * Time.deltaTime;


            if (_radius < currentRadius)
                currentRadius -= _radiusDecreaseSpeed * Time.deltaTime;

            //tornadoMovable.MoveRotation(Quaternion.LookRotation(transform.Vector3YZeroAxisPosition() - tornadoMovable.transform.Vector3YZeroAxisPosition()));
            nextPosition = new Vector3(transform.position.x + x, y, transform.position.z + z);
            tornadoMovable.MovePosition(nextPosition);
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