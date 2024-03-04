using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReward : MonoBehaviour
{
    [SerializeField] Sprite[] rewards;
    [SerializeField] GameObject bossRewardParticle1;
    [SerializeField] GameObject bossRewardParticle2;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = rewards[PlayerPrefs.GetInt("BossNum")];
        transform.localScale = Vector3.zero;
        bossRewardParticle1.SetActive(false);
        bossRewardParticle2 .SetActive(false);
    }

    public void Appear()
    {
        StartCoroutine(AppearCo());
    }

    IEnumerator AppearCo()
    {
        transform.DOScale(Vector3.one, 2f).SetEase(Ease.Linear);
        yield return (transform.DORotate(new Vector3(0, 2160f, 0), 2f, RotateMode.FastBeyond360).SetEase(Ease.Linear)).WaitForCompletion();
        bossRewardParticle1.SetActive(true);
        yield return (transform.DOScale(Vector3.one * 1.5f, 0.25f).SetEase(Ease.InOutSine)).WaitForCompletion();
        yield return (transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.InOutSine)).WaitForCompletion();
        bossRewardParticle2.SetActive(true);
    }
}
