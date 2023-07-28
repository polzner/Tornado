using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float _timeToLoad = 4f;
    [SerializeField] private SceneLoadAnimator _sceneLoadAnimator;

    private void Start()
    {
        _sceneLoadAnimator.OpenScene();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(AsyncLoadSceneRoutine(sceneName));
    }

    private IEnumerator AsyncLoadSceneRoutine(string sceneName)
    {
        _sceneLoadAnimator.CloseScene();
        yield return new WaitForSeconds(_timeToLoad);
        AsyncOperation asyncSceneLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncSceneLoad.isDone)
            yield return null;
    }
}