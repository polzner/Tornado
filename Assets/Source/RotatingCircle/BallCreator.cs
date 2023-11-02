using System;
using UnityEngine;

[CreateAssetMenu(menuName = "BallCreator")]
public class BallCreator : ScriptableObject
{
    [SerializeField] private GameObject _fireBall;
    [SerializeField] private GameObject _waterBall;
    [SerializeField] private GameObject _dustBall;
    [SerializeField] private GameObject _1;
    [SerializeField] private GameObject _2;
    [SerializeField] private GameObject _3;
    [SerializeField] private GameObject _4;
    [SerializeField] private GameObject _5;
    [SerializeField] private GameObject _6;

    public GameObject GetTemplate(IEffectBall ball)
    {
        if (ball is FireBall)
            return _fireBall;
        else if (ball is WaterBall)
            return _waterBall;
        else if (ball is DustBall)
            return _dustBall;
        else if (ball is WaterBall1)
            return _1;
        else if (ball is WaterBall2)
            return _2;
        else if (ball is WaterBall3)
            return _3;
        else if (ball is WaterBall4)
            return _4;
        else if (ball is WaterBall5)
            return _5;
        else if (ball is WaterBall6)
            return _6;

        throw new InvalidOperationException();
    }
}