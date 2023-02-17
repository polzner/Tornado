using UnityEngine;

public class EffectBallsSpawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _force = 100000f;
    private GameObject _dragBall;

    public void Spawn(ITornadoEffectBall ball)
    {        
        _dragBall = Instantiate(((MonoBehaviour)ball).gameObject);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        _dragBall.transform.position = point;
    }

    private void Update()
    {
        if (_dragBall)
        {
            Vector3 oldPosition = _dragBall.transform.position;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float distance;
            plane.Raycast(ray, out distance);
            Vector3 point = ray.GetPoint(distance);

            _dragBall.transform.position = new Vector3(point.x, point.y, point.z);

            if (Input.GetMouseButtonUp(0))
            {
                Rigidbody rigidbody = _dragBall.GetComponent<Rigidbody>();
                rigidbody.isKinematic = false;
                Vector3 offset = -(oldPosition - _dragBall.transform.position);
                rigidbody.AddForce(new Vector3(offset.x, 0, offset.z) * _force, ForceMode.Acceleration);
                _dragBall = null;
            }
        }
    }
}
