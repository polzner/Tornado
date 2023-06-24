using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class GetFarthestPointFromPlayer : Conditional
{
    public Player Player;
    public float Radius;
    public SharedNode NextNode;
    public SharedEdge SharedEdge;

    public override TaskStatus OnUpdate()
    {
        if (Vector2.Distance(Player.transform.Vector2Position(), transform.Vector2Position()) < Radius)
        {
            float distanceFromPlayerToNextNode = Vector2.Distance(Player.transform.Vector2Position(), NextNode.Value.transform.Vector2Position());
            float distnceFromBotToNextNode = Vector2.Distance(transform.Vector2Position(), NextNode.Value.transform.Vector2Position());

            if (distanceFromPlayerToNextNode < distnceFromBotToNextNode)
                NextNode.Value = NextNode.Value.GetNearestIncidentNode(transform);

            return TaskStatus.Success;
        } 
            
        return TaskStatus.Failure;
    }
}