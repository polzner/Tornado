using System;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private List<Edge> _incidentEdes;

    public void AddEdge(Node node)
    {
        _incidentEdes.Add(new Edge(this, node));
    }

    public Node GetRandomIncidentNode()
    {
        int randomIndex = UnityEngine.Random.Range(0, _incidentEdes.Count);

        return _incidentEdes[randomIndex].GetIncidentNode(this);
    }

    public Node GetFarthestIncidentNode(Transform point)
    {
        float farthestDistance = 0f;
        Node farthestNode = null;

        foreach (Edge edge in _incidentEdes)
        {
            Node node = edge.GetIncidentNode(this);
            float distance = Vector2.Distance(node.transform.Vector2Position(), point.Vector2Position());

            if (distance > farthestDistance)
            {
                farthestDistance = distance;
                farthestNode = node;
            }
        }

        return farthestNode != null ? farthestNode : throw new NullReferenceException("cant find farthest node");
    }
}
