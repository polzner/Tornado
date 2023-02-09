using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Rotate : Action
{
    public SharedNode TargetPoint;
    public Rigidbody Body;
    public float RotateTime;
    private float _elapsedTime = 0f;
    private Quaternion _fromRotation;
    private Quaternion _targetRotation;

    public override void OnStart()
    {
        _fromRotation = transform.rotation;
        Vector3 lookDirection = TargetPoint.Value.transform.Vector3YZeroAxisPosition() - transform.Vector3YZeroAxisPosition();
        _targetRotation = Quaternion.LookRotation(lookDirection);
    }

    public override TaskStatus OnUpdate()
    {
        Body.MoveRotation(Quaternion.Lerp(_fromRotation, _targetRotation, _elapsedTime / RotateTime));

        if (_elapsedTime >= RotateTime)
        {
            _elapsedTime = 0f;
            return TaskStatus.Success;
        }

        _elapsedTime += Time.deltaTime;
        return TaskStatus.Running;
    }
}