using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPositionTrigger
{
    private RotateInputRouter _router;
    private RotateTest _rotator;
    private BallSpawner _ballSpawner;
    private Rect _screenZone;
    private bool _inZone = false;
    private float _clickTime = 0.1f;
    private float _elapsedTime;
    private bool _isMousePressed = false;

    public InputPositionTrigger(RotateInputRouter router, RotateTest rotator, Rect triggerZone, BallSpawner ballSpawner)
    {
        _rotator = rotator;
        _screenZone = triggerZone;
        _router = router;
        _ballSpawner = ballSpawner;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _inZone = _screenZone.Contains(Input.mousePosition);
            _isMousePressed = true;
        }

        if (Input.GetMouseButtonUp(0) && _inZone)
        {
            _isMousePressed = false;

            if (_elapsedTime <= _clickTime)
                _ballSpawner.Spawn((_rotator.CurrentItemIndex));

            _elapsedTime = 0;
        }

        if (_isMousePressed)
            _elapsedTime += Time.deltaTime;

        if (Input.GetMouseButton(0) && _inZone)
        {
            _rotator.Rotate();
            _router.Update();
        }
        else
            _rotator.SnapRotate();
    }
}
