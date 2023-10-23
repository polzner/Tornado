using UnityEngine;

public class RotateInputRouter
{
    public float RotationInput { get; private set; }

    public void Update()
    {
        RotationInput = Input.GetAxis("Mouse X");
    }
}
