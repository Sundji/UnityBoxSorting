using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private BoxColor _containerColor = BoxColor.GREEN;
    
    public BoxColor ContainerColor => _containerColor;
}
