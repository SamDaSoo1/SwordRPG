using DG.Tweening;
using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlackMageDie : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI blackMageDieText;
    [SerializeField] SpriteRenderer boss;
    [SerializeField] GameObject canvas_BlackMageDieText;

    string[] texts;
    int idx = 0;

    List<WaitForSeconds> blackMageSpeakDelay = new List<WaitForSeconds>() 
    {
        new WaitForSeconds(3f),
        new WaitForSeconds(4f),
        new WaitForSeconds(6f),
        new WaitForSeconds(4f)
    };

    List<float> blackMageTextDelay = new List<float>() { 2f, 2f, 3.5f, 3f };

    void Awake()
    {
        
        blackMageDieText.faceColor = Color.black;
        blackMageDieText.outlineColor = new Color(210 / 255f, 0, 0, 1);
        blackMageDieText.text = "";
        blackMageDieText.maxVisibleCharacters = 0;
        texts = new string[]
        {
            "대적자여...",
            "길은 이미 완성되었다.",
            "그대는 정해진 길의 끝을 향해 달려갈 뿐.",
            "오너라, 너희의 모든 것을 걸고!"
        };
    }

    // 애니메이션 클립의 이벤트에서 실행됨
    public void DieText()
    {
        canvas_BlackMageDieText.SetActive(true);
        StartCoroutine(DieTextCo());
    }

    IEnumerator DieTextCo()
    {
        if (idx == 4)
        {
            StartCoroutine(TextDisappear());
            yield break;
        }

        blackMageDieText.maxVisibleCharacters = 0;
        blackMageDieText.text = texts[idx];

        DOTween.To(x => blackMageDieText.maxVisibleCharacters = (int)x, 0f, blackMageDieText.text.Length, blackMageTextDelay[idx]).SetEase(Ease.Linear);

        // print(blackMageDieText.maxVisibleCharacters + ", "+ blackMageDieText.text.Length);
        
        yield return blackMageSpeakDelay[idx];
        idx++;

        StartCoroutine(DieTextCo());
    }

    IEnumerator TextDisappear()
    {
        float time = 1.5f;
        while(time > 0f)
        {
            blackMageDieText.color = new Color(1, 1, 1, time / 1.5f);
            time -= Time.deltaTime;
            yield return null;
        }
        blackMageDieText.color = new Color(1, 1, 1, 0);
        blackMageDieText.text = "";
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(BossDisappear());
    }

    IEnumerator BossDisappear()
    {
        float time = 1.5f;
        while (time > 0f)
        {
            boss.color = new Color(1, 1, 1, time / 1.5f);
            time -= Time.deltaTime;
            yield return null;
        }
        boss.color = new Color(1, 1, 1, 0);
    }
}
