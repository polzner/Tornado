using System;
using UnityEngine;

[CreateAssetMenu(menuName = "BallCreator")]
public class BallCreator : ScriptableObject
{
    [SerializeField] private GameObject _fireBall;
    [SerializeField] private GameObject _waterBall;
    [SerializeField] private GameObject _dustBall;

    public GameObject GetTemplate(IEffectBall ball)
    {
        if(ball is FireBall)
            return _fireBall;
        else if (ball is WaterBall)
            return _waterBall;
        else if(ball is DustBall)
            return _dustBall;

        throw new InvalidOperationException();
    }
}