using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _barSpeed = 1;
    private float _targetProgress;

    private bool _canIncrease => _slider.value < _slider.maxValue;

    private void Start()
    {
        StartCoroutine(UpdateProgressBar());
    }

    public void UpdateProgress(float offset)
    {
        _targetProgress += offset/_slider.maxValue;
    }

    private IEnumerator UpdateProgressBar()
    {
        while (_canIncrease)
        {
            if (_slider.value < _targetProgress)
                _slider.value += Time.deltaTime * _barSpeed;

            yield return null;
        }
    }
}
