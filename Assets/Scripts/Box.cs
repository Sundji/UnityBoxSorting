using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    public static Action<Box> OnBoxDroppedAction = null;

    [SerializeField] private BoxColor _boxColor = BoxColor.GREEN;
    [SerializeField] private bool _initializeInAwake = false;

    private Transform _parent = null;
    private SpriteRenderer _spriteRenderer = null;

    public BoxColor BoxColor => _boxColor;

    private void Awake()
    {
        _parent = transform.parent;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_initializeInAwake) InitializeBox(_boxColor);
    }

    public void CarryBox(Transform carrier, Vector2 positionInCarrier)
    {
        _spriteRenderer.sprite = GlobalsManager.Instance.VisualGlobals.GetBoxAndContainerVisualsEntry(_boxColor).BoxCarriedSprite;
        transform.parent = carrier;
        transform.localPosition = positionInCarrier;
    }

    public void DropBox()
    {
        transform.parent = _parent;
        transform.localPosition = Vector2.zero;
        OnBoxDroppedAction?.Invoke(this);
        gameObject.SetActive(false);
    }

    public void InitializeBox(BoxColor boxColor)
    {
        _boxColor = boxColor;
        _spriteRenderer.sprite = GlobalsManager.Instance.VisualGlobals.GetBoxAndContainerVisualsEntry(_boxColor).BoxSprite;
    }
}
