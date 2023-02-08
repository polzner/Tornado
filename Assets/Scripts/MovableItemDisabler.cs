using UnityEngine;

public class MovableItemDisabler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == Layers.TrigeredItem)
            other.gameObject.SetActive(false);
    }
}
