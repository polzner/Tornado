using UnityEngine;
using BehaviorDesigner.Runtime;

public class GravityTriggerHandler : MonoBehaviour
{
    [SerializeField] private Gravitator _gravitator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Layers.TornadoMovableItem)
        {
            GameObject currentGameObject = other.gameObject;
            currentGameObject.layer = Layers.GravitatingObject;
            _gravitator.Gravitate(transform, currentGameObject);
        }

        if (other.gameObject.layer == Layers.Bot)
        {
            GameObject currentGameObject = other.gameObject;
            currentGameObject.GetComponent<BehaviorTree>().enabled = false;
            currentGameObject.layer = Layers.GravitatingObject;
            _gravitator.Gravitate(transform, currentGameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Layers.GravitatingObject)
        {
            GameObject currentGameObject = other.gameObject;
            currentGameObject.layer = Layers.TornadoMovableItem;
            _gravitator.StopGravitate(currentGameObject);
        }
    }
}
