using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GreenArea : MonoBehaviour
{
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float upperLimit;
    [SerializeField] private Transform box;
    [SerializeField] private float minAlpha;
    [SerializeField] private float maxAlpha;
    [SerializeField] private float durationChangeAlpha;
    private SpriteRenderer _spriteRenderer;
    private bool _isBoxInArea = false;

    public bool IsBoxInAreaProperty { 
        get
        {
            return _isBoxInArea;
        }
    }
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (!LevelZeroManager.isTeleportFromSixthLevelToZero)
        {
            StartCoroutine(AlphaPingPong(minAlpha, maxAlpha, durationChangeAlpha));
        }
    }
    
    private void Update()
    {
        IsBoxInArea();
    }

    private System.Collections.IEnumerator AlphaPingPong(float minAlpha, float maxAlpha, float duration)
    {
        while (true)
        {
            yield return StartCoroutine(ChangeAlphaSprite(minAlpha, maxAlpha, duration));
            if (_isBoxInArea)
            {
                StopAllCoroutines();
                break;
            }
            else
            {
                yield return StartCoroutine(ChangeAlphaSprite(maxAlpha, minAlpha, duration));
            }
        }
        Color setMaxAlpha = _spriteRenderer.color;
        setMaxAlpha.a = maxAlpha;
        _spriteRenderer.color = setMaxAlpha;
    }
    private System.Collections.IEnumerator ChangeAlphaSprite(float startAlpha, float targetAlpha, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float timePeriod = elapsedTime / duration;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timePeriod);
            Color newColor = _spriteRenderer.color;
            newColor.a = newAlpha;
            _spriteRenderer.color = newColor;

            yield return null;
        }
        Color newColorThisAlpha = _spriteRenderer.color;
        newColorThisAlpha.a = targetAlpha;
        _spriteRenderer.color = newColorThisAlpha;

    }

    private void IsBoxInArea()
    {
        Transform boxTransform = box;
        if (boxTransform.position.x >= leftLimit && boxTransform.position.x <= rightLimit &&
            boxTransform.position.y >= bottomLimit && boxTransform.position.y <= upperLimit)
        {
            _isBoxInArea = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.orange;
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(rightLimit, upperLimit));
    }
}
