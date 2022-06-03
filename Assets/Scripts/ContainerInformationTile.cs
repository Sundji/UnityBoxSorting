using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContainerInformationTile : MonoBehaviour
{
    [SerializeField] private BoxColor _containerColor = BoxColor.GREEN;
    [SerializeField] private Image _boxColorImage = null;
    [SerializeField] private TextMeshProUGUI _boxCountText = null;
    [Header("Sprites and colors")]
    [SerializeField] private Sprite _boxGreenSprite = null;
    [SerializeField] private Color _containerGreenFontColor = Color.white;
    [SerializeField] private Sprite _boxRedSprite = null;
    [SerializeField] private Color _containerRedFontColor = Color.white;

    private void Awake()
    {
        Container.OnBoxCountChanged += OnBoxCountChange;
        OnBoxCountChange(_containerColor, 0);
    }

    private void OnDestroy()
    {
        Container.OnBoxCountChanged -= OnBoxCountChange;
    }

    private void OnBoxCountChange(BoxColor boxColor, int boxCount)
    {
        if (_containerColor != boxColor) return;

        _boxColorImage.sprite = boxColor == BoxColor.GREEN ? _boxGreenSprite : _boxRedSprite;
        _boxCountText.text = boxCount.ToString();
        _boxCountText.color = boxColor == BoxColor.GREEN ? _containerGreenFontColor : _containerRedFontColor;
    }
}
