using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private FloatingJoystick _joystick;

    private void Update()
    {
        _mover.Move(_joystick.Direction);
    }
}
