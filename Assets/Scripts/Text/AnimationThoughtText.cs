using TMPro;
using UnityEngine;

public class AnimationThoughtText : AnimationText
{
    public static AnimationThoughtText Instance { get; private set; }
    private IText _itext;
    private void Awake()
    {
        Instance = this;
        _itext = Itext as IText;
    }
    private void Update()
    {
        if (!IsEndTextsPlayer && IsTalk && PauseComplete()) {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= Interval)
            {
                Text = CurrentText;
                if (j < TextsPlayer[i].Length)
                {
                    CurrentText += TextsPlayer[i][j];
                    j++;
                } else
                {
                    CurrentText = "";
                    j = 0;
                    if (i < TextsPlayer.Length - 1)
                    {
                        i++;
                        IsPause = true;
                    } else
                    {
                        IsEndTextsPlayer = true;
                        IsPause = true;
                    }
                    
                }
            }
        } else
        {
            if (IsEndTextsPlayer && PauseComplete())
            {
                CurrentTime = 0f;
                CurrentText = "";
                i = 0;
                IsTalk = false;
            }
        }
    }

    
    public override void StartText()
    {
        IsTalk = true;
        int index = _itext.IndexThought;
        TextsPlayer = _itext.ThoughtText[index];
        Text = "";
    }

    public override void StartText(string[] texts)
    {
        IsTalk = true;
        TextsPlayer = texts;
        Text = "";
    }



}
