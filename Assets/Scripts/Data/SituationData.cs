using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Situation", menuName = "ScriptableObjects/GameplaySituation")]
public class SituationData : ScriptableObject
{
    public string character;
    [TextArea]
    public string brief;

    public Sprite characterSprite;

    public SituationType type;

    public Decision[] decisions;

    public Situation GetSituation()
    {
        Situation situation;
        situation = new Situation(type, brief, decisions.Length, characterSprite);

        situation.SetDecisions(decisions);
        
        return situation;
    }
}
