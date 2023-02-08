using UnityEngine;

public class TornadoTriggerHandler : MonoBehaviour
{
    [SerializeField] private SpiralMover _mover;
    [SerializeField] private Gravitator _gravitator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Layers.GravitatingObject)
        {
            GameObject item = other.gameObject;
            item.gameObject.layer = Layers.TrigeredItem;
            _gravitator.StopGravitate(item);
            Rigidbody rigidbody = item.GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            _mover.Move(rigidbody);
        }
    }
}
