using UnityEngine;

public class TornadoTriggerHandler : MonoBehaviour
{
    [SerializeField] private SpiralMover _mover;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TornadoMovableItem item))
        {
            item.GetComponent<Collider>().enabled = false;
            _mover.Move(item.GetComponent<Rigidbody>());
        }
    }
}
