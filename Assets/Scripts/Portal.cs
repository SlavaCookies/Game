using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Portal : MonoBehaviour
{
    public static Portal Instance { get; private set; }
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isPortalActivated = false;
    public bool IsPortalActivated
    {
        get
        {
            return _isPortalActivated;
        }
    }

    private void Awake()
    {
        Instance = this;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _spriteRenderer.enabled = false;
        _animator.enabled = false;
   }
    public void PortalActivate()
    {
        Vector3 playerPos = Player.Instance.transform.position;
        gameObject.transform.position = playerPos;
        _spriteRenderer.enabled = true;
        _animator.enabled = true;
        _isPortalActivated = true;
    }
}