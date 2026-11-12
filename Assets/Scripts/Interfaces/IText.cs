using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public interface IText
{
    public List<string[]> ThoughtText { get; set; }
    public List<string[]> DialogTextsPlayer { get; set; }
    public List<string[]> DialogTextsNPC { get; set; }
    public List<string> WhoStartTalk { get; set; }
    public int IndexThought { get; set; }
    public int IndexDialogText { get; set; }
}
