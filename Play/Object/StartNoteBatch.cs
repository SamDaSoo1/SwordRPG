using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNoteBatch : MonoBehaviour
{
    [SerializeField] GameObject[] RNote;
    [SerializeField] GameObject[] LNote;
    [SerializeField] Sprite[] NoteSprite;
    [SerializeField] NoteFailGauge noteFailGauge;

    readonly float rNoteXPos = 1.6f;
    readonly float lNoteXPos = -1.6f;
    readonly float noteSettingDuration = 0.25f;
    readonly int noteInterval = 1;

    float yPos = 7.5f;

    void Start()
    {
        StartCoroutine(Setting());
    }

    IEnumerator Setting()
    {
        noteFailGauge.KeyBoardLock = true;
        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < RNote.Length; i++)
        {
            int ranNum = Random.Range(0, 2);

            if(ranNum == 0)
            {
                RNote[i].GetComponent<SpriteRenderer>().sprite = NoteSprite[0];
                RNote[i].tag = "Meso"; 
                LNote[i].GetComponent<SpriteRenderer>().sprite = NoteSprite[1];
                LNote[i].tag = "Bomb";
            }
            else
            {
                RNote[i].GetComponent<SpriteRenderer>().sprite = NoteSprite[1];
                RNote[i].tag = "Bomb";
                LNote[i].GetComponent<SpriteRenderer>().sprite = NoteSprite[0];
                LNote[i].tag = "Meso";
            }

            RNote[i].transform.DOMove(new(rNoteXPos, yPos, 0), noteSettingDuration);
            LNote[i].transform.DOMove(new(lNoteXPos, yPos, 0), noteSettingDuration);

            yPos -= noteInterval;

            yield return null;
        }

        yield return new WaitForSeconds(0.25f);
        noteFailGauge.KeyBoardLock = false;
    }
}