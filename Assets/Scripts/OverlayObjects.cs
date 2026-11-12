using JetBrains.Annotations;
using UnityEngine;

public class OverlayObjects : MonoBehaviour
{
    public static OverlayObjects Instance { get; private set; }
    [SerializeField] private float transparent;
    [SerializeField] private float timeAlpha;
    private SpriteRenderer[] _occluders;
    private Color[] _originalColors;
    private Color[] _targetColors;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Occluder");
        _occluders = new SpriteRenderer[gameObjects.Length];
        _originalColors = new Color[gameObjects.Length];
        _targetColors = new Color[gameObjects.Length];
        for (int i = 0; i < _occluders.Length; ++i)
        {
            _occluders[i] = gameObjects[i].GetComponent<SpriteRenderer>();
            _originalColors[i] = _occluders[i].color;
            Color color = _occluders[i].color;
            color.a = transparent;
            _targetColors[i] = color;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        for (int i = 0; i < _occluders.Length; ++i)
        {
            Color color = _occluders[i].color;
            color = Color.Lerp(color, _targetColors[i], timeAlpha);
            _occluders[i].color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        for (int i = 0; i < _occluders.Length; ++i)
        {
            _occluders[i].color = _originalColors[i];
        }
    }
}
