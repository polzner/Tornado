using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectBallCombiner : MonoBehaviour
{
    private Dictionary<IEffectBall, List<(IEffectBall, string)>> _rules =
            new Dictionary<IEffectBall, List<(IEffectBall, string)>>()
            {
                [new FireBall()] = new List<(IEffectBall, string)>()
                {
                    (new DustBall(), "fire + dust"),
                    (new FireBall(), "fire + fire"),
                },

                [new DustBall()] = new List<(IEffectBall, string)>()
                {
                    (new FireBall(), "dust + fire"),
                    (new DustBall(), "dust + dust"),
                    (new WaterBall(), "dust + water")
                },

                [new WaterBall()] = new List<(IEffectBall, string)>()
                {
                    (new DustBall(), "water + dust"),
                    (new WaterBall(), "water + water")
                }
            };

    public void Combine(IEffectBall first, IEffectBall second)
    {
        foreach (var item in _rules)
        {
            if (item.Key.GetType() == first.GetType())
            {
                foreach (var q in item.Value)
                {
                    if (q.Item1.GetType() == second.GetType())
                        Console.WriteLine(q.Item2);
                }
            }
        }
    }
}

public class FireBall : IEffectBall
{
}

public class DustBall : IEffectBall
{
}

public class WaterBall : IEffectBall
{
}
