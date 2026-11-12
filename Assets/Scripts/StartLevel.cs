using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    public static StartLevel Instance { get; private set; }
    [SerializeField] private TMP_Text textLevel;
    [SerializeField] private Image imageLevel;
    [SerializeField] private Canvas canvas;
    
    private bool _isMaxText = false;
    //private float _speedAlphaChangeObject = Time.fixedDeltaTime * 0.1f;
    private Color _colorText;
    private Color _colorImage;
    //private float _alpha = 0f;
    private bool _isAnimationProccess = true;
    private const string FirstLevelName = "FirstLevel";
    public bool IsAnimationProccess
    {
        get { return _isAnimationProccess; }
        set { _isAnimationProccess = value; }
    }
    private void Awake()
    {
        Instance = this;
        _colorText = textLevel.color;
        _colorText.a = 0;
        textLevel.color = _colorText;
        _colorImage = imageLevel.color;
        _isAnimationProccess = true;
        if (SceneManager.GetActiveScene().name == FirstLevelName)
        {
            PlayerVisual.Instance.SpriteRendererProperties.enabled = false;
            PlayerVisual.Instance.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    
    private void Update()
    {
        if (Player.Instance.IsFreezePlayer == false)
        {
            Player.Instance.IsFreezePlayer = true;
        }
        if (_colorText.a < 1 && !_isMaxText)
        {
            _colorText.a += (Time.fixedDeltaTime * 0.5f);
            textLevel.color = _colorText;
        } else if (_colorText.a > 0)
        {
            _isMaxText = true;
            _colorText.a -= (Time.fixedDeltaTime * 0.5f);
            textLevel.color = _colorText;
            if (imageLevel.color.a > 0)
            {
                _colorImage.a -= (Time.fixedDeltaTime * 0.5f * 1.09f);
                imageLevel.color = _colorImage;
            }
        } else
        {
            _isAnimationProccess = false;
            canvas.additionalShaderChannels = AdditionalCanvasShaderChannels.None;
            if (SceneManager.GetActiveScene().buildIndex != 2)
            {
                Player.Instance.IsFreezePlayer = false;
            }
            canvas.transform.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        
    }

}
