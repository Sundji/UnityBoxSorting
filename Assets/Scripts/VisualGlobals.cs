using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New VisualGlobals")]
public class VisualGlobals : ScriptableObject
{
    [SerializeField] private List<BoxAndContainerVisualsEntry> _boxAndContainerVisuals = new List<BoxAndContainerVisualsEntry>();

    public BoxAndContainerVisualsEntry GetBoxAndContainerVisualsEntry(BoxColor color)
    {
        return _boxAndContainerVisuals.Find(entry => entry.Color == color);
    }
}
