using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class DialogField : MonoBehaviour
{
    [SerializeField] private GameObject dialogField;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private float lineFirstDialog;
    [SerializeField] private float lineSecondDialog;
    [SerializeField] private float lineDialogY1;
    [SerializeField] private float lineDialogY2;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float timeFollow;
    [SerializeField] private float timeStayCamera;
    private DialogEnum.DialogLevelEnum _dialogEnum = DialogEnum.DialogLevelEnum.StartLevelEnter;
    private bool _isDialogStarted = false;
    private Vector3 _startPos;
    private float _currentTimeCameraStay = 0f;
    private bool _isCameraMoved = false;
    private Transform _followCamera;
    private float t = 0f;
    private void Awake()
    {
        dialogField.SetActive(false);
    }


    private void Update()
    {
        float playerPosition = Player.Instance.transform.position.x;
        switch (_dialogEnum)
        {
            case DialogEnum.DialogLevelEnum.StartLevelEnter:
                if (playerPosition >= lineFirstDialog && !dialogField.activeSelf)
                {
                    _isDialogStarted = true;
                    dialogField.SetActive(true);
                    AnimationThoughtText.Instance.StartText(
                        PlayerThoughts.Instance.StartLevelPlayerThoughts());
                }
                else
                {
                    if (AnimationThoughtText.Instance.IsTalk == false && _isDialogStarted)
                    {
                        dialogField.SetActive(false);
                        _dialogEnum++;
                        _isDialogStarted = false;
                        AnimationThoughtText.Instance.IsEndTextsPlayer = false;
                    }
                }
                break;
            case DialogEnum.DialogLevelEnum.StartLevelBox:
                if (playerPosition >= lineSecondDialog && !_isCameraMoved)
                {
                    if (!dialogField.activeSelf)
                    {
                        _isDialogStarted = true;
                        dialogField.SetActive(true);
                        AnimationThoughtText.Instance.StartText(
                            PlayerThoughts.Instance.StartLevelPlayerThoughtsBox());

                        Player.Instance.IsFreezePlayer = true;
                        Player.Instance.IsRunning = false;
                        _startPos = cinemachineCamera.transform.position;
                        _followCamera = cinemachineCamera.Follow;
                        cinemachineCamera.Follow = null;
                    }
                    CameraMove();
                } else
                {
                    if (AnimationThoughtText.Instance.IsTalk == false && _isDialogStarted)
                    {
                        dialogField.SetActive(false);
                        _isDialogStarted = false;
                        _dialogEnum++;
                        cinemachineCamera.Follow = _followCamera;
                        Player.Instance.IsFreezePlayer = false;
                        AnimationThoughtText.Instance.IsEndTextsPlayer = false;

                    }
                }
                break;
            case DialogEnum.DialogLevelEnum.None:
                break;
        }
    }
//    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.orange;
        Gizmos.DrawLine(new Vector2(lineFirstDialog, lineDialogY1),
            new Vector2(lineFirstDialog, lineDialogY2));
        Gizmos.DrawLine(new Vector2(lineSecondDialog, lineDialogY1),
            new Vector2(lineSecondDialog, lineDialogY2));
    }

    private void CameraMove()
    {
        ChangeTimeCameraStay(); 
        if (_currentTimeCameraStay < timeStayCamera)
        {
            t = _currentTimeCameraStay / timeFollow;
            cinemachineCamera.transform.position = Vector3.Lerp(_startPos, targetPos, t);
            Debug.Log(t);
        }
        else
        {
            t = (_currentTimeCameraStay - timeStayCamera) / timeFollow;
            cinemachineCamera.transform.position = Vector3.Lerp(targetPos, _startPos, t);
            if (_currentTimeCameraStay >= timeStayCamera + timeFollow)
            {
                _isCameraMoved = true;
                Player.Instance.IsFreezePlayer = false;
            }
        }
    }
    
    private void ChangeTimeCameraStay()
    {
        _currentTimeCameraStay += Time.deltaTime;
    }
}















