using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    [SerializeField] private ESCMenu escMenu;
    [SerializeField] private Transform canvasTransform;
    public PlayerInputActions _playerInputActions;
    private InputAction _inputAction;

    private GameObject _newESCMenu;
    public List<IButtonSpace> spaceButtons = new List<IButtonSpace>();
    public List<IButtonE> EButtons = new List<IButtonE>();
    public List<IInterract> FButtons = new List<IInterract>();
    

    private void Awake()
    {
        Instance = this;
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
    }

    public void DisabledMovement()
    {
        _playerInputActions.Disable();
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        OnEnableSpaceButton();
        OnEnableEButton();
        OnEnableFButton();
        OnEnableEscapeButton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnableSpaceButton()
    {
        _playerInputActions.Player.InteractWithNPC.performed += InteractWithNPC_performed;
    }
    private void OnDisableSpaceButton()
    {
        _playerInputActions.Player.InteractWithNPC.performed -= InteractWithNPC_performed;
    }
    private void OnEnableEButton()
    {
        _playerInputActions.Player.TakeItem.performed += TakeItem_performed;
    }
    private void OnDisableEButton()
    {
        _playerInputActions.Player.TakeItem.performed -= TakeItem_performed;
    }
    private void OnEnableFButton()
    {
        _playerInputActions.Player.Interract.performed += Interract_performed;
    }
    private void OnDisableFButton()
    {
        _playerInputActions.Player.Interract.performed -= Interract_performed;
    }
    private void OnEnableEscapeButton()
    {
        _playerInputActions.Player.Exit.performed += Exit_performed;
    }
    private void OnDisableEscapeButton()
    {
        _playerInputActions.Player.Exit.performed -= Exit_performed;
    }
    private void InteractWithNPC_performed(InputAction.CallbackContext context)
    {
        foreach (var spaceButton in spaceButtons)
        {
            if (spaceButton.IsActive())
            {
                if (!AnimationDialogText.Instance.IsTalk)
                {
                    spaceButton.StartDialog();
                }
            }
        }
    }
    private void TakeItem_performed(InputAction.CallbackContext context)
    {
        Debug.Log("EButton");
        for (int i = 0; i < EButtons.Count; ++i)
        {
            if (EButtons[i] != null && EButtons[i].IsActive())
            {
                EButtons[i].AddToInventory();
            }
        }
        for (int i = 0; i < EButtons.Count; ++i)
        {
            if (EButtons[i].GetIsActivated())
            {
                EButtons[i].DestroyThisObjectButton();
                EButtons.Remove(EButtons[i]);
            }
        }
    }
    private void Interract_performed(InputAction.CallbackContext context)
    {

        for (int i = 0; i < FButtons.Count; ++i)
        {
            if (FButtons[i]?.IsActive() == true)
            {
                FButtons[i].Interract();
            }
        }
        for (int i = 0; i < FButtons.Count; ++i)
        {
            if (FButtons[i].IsRemove())
            {
                FButtons.Remove(FButtons[i]);
            }
        }
    }
    private void Exit_performed(InputAction.CallbackContext context)
    {
        if (_newESCMenu == null)
        {
            _newESCMenu = Instantiate(escMenu.gameObject, canvasTransform);
        } else
        {
            ESCMenu escMenuFunctions = _newESCMenu.GetComponent<ESCMenu>();
            escMenuFunctions.ContinueGame();
        }
    }
    private void OnDestroy()
    {
        if (_playerInputActions != null)
        {
            OnDisableSpaceButton();
            OnDisableEButton();
            OnDisableFButton();
            OnDisableEscapeButton();
            _playerInputActions.Player.Disable();
            _playerInputActions.Dispose();
            _playerInputActions = null;
        }
    }
}