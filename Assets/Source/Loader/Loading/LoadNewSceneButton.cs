using UnityEngine;
using UnityEngine.UI;

public class LoadNewSceneButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private SceneLoader _sceneLoader;
 
    private void OnEnable()
    {
        _button.onClick.AddListener(LoadScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(LoadScene);
    }

    private void LoadScene()
    {
        _sceneLoader.LoadScene(Scenes.Level1);
    }
}
