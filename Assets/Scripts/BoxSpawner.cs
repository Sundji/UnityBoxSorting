using System;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private Box _boxPrefab = null;
    [SerializeField] private Transform _boxContainer = null;
    [SerializeField] private Vector2 _spawnPeriodRange = Vector2.zero;
    [SerializeField] private Vector2 _spawnPositionXRange = Vector2.zero;
    [SerializeField] private Vector2 _spawnPositionYRange = Vector2.zero;

    private Stack<Box> _unusedBoxes = new Stack<Box>();
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
        Box.OnBoxDroppedAction += OnBoxDropped;
    }

    private void OnDestroy()
    {
        Box.OnBoxDroppedAction -= OnBoxDropped;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0.0f)
        {
            _timer = _spawnPeriodRange.RandomValue();
            SpawnBox();
        }
    }

    private void OnBoxDropped(Box box)
    {
        _unusedBoxes.Push(box);
    }

    private void SpawnBox()
    {
        Vector2 position = new Vector2(_spawnPositionXRange.RandomValue(), _spawnPositionYRange.RandomValue());
        Box box;
        if (_unusedBoxes.Count > 0)
        {
            box = _unusedBoxes.Pop();
            box.transform.position = position;
            box.gameObject.SetActive(true);
        }
        else box = Instantiate(_boxPrefab, position, Quaternion.identity, _boxContainer);
        box.InitializeBox(BoxColors[new Vector2Int(0, BoxColors.Length).RandomValue()]);
    }
}
