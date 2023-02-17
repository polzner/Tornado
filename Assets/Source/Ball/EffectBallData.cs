using UnityEngine;

[CreateAssetMenu(menuName = "Tornado/EffectBallData")]
public class EffectBallData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private MonoBehaviour _effectBallPrefab;

    public Sprite Icon => _icon;
    public ITornadoEffectBall EffectBallPrefab => (ITornadoEffectBall)_effectBallPrefab;
}
