using UnityEngine;
using System.Collections;

public class DarkBallEnd : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    ParticleSystem.MinMaxCurve size;
    ParticleSystem.MainModule main;
    static float InitialYPos { get; set; } = 3.3f;
    public float speed = 0f;
    float time = 0.8f;

    private void OnEnable()
    {
        gameObject.transform.position = new Vector3(0, InitialYPos, 0);
        StartCoroutine(SizeDown());
    }

    IEnumerator SizeDown()
    {
        while(true)
        {
            time -= Time.deltaTime;
            main = ps.main;
            main.startSize = time;
            size = main.startSize;
            if (size.constant == 0)
            {
                time = 0.8f;
                gameObject.SetActive(false);
                yield break;
            }
                
            yield return null;
        }
    }

    public void BossTarget()
    {
        InitialYPos = 2.5f;
    }

    public void BoxTarget()
    {
        InitialYPos = 3.3f;
    }
}
