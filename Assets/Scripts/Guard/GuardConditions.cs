using System.Runtime.CompilerServices;
using UnityEngine;

public class GuardConditions : MonoBehaviour, IConditionsDialog
{
    [SerializeField] private MonoBehaviour itext;
    [SerializeField] private float needTimeToResetWait = 5f;
    [SerializeField] private Rabbit rabbit;
    [SerializeField] private Vector3 positionRabbit;
    [SerializeField] private OpenDoorAndInTower openDoorAndInTower;
    private IText _itext;
    private AnyLevelButtonDialog _buttonDialog;
    private bool _isGuardAsked = false;
    private float _currentTimeToResetWait = 0f;
    private void Start()
    {
        _buttonDialog = GetComponent<AnyLevelButtonDialog>();
        _itext = itext as IText;
    }
    public void Condition()
    {
        switch (_itext.IndexDialogText)
        {
            case 0:
                DialogFunction.Instance.Dialog(0);
                _itext.IndexDialogText++;
                break;
            case 1:
                DialogFunction.Instance.Dialog(1);
                _isGuardAsked = true;
                _currentTimeToResetWait = 0f;
                break;
            case 2:
                DialogFunction.Instance.Dialog(2);
                _itext.IndexDialogText++;
                PlayerObject.Instance.SpriteRenderer.sprite = null;
                rabbit.gameObject.SetActive(true);
                rabbit.gameObject.transform.position = positionRabbit;
                rabbit.spriteRenderer.sortingOrder = 0;
                rabbit.TakeRabbitObject.gameObject.SetActive(false);
                rabbit.ButtonVision.enabled = false;
                openDoorAndInTower.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (_currentTimeToResetWait >= needTimeToResetWait)
        {
            _isGuardAsked = false;
        } else
        {
            _currentTimeToResetWait += Time.deltaTime;
        }
        if (PlayerObject.Instance.NameObject == RabbitSO.rabbitName &&
            _itext.IndexDialogText == 1 && _isGuardAsked && 
            !AnimationDialogText.Instance.IsTalk)
        {
            _itext.IndexDialogText++;
            Condition();
        }
    }
}
