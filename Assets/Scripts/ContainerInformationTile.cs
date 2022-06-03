using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContainerInformationTile : MonoBehaviour
{
    [SerializeField] private BoxColor _containerColor = BoxColor.GREEN;
    [SerializeField] private Image _boxColorImage = null;
    [SerializeField] private TextMeshProUGUI _boxCountText = null;

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

        BoxAndContainerVisualsEntry entry = GlobalsManager.Instance.VisualGlobals.GetBoxAndContainerVisualsEntry(boxColor);
        _boxColorImage.sprite = entry.BoxSprite;
        _boxCountText.text = boxCount.ToString();
        _boxCountText.color = entry.FontColor;
    }
}
