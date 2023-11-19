using System.Collections.Generic;
using UnityEngine;

public class BallSpawner
{
    private Transform _spawnPoint;
    private Inventory _inventory;

    public BallSpawner(Inventory inventory, Transform spawnPoint)
    {
        _inventory = inventory;
        _spawnPoint = spawnPoint;
    }

    public void Spawn(int index)
    {
        
    }
}

