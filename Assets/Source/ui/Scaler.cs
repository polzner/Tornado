using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private RectTransform _canvas;
    [SerializeField] private RectTransform _image;

    private void Start()
    {
        _image.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _canvas.rect.width/2);
    }
}
