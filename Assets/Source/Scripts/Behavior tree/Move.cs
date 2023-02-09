using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Move : Action
{
    public Rigidbody Character;
    public float MoveSpeed;
    public float Radius;
    public SharedNode TargetPoint;

    public override TaskStatus OnUpdate()
    {
        if (Vector2.Distance(TargetPoint.Value.transform.Vector2Position(), transform.Vector2Position()) <= Radius)
            return TaskStatus.Success;

        return TaskStatus.Running;
    }

    public override void OnFixedUpdate()
    {
        Vector3 direction = TargetPoint.Value.transform.position - transform.position;
        direction.Normalize();
        Character.MovePosition(transform.position + (direction * MoveSpeed * Time.deltaTime));
    }
}
