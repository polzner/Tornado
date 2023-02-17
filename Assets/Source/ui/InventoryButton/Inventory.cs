using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<EffectBallData> _effectBallsData;
    [SerializeField] private InventoryButton _EffectBallButtonPrefab;
    [SerializeField] private Transform _buttonParent;
    [SerializeField] private EffectBallsSpawner _spawner;

    private List<InventoryItemButtonHandler> _items = new List<InventoryItemButtonHandler>();

    private void OnDisable()
    {
        foreach (var item in _items)
        {
            item.OnDisable();
        }
    }

    private void Start()
    {
        //заполнить layout кнопками по данным шаров
        foreach (var item in _effectBallsData)
        {
            InventoryButton button = Instantiate(_EffectBallButtonPrefab, _buttonParent);
            button.GetComponent<Image>().sprite = item.Icon;
            InventoryItemButtonHandler inventoryItemButton = new InventoryItemButtonHandler(button, item.EffectBallPrefab, _spawner);
            inventoryItemButton.OnEnable();
            _items.Add(inventoryItemButton);
        }
    }
}
