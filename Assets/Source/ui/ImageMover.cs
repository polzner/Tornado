using System.Collections;
using UnityEngine;

public class ImageMover : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private RectTransform _imageRect;
    [SerializeField] private RectTransform _canvasRect;
    [SerializeField] private float _time;

    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = _imageRect.anchoredPosition;
    }

    public void Move()
    {
        Vector2 targetPosition = _startPosition + (_direction * _imageRect.rect.width);
        StartCoroutine(MoveRoutine(_time, _startPosition, targetPosition));
    }

    public void MoveDefaulPosition()
    {
        StartCoroutine(MoveRoutine(_time, _startPosition + (_direction * _imageRect.rect.width), _startPosition));
    }

    private IEnumerator MoveRoutine(float time, Vector2 startPosition, Vector2 targetPosition)
    {
        float elapsedTime = 0;        

        while(elapsedTime < time)
        {
            _imageRect.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / time);
            elapsedTime += Time.deltaTime/2;

            yield return null;
        }
    }
}
