using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float _timeToLoad = 1f;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(AsyncLoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        _animator.SetTrigger("sceneClosing");

        yield return new WaitForSeconds(_timeToLoad);

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator AsyncLoadSceneRoutine(string sceneName)
    {
        _animator.SetTrigger("sceneClosing");
        yield return new WaitForSeconds(_timeToLoad);
        AsyncOperation asyncSceneLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncSceneLoad.isDone)
            yield return null;
    }
}