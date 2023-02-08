using BehaviorDesigner.Runtime;
using System;

[Serializable]
public class SharedNode : SharedVariable<Node>
{
    public static implicit operator SharedNode(Node value) => new SharedNode { Value = value };
}
