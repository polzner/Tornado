using System.Collections.Generic;
using UnityEngine;

//заменить айтемы спавном из инвент
public class RotateTest
{
    private BallCreator _creator;
    private Inventory _inventory;
    private RotateInputRouter _router;
    private Transform _parentTransform;
    private int _transformsCount;
    private float _currentPosition;
    private List<MenuItemBall> _items = new List<MenuItemBall>();
    private List<RotatingMenuItem> _transforms = new List<RotatingMenuItem>();
    private float _elapsedTime;
    private float _inertialRotationSpeed;
    private float _rotationSpeed;

    public RotateTest(BallCreator ballCreator, Inventory inventory, RotateInputRouter router, Transform parentTransform, 
        int transformsCount, float rotationSpeed)
    {
        _creator = ballCreator;
        _inventory = inventory;
        _router = router;
        _parentTransform = parentTransform;
        _transformsCount = transformsCount;
        _rotationSpeed = rotationSpeed;
    }

    public IEffectBall CurrentItem { get; private set; }
    public int AngleStep => 360 / _transformsCount;

    public void Awake()
    {
        foreach (var item in _inventory.Cells)
        {
            MenuItemBall newItem = new MenuItemBall(GameObject.Instantiate(_creator.GetTemplate(item.Ball)), item.Ball);
            newItem.View.SetActive(false);
            _items.Add(newItem);
        }
    }

    public void Start()
    {
        var distance = 0;

        for (int i = 0;  i < _transformsCount; i++)
        {
            Transform point = new GameObject().transform;
            point.parent = _parentTransform;
            SetPosition(point, distance);
            RotatingMenuItem cell = new RotatingMenuItem(point);
            cell.ReplaceChild(_items[i]);
            _transforms.Add(cell);
            distance -= AngleStep;
        }

        ReplaceOutOfRangeItems();
    }

    public void Rotate()
    {
        _elapsedTime = 0f;
        _inertialRotationSpeed = -_router.RotationInput * _rotationSpeed * Time.deltaTime;

        MoveItems(_currentPosition);
        _currentPosition += -_router.RotationInput * _rotationSpeed * Time.deltaTime;

        ReplaceOutOfRangeItems();
    }

    public void SnapRotate()
    {
        float step = _rotationSpeed / 5f * Time.deltaTime;

        if (_elapsedTime < 1f && _inertialRotationSpeed != 0f)
        {
            _currentPosition += _inertialRotationSpeed;
            MoveItems(_currentPosition);
            ReplaceOutOfRangeItems();

        }

        if (_elapsedTime >= 1f || _inertialRotationSpeed == 0f)
        {
            float snappedAngle = Mathf.Round(_currentPosition / AngleStep) * AngleStep;
            float targetPosition = Mathf.MoveTowards(_currentPosition, snappedAngle, 100f * Time.deltaTime);
            MoveItems(targetPosition);
            _currentPosition = targetPosition;
            ReplaceOutOfRangeItems();

        }

        _elapsedTime += Time.deltaTime;

    }

    private void ReplaceOutOfRangeItems()
    {
        int itemIndex = Mathf.RoundToInt(_currentPosition / (360f / _transforms.Count)) % _items.Count;
        int transformIndex = Mathf.RoundToInt(_currentPosition / (360f / _transforms.Count)) % _transforms.Count;
        itemIndex = itemIndex < 0 ? _items.Count + itemIndex : itemIndex;
        transformIndex = transformIndex < 0 ? _transforms.Count + transformIndex : transformIndex;

        CurrentItem = _items[itemIndex].EffectBall;

        for (int i = -2; i < 3; i++)
        {
            int currentItemIndex = itemIndex + i;
            int currentTransformIndex = transformIndex + i;
            
            currentItemIndex = (int)Mathf.Repeat(currentItemIndex, _items.Count);
            currentTransformIndex = (int)Mathf.Repeat(currentTransformIndex, _transforms.Count);

            MenuItemBall item = _items[currentItemIndex];
            _transforms[currentTransformIndex].ReplaceChild(item);
        }
    }

    private void MoveItems(float position)
    {
        foreach (var t in _transforms)
        {
            SetPosition(t.ParentTransform, position);
            position -= AngleStep;
        }
    }

    private void SetPosition(Transform transform, float distance)
    {
        float x = Mathf.Sin(distance * Mathf.Deg2Rad + Mathf.PI);
        float z = Mathf.Cos(distance * Mathf.Deg2Rad + Mathf.PI);

        transform.localPosition = new Vector3(x, 0, z);
    }
}

public class RotatingMenuItem
{
    public RotatingMenuItem(Transform parentTransform)
    {
        ParentTransform = parentTransform;
    }

    public MenuItemBall ChildObject { get; private set; }
    public Transform ParentTransform { get; private set; }

    public void ReplaceChild(MenuItemBall child)
    {
        if (ChildObject != null)
            ChildObject.View.SetActive(false);

        ChildObject = child;
        child.View.transform.SetParent(ParentTransform);
        child.View.transform.localPosition = Vector3.zero;
        ChildObject.View.SetActive(true);
    }
}

public class MenuItemBall
{
    public MenuItemBall(GameObject view, IEffectBall effectBall)
    {
        View = view;
        EffectBall = effectBall;
    }

    public GameObject View { get; private set; }
    public IEffectBall EffectBall { get; private set; }
}