using UnityEngine;

public class InputPositionTrigger
{
    private RotateTest _rotator;
    private Rect _screenZone;
    private bool _inZone = false;

    public InputPositionTrigger(RotateTest rotator, Rect triggerZone)
    {
        _rotator = rotator;
        _screenZone = triggerZone;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _inZone = _screenZone.Contains(Input.mousePosition);

        if (Input.GetMouseButton(0) && _inZone)
           _rotator.Rotate();
        else
           _rotator.SnapRotate();
    }
}
