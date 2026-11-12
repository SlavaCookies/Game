using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class VideoControllDance : MonoBehaviour
{
    [SerializeField] private VideoClip[] videoClips;
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private TextMeshProUGUI textNumberObject;
    private string[] textsEducation = new string[] { 
    "—ейчас будут показыватьс€ последовательности, по одной на каждый сценарий. ¬аша задача запомнить эту последователь-ность" +
        " и повторить еЄ правильным образом. ƒл€ того, чтобы пос-ледовательность начала по-€вл€тьс€, необходимо" +
        " зайти в зелЄную область и быть там секунду. ƒалее будет отсчЄт после которого начнЄтс€ последова-тельность.",
    "≈сли в какой-то момент вы наступите не на ту клетку, то пройденна€ последовательность начнЄт мигать красным, а ваше движение будет заморожено," +
        " пос-ле того, как мигание пройдЄт, вы будете телепортированы на начало," +
        " а также будет разморожено движение. " +
        " “акже будет доступна возможность снова увидеть последовательность.",
    "≈сли последовательность была пройдена правильно, то она начнЄт мигать зелЄным цветом. ѕосле текущей последовательности бу-дет показыватьс€" +
        " следующа€ пос-ледовательность, если текуща€ последовательность была пос-ледней, то на карте по€витс€ ключ дл€ открыти€ двери этажа."
    };
    private int _currentIndexPage = 0;
    public void NextPageEducation()
    {
        if (_currentIndexPage < (videoClips.Length - 1))
        {
            _currentIndexPage++;
            textObject.text = textsEducation[_currentIndexPage];
            videoPlayer.Stop();
            videoPlayer.clip = videoClips[_currentIndexPage];
            videoPlayer.Prepare();
            videoPlayer.Play();
            textNumberObject.text = $"{_currentIndexPage + 1}/{videoClips.Length}";
        }
    }

    public void PredPageEducation()
    {
        if (_currentIndexPage > 0)
        {
            _currentIndexPage--;
            textObject.text = textsEducation[_currentIndexPage];
            videoPlayer.Stop();
            videoPlayer.clip = videoClips[_currentIndexPage];
            videoPlayer.Prepare();
            videoPlayer.Play();
            textNumberObject.text = $"{_currentIndexPage + 1}/{videoClips.Length}";
        }
    }
    private void Awake()
    {
        videoPlayer.clip = videoClips[_currentIndexPage];
        videoPlayer.Prepare();
        videoPlayer.Play();
        textObject.text = textsEducation[0];
        textNumberObject.text = $"{_currentIndexPage + 1}/{videoClips.Length}";
    }
    private void OnDestroy()
    {
        videoPlayer.Stop();
        FifthLevel.Instance.CreateDancePlace();
    }
}
