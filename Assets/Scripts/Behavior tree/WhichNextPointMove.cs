using BehaviorDesigner.Runtime.Tasks;

public class WhichNextPointMove : Action
{
    public BotMovingPointsGraph MovingPointGraph;
    public SharedNode NextNode;

    public override void OnStart()
    {
        NextNode.Value = NextNode.Value.GetRandomIncidentNode();
    }
}
