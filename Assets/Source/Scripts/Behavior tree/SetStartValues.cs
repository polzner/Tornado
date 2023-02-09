using BehaviorDesigner.Runtime.Tasks;

public class SetStartValues : Action
{
    public BotMovingPointsGraph MovingPointGraph;
    public SharedNode NextNode;

    public override void OnStart()
    {
        NextNode.Value = MovingPointGraph.GetClosestNode(transform).GetRandomIncidentNode();
    }
}
