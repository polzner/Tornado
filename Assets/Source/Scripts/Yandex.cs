using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();
    }
}
