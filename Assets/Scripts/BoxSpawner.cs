using System;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private Box _boxPrefab = null;
    [SerializeField] private Transform _boxContainer = null;
    [SerializeField] private Vector2 _spawnPeriodRange = Vector2.zero;
    [SerializeField] private Vector2 _spawnPositionXRange = Vector2.zero;
    [SerializeField] private Vector2 _spawnPositionYRange = Vector2.zero;

    private BoxColor[] _boxColors = null;
    private float _timer = 0.0f;

    private BoxColor[] BoxColors
    {
        get
        {
            if (_boxColors == null) _boxColors = (BoxColor[])Enum.GetValues(typeof(BoxColor));
            return _boxColors;
        }
    }

    private void Awake()
    {
        _timer = _spawnPeriodRange.RandomValue();
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0.0f)
        {
            Vector2 position = new Vector2(_spawnPositionXRange.RandomValue(), _spawnPositionYRange.RandomValue());
            Box box = Instantiate(_boxPrefab, position, Quaternion.identity, _boxContainer);
            box.InitializeBox(BoxColors[new Vector2Int(0, BoxColors.Length).RandomValue()]);

            _timer = _spawnPeriodRange.RandomValue();
        }
    }
}
