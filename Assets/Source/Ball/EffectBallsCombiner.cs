using System.Collections.Generic;
using UnityEngine;

public class EffectBallsCombiner : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;

    private Queue<ITornadoEffectBall> _effectBalls= new Queue<ITornadoEffectBall>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ITornadoEffectBall ball))
        {
            _effectBalls.Enqueue(ball);

            if (_effectBalls.Count == 3)
                ((MonoBehaviour)_effectBalls.Dequeue()).gameObject.SetActive(false);

            if (_effectBalls.Count == 2)
            {
                Combine(_effectBalls);
                _sceneLoader.LoadScene(Scenes.Level1);
            }

        }
    }

    private void Combine(Queue<ITornadoEffectBall> effectBalls)
    {
        Queue<ITornadoEffectBall> balls = new Queue<ITornadoEffectBall>(effectBalls);

        switch (balls.Dequeue())
        {
            case FireEffectBall ball:
                switch (balls.Dequeue())
                {
                    case DustEffectBall dustBall:
                        Debug.Log("fire + dust");
                        break;

                    case FireEffectBall fireBall:
                        Debug.Log("fire + fire");
                        break;
                }
                break;

            case DustEffectBall ball:
                switch (balls.Dequeue())
                {
                    case DustEffectBall dustBall:
                        Debug.Log("dust + dust");
                        break;

                    case FireEffectBall fireBall:
                        Debug.Log("dust + fire");
                        break;

                    case WaterEffectBall waterBall:
                        Debug.Log("water + dust");
                        break;
                }
                break;

            case WaterEffectBall ball:
                switch (balls.Dequeue())
                {
                    case DustEffectBall dustBall:
                        Debug.Log("water + dust");
                        break;
                
                    case WaterEffectBall waterBall:
                        Debug.Log("water + water");
                        break;
                }
                break;
        }
    }
}