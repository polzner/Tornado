using System;
using UnityEngine;

[Serializable]
public class Edge
{
    [SerializeField] private Node _first;
    [SerializeField] private Node _second;

    public Edge(Node first, Node second)
    {
        _first = first;
        _second = second;
    }

    public Node GetIncidentNode(Node node)
    {
        Node incidentNode = node == _first ? _second : node == _second ? _first : null;

        if (incidentNode == null)
            throw new InvalidOperationException("not incident");

        return incidentNode;
    }
}
