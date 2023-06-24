using System;
using System.Collections.Generic;
using UnityEngine;

public class BotMovingPointsGraph : MonoBehaviour
{
    [SerializeField] private List<Node> _nodes;
    [SerializeField] private int _columns;
    [SerializeField] private int _rows;

    private void Start()
    {
        NodeConnector nodeConnector = new NodeConnector();
        nodeConnector.ConnectNodes(_nodes, _rows, _columns);
    }

    public Node GetClosestNode(Transform point)
    {
        float nearbyPointDistance = float.PositiveInfinity;
        Node nearestPoint = null;

        foreach (var node in _nodes)
        {
            float distance = Vector2.Distance(point.Vector2Position(), node.transform.Vector2Position());

            if (distance < nearbyPointDistance)
            {
                nearestPoint = node;
                nearbyPointDistance = distance;
            }
        }

        return nearestPoint != null ? nearestPoint : throw new InvalidOperationException("cant find point in nodes");
    }
}
