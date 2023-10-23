using System.Collections.Generic;
using UnityEngine;

public class BallsHandler
{
    private BallCreator _ballCreator;
    private RotateTransform _rotateTransform;
    private Inventory _inventory;
    private List<GameObject> _items;
    private float _radius;

    public BallsHandler(BallCreator ballCreator, Inventory inventory, RotateTransform rotateTransform)
    {
        _ballCreator = ballCreator;
        _rotateTransform = rotateTransform;
        _inventory = inventory;
        _radius = rotateTransform.Radius;
        _items = new List<GameObject>();
    }

    public void Spawn()
    {
        float angleStep = 360f / _inventory.Cells.Count;

        for (int i = 0; i < _inventory.Cells.Count; i++)
        {
            float angle = i * angleStep + 180f;

            float radian = angle * Mathf.Deg2Rad;

            float x = _radius * Mathf.Sin(radian);
            float z = _radius * Mathf.Cos(radian);

            GameObject child = GameObject.Instantiate(_ballCreator.GetTemplate(_inventory.Cells[i].Ball),
                _rotateTransform.Transform);
            child.transform.localPosition = new Vector3(x, 0f, z);
            _items.Add(child);
        }
    }
}

