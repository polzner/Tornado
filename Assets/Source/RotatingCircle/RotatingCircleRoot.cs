using System;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCircleRoot : MonoBehaviour
{
    [SerializeField] private BallCreator _ballCreator;
    [SerializeField] private List<RotateTransform> _rotateTransforms = new List<RotateTransform>();

    //private List<Rotator> _rotators = new List<Rotator>();
    private List<RotateTest> _rotators = new List<RotateTest>();
    private List<InputPositionTrigger> _positionTriggers = new List<InputPositionTrigger>();
    private List<BallsHandler> _handlers = new List<BallsHandler>();
    private RotateInputRouter _rotateInputRouter;
    private Inventory _inventory;

    private void OnValidate()
    {
        UpdateTriggerZone();
    }

    private void OnDrawGizmos()
    {
        _rotateTransforms.ForEach(t =>
        Handles.DrawSolidRectangleWithOutline(t.TriggerZone, new Color(0, 0, 0, 0), Color.green));
    }

    private void Awake()
    {
        UpdateTriggerZone();

        _inventory = new Inventory();
        _rotateInputRouter = new RotateInputRouter();

        foreach (var rotateTransform in _rotateTransforms)
        {
            //Rotator rotator = new Rotator(_rotateInputRouter, rotateTransform.Transform,
            //    rotateTransform.Speed, 360f / _inventory.Cells.Count);

            RotateTest rotator = new RotateTest(_ballCreator, _inventory,_rotateInputRouter, 
                rotateTransform.Transform, 6);

            _rotators.Add(rotator);
            rotator.Awake();
            _positionTriggers.Add(new InputPositionTrigger(rotator, rotateTransform.TriggerZone));
            //_handlers.Add(new BallsHandler(_ballCreator, _inventory, rotateTransform));
        }
    }

    private void Start()
    {
        _rotators.ForEach(r => r.Start());
        //_handlers.ForEach(h => h.Spawn());
    }

    private void Update()
    {
        _rotateInputRouter.Update();

        foreach (var positionTrigger in _positionTriggers)
            positionTrigger.Update();
    }

    private void UpdateTriggerZone()
    {
        foreach (var item in _rotateTransforms)
            item.UpdateZone();
    }
}

[Serializable]
public class RotateTransform
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;
    [SerializeField] private Rect _triggerZone;
    [SerializeField] private Place _place;

    public Transform Transform => _transform;
    public float Speed => _speed;
    public float Radius => _radius;
    public Rect TriggerZone => _triggerZone;
    public Place Place => _place;

    public void UpdateZone()
    {
        _triggerZone = _place == Place.left ? new Rect(0, 0, Camera.main.pixelWidth / 2, Camera.main.pixelHeight)
            : _place == Place.right ? new Rect(Camera.main.pixelWidth / 2, 0, Camera.main.pixelWidth / 2, Camera.main.pixelHeight) : _triggerZone;
    }
}

public enum Place
{
    left,
    right,
    custom
}
