using UnityEngine;

public class InputPositionTrigger
{
    private RotateInputRouter _router;
    private RotateTest _rotator;
    private Rect _screenZone;
    private bool _inZone = false;

    public InputPositionTrigger(RotateInputRouter router, RotateTest rotator, Rect triggerZone)
    {
        _rotator = rotator;
        _screenZone = triggerZone;
        _router = router;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _inZone = _screenZone.Contains(Input.mousePosition);

        if (Input.GetMouseButton(0) && _inZone)
        {
            _rotator.Rotate();
            _router.Update();
            Debug.Log(_router.RotationInput);
        }
        else
            _rotator.SnapRotate();
    }
}
