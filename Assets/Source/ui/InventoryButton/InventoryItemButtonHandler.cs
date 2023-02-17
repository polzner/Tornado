public class InventoryItemButtonHandler
{
    private InventoryButton _button;
    private ITornadoEffectBall _effectBall;
    private EffectBallsSpawner _spawner;

    public InventoryItemButtonHandler(InventoryButton button, ITornadoEffectBall effectBall, EffectBallsSpawner spawner)
    {
        _button = button;
        _effectBall = effectBall;
        _spawner = spawner;
    }

    public void OnEnable()
    {
        _button.PointerDown += OnButtonDown;
    }

    public void OnDisable()
    {
        _button.PointerDown -= OnButtonDown;
    }

    public void OnButtonDown()
    {
        _spawner.Spawn(_effectBall);
    }
}
