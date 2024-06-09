using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class timelineTenda1 : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] DialogueManagerV2 dialogueManagerV2;

    // Update is called once per frame
    void Update()
    {
        PlayTimeline();
    }

    void PlayTimeline()
    {
        if (dialogueManagerV2.countClickButton == dialogueManagerV2.countSentences)
        {
            playableDirector.Play();
            dialogueManagerV2.countClickButton = 0
;
        }
    }
}
