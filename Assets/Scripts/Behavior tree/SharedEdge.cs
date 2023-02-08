using BehaviorDesigner.Runtime;
using System;

[Serializable]
public class SharedEdge : SharedVariable<Edge>
{
    public static implicit operator SharedEdge(Edge value) => new SharedEdge { Value = value };
}