using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Situation", menuName = "ScriptableObjects/GameplaySituation")]
public class SituationData : ScriptableObject
{
    [TextArea]
    public string brief;

    public Decision[] decisions;

    public Situation GetSituation()
    {
        Situation situation;
        situation = new Situation(brief, decisions.Length);

        situation.SetDecisions(decisions);
        
        return situation;
    }
}
