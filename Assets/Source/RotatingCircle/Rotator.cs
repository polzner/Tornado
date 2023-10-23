using UnityEngine;

public class Rotator
{
    private RotateInputRouter _router;
    private Transform _rotateTransform;
    private float _rotationSpeed;
    private float _snapAngle;
    private Quaternion _targetRotation;
    private float _snappedAngle;
    private float _elapsedTime;
    private float _inertialRotationSpeed;

    public Rotator(RotateInputRouter router, Transform rotateTransform, float rotationSpeed, float snapAngle)
    {
        _router = router;
        _rotateTransform = rotateTransform;
        _rotationSpeed = rotationSpeed;
        _snapAngle = snapAngle;
    }

    public void Start()
    {
        _targetRotation = _rotateTransform.rotation;
    }

    public void Rotate()
    {
        _elapsedTime = 0f;
        float rotationAmount = -_router.RotationInput * _rotationSpeed * Time.deltaTime;
        _inertialRotationSpeed = rotationAmount;
        _targetRotation *= Quaternion.Euler(0f, rotationAmount, 0f);
        _rotateTransform.rotation = _targetRotation;
    }

    public void SnapRotate()
    {
        float step = _rotationSpeed / 5f * Time.deltaTime;

        if (_elapsedTime < 1f && _inertialRotationSpeed != 0f)
        {
            _targetRotation *= Quaternion.Euler(0f, _inertialRotationSpeed, 0f);
            _rotateTransform.rotation = _targetRotation;
            _inertialRotationSpeed = Mathf.MoveTowards(_inertialRotationSpeed, 0, step);
        }

        if (_elapsedTime >= 1f || _inertialRotationSpeed == 0f)
        {
            float currentAngle = _rotateTransform.rotation.eulerAngles.y;
            _snappedAngle = Mathf.Round(currentAngle / _snapAngle) * _snapAngle;
            _targetRotation = Quaternion.Euler(0f, Mathf.MoveTowards(currentAngle, _snappedAngle, 100f * Time.deltaTime), 0f);
            _rotateTransform.rotation = _targetRotation;
        }

        _elapsedTime += Time.deltaTime;
    }
}
