using UnityEngine;

public class ProgressHandler : MonoBehaviour
{
    [SerializeField] private SliderUpdater _sliderUpdater;
    [SerializeField] private float _increaceOffset = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Layers.TrigeredItem)
            _sliderUpdater.UpdateProgress(_increaceOffset);
    }
}

