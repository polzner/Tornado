using UnityEngine;

public static class MyExtentions
{
    public static Vector2 Vector2Position(this Transform transform)
    {
        return new Vector2(transform.position.x, transform.position.z);
    }

    public static Vector3 Vector3YZeroAxisPosition(this Transform transform)
    {
        return new Vector3(transform.position.x, 0f, transform.position.z);
    }
}
