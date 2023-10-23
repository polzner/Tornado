using UnityEngine;

public class BallSpawner
{
    private GameObject _currentBall;
    private Transform _spawnPlace;

    public BallSpawner(Transform spawnPlace)
    {
        _spawnPlace = spawnPlace;
    }

    private void Spawn(GameObject effectBall)
    {
        _currentBall.SetActive(false);
        _currentBall = effectBall;

        //выбрасывать шар в котел
    }
}
