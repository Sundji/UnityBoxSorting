using UnityEngine;

public class GlobalsManager : MonoBehaviour
{
    private static GlobalsManager _instance = null;

    public static GlobalsManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<GlobalsManager>();
            return _instance;
        }
    }

    [SerializeField] private VisualGlobals _visualGlobals = null;

    public VisualGlobals VisualGlobals => _visualGlobals;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else if (!_instance.Equals(this)) Destroy(gameObject);
    }
}
