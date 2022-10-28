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
        beforeWePlay.Add(new DialogueEffect(0, "Bar", new Dictionary<string, string>() { { "NextDialogueIndex", "1" } }));
        DialoguesWithEffects.Add("BeforeWePlay", beforeWePlay);

        //List<DialogueEffect> horrorEnding = new List<DialogueEffect>();
        //horrorEnding.Add(new DialogueEffect(0, null, new List<string>() { "attack"}));
        //DialoguesWithEffects.Add("BeforeWePlay", beforeWePlay);

        List<DialogueEffect> BarEffect = new List<DialogueEffect>();
        BarEffect.Add(new DialogueEffect(1, null));
        BarEffect.Add(new DialogueEffect(-1, null));
        BarEffect.Add(new DialogueEffect(-1, null));
        DialoguesWithEffects.Add("Bar", BarEffect);

        List<DialogueEffect> jukeboxEffects = new List<DialogueEffect>();
        jukeboxEffects.Add(new DialogueEffect(0, null, new Dictionary<string, string>() {{"ChangeSong", "0" }}));
        jukeboxEffects.Add(new DialogueEffect(0, null, new Dictionary<string, string>() { { "ChangeSong", "0" } }));
        jukeboxEffects.Add(new DialogueEffect(0, null, new Dictionary<string, string>() { { "ChangeSong", "0" } }));
        DialoguesWithEffects.Add("JukeBox", jukeboxEffects);

        return DialoguesWithEffects;
    }
    
    
}
