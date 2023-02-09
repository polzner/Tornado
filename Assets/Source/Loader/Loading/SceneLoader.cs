using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float _timeToLoad = 4f;
    [SerializeField] private SceneLoadAnimator _animator;

    private void Start()
    {
        _animator.OpenScene();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(AsyncLoadSceneRoutine(sceneName));
    }

    private IEnumerator AsyncLoadSceneRoutine(string sceneName)
    {
        _animator.CloseScene();
        yield return new WaitForSeconds(_timeToLoad);
        AsyncOperation asyncSceneLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncSceneLoad.isDone)
            yield return null;
    }
}