using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    public static Action<Box> OnBoxDroppedAction = null;

    [SerializeField] private BoxColor _boxColor = BoxColor.GREEN;
    [SerializeField] private bool _initializeInAwake = false;
    [Header("Box Sprites")]
    [SerializeField] private Sprite _boxGreenSprite = null;
    [SerializeField] private Sprite _boxGreenCarriedSprite = null;
    [SerializeField] private Sprite _boxRedSprite = null;
    [SerializeField] private Sprite _boxRedCarriedSprite = null;

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
        _spriteRenderer.sprite = _boxColor == BoxColor.GREEN ? _boxGreenCarriedSprite : _boxRedCarriedSprite;
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
        _spriteRenderer.sprite = boxColor == BoxColor.GREEN ? _boxGreenSprite : _boxRedSprite;
    }
}
