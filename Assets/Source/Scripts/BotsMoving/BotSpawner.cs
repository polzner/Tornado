using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _botPrefab;
    [SerializeField] private int _botsQuantity;
    [SerializeField] private List<Node> _nodes;

    private void Start()
    {
        for (int i = 0; i < _botsQuantity; i++)
        {
            int randomPositionIndex = Random.Range(0, _nodes.Count);
            GameObject gameObject = Instantiate(_botPrefab, _nodes[randomPositionIndex].transform.position, Quaternion.identity, transform);
            gameObject.SetActive(true);
        }
    }
}