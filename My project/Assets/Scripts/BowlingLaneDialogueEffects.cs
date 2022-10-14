using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingLaneDialogueEffects
{
    //public Dictionary<string, List<DialogueEffect>> DialoguesWithEffects;

    public static Dictionary<string, List<DialogueEffect>> GetDialogueWithEffects()
    {
        Dictionary<string, List<DialogueEffect>> DialoguesWithEffects = new Dictionary<string, List<DialogueEffect>>();

        List<DialogueEffect> introEffects = new List<DialogueEffect>();
        introEffects.Add(new DialogueEffect(0, null));
        introEffects.Add(new DialogueEffect(-1, null));
        introEffects.Add(new DialogueEffect(1, null));
        DialoguesWithEffects.Add("Intro", introEffects);

        List<DialogueEffect> beforeWePlay = new List<DialogueEffect>();
        Dictionary<string, string> beforeWePlayCommandsOption1 = new Dictionary<string, string>();
        beforeWePlayCommandsOption1.Add("NextDialogueIndex", "2");
        beforeWePlay.Add(new DialogueEffect(0, "Bar", beforeWePlayCommandsOption1));
        DialoguesWithEffects.Add("BeforeWePlay", beforeWePlay);

        //List<DialogueEffect> horrorEnding = new List<DialogueEffect>();
        //horrorEnding.Add(new DialogueEffect(0, null, new List<string>() { "attack"}));
        //DialoguesWithEffects.Add("BeforeWePlay", beforeWePlay);

        return DialoguesWithEffects;
    }
    
    
}
