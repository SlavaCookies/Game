using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsGame : MonoBehaviour
{
    public static QuestionsGame Instance { get; private set; }
    [SerializeField] private TMP_Text questionsText;
    [SerializeField] private TMP_Text answersText;
    [SerializeField] private Sprite incorrectAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;
    [SerializeField] private Color startColor;
    [SerializeField] private Color targetColor;
    [SerializeField] private GameObject buttonAnswer;
    [SerializeField] private float timeColorAnswer = 0.5f;
    
    private Minimap _minimap;
    private BackpackOpen _backpackOpen;
    private QuestionsLevel _questions;
    private int _questionNumber = 0;
    private int _questionVariantNumber = 0;
    private int _answerNumber = 0;
    private Image _buttonAnswerImage;
    private Sprite _defaultButtonSprite;
    
    public Minimap minimap
    {
        get { return _minimap; }
        set { _minimap = value; }
    }
    public BackpackOpen backpackOpen
    {
        get { return _backpackOpen; }
        set { _backpackOpen = value; }
    }
    public QuestionsLevel questions
    {
        get { return _questions; }
        set { _questions = value; }
    }
    private void Awake()
    {
        Instance = this;
        _defaultButtonSprite = buttonAnswer.GetComponent<Image>().sprite;
    }
    private void Start()
    {
        _minimap.gameObject.SetActive(false);
        _backpackOpen.gameObject.SetActive(false);
        _buttonAnswerImage = buttonAnswer.GetComponent<Image>();
        SetQuestion();
    }
    
    public void NextAnswer()
    {
        if (_answerNumber == questions.answers[_questionNumber][_questionVariantNumber].Length - 1)
        {
            _answerNumber = 0;
        } else
        {
            _answerNumber++;
        }
        answersText.text = questions.answers[_questionNumber][_questionVariantNumber][_answerNumber];
    }
    public void PredAnswer()
    {
        if (_answerNumber == 0)
        {
            _answerNumber = questions.answers[_questionNumber][_questionVariantNumber].Length - 1;
        } else
        {
            _answerNumber--;
        }
        answersText.text = questions.answers[_questionNumber][_questionVariantNumber][_answerNumber];
    }
    public void ButtonAnswer()
    {
        bool isCorrectAnswer;
        if (answersText.text != questions.correctAnswers[_questionNumber][_questionVariantNumber])
        {
            StartCoroutine(AnswerIncorrect());
            isCorrectAnswer = false;
        } else
        {
            StartCoroutine(AnswerCorrect());
            isCorrectAnswer = true;
        }
        StartCoroutine(SixthLevelController(isCorrectAnswer));
        
    }
    private IEnumerator SixthLevelController(bool isAnswerForCurrentQuestion)
    {
        if (!isAnswerForCurrentQuestion) {
            StartCoroutine(GetRandomNumber());
        } else
        {
            _questionNumber++;
        }
        if (_questionNumber == 5)
        {
            Minimap.Instance.gameObject.SetActive(true);
            BackpackOpen.Instance.gameObject.SetActive(true);
            WiseDialog.Instance.DialogBeforeCompleteGameWise();
            Destroy(gameObject);
        }
        else
        {
            SetQuestion();
        }
        yield return null;
    }
    private void SetQuestion()
    {
        questionsText.text = questions.questions[_questionNumber][_questionVariantNumber];
        answersText.text = questions.answers[_questionNumber][_questionVariantNumber][0];
        _answerNumber = 0;
        
        
    }
    private IEnumerator GetRandomNumber()
    {
        bool isNumberGetted = false;
        int randomNumber = 0;
        while (!isNumberGetted)
        {
            randomNumber = Random.Range(0, questions.answers[_questionNumber][_questionVariantNumber].Length - 1);
            if (randomNumber != _questionVariantNumber)
            {
                isNumberGetted = true;
            }
        }
        _questionVariantNumber = randomNumber;
        yield return null;
    }
    private IEnumerator AnswerIncorrect()
    {
        StartCoroutine(UpdateSprite(incorrectAnswerSprite));
        yield return null;
    }
    private IEnumerator AnswerCorrect()
    {
        StartCoroutine(UpdateSprite(correctAnswerSprite));
        yield return null;
    }
    private IEnumerator UpdateSprite(Sprite sprite)
    {
        _buttonAnswerImage.sprite = sprite;
        float elapsed = 0f;
        while (elapsed < timeColorAnswer)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / timeColorAnswer;
            Color currentColor = Color.Lerp(startColor, targetColor, t);//
            _buttonAnswerImage.color = currentColor;
            yield return null;
        }
        _buttonAnswerImage.sprite = _defaultButtonSprite;
        Color defaultColor = _buttonAnswerImage.color;
        defaultColor.a = 255;
        defaultColor.r = 255;
        defaultColor.g = 255;
        defaultColor.b = 255;
        _buttonAnswerImage.color = defaultColor;
    }
}
