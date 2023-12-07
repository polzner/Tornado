using System.Collections.Generic;
using UnityEngine;

public class BallSpawner
{
    private Transform _spawnPoint;
    private Inventory _inventory;
    private BallCreator _ballCreator;

    public BallSpawner(Inventory inventory, Transform spawnPoint, BallCreator ballCreator)
    {
        _inventory = inventory;
        _spawnPoint = spawnPoint;
        _ballCreator = ballCreator;
    }

    public void Spawn(IEffectBall ball)
    {
        
    }
}

