using System;
using UnityEngine;

public class Container : MonoBehaviour
{
    public static Action<BoxColor, int> OnBoxCountChanged = null;

    [SerializeField] private BoxColor _containerColor = BoxColor.GREEN;

    private int _boxCount = 0;
    
    public BoxColor ContainerColor => _containerColor;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = GlobalsManager.Instance.VisualGlobals.GetBoxAndContainerVisualsEntry(_containerColor).ContainerSprite;
    }

    public void AddBox()
    {
        _boxCount++;
        OnBoxCountChanged?.Invoke(ContainerColor, _boxCount);
    }
}
