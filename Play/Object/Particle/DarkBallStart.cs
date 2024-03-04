using UnityEngine;
using System.Collections;

public class DarkBallStart : MonoBehaviour
{
    float speed;
    static float ArrivalLocation { get; set; } = 3.3f;
    Vector3 resetPos = new(0, -3.8f, 0);

    private void Awake()
    {
        speed = 30f;
    }

    void Update() 
    {
        if (Time.timeScale == 0) return;

        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.y > ArrivalLocation)
        {
            gameObject.SetActive(false);
        }  
	}

    private void OnEnable()
    {
        transform.position = resetPos;
    }

    public void BossTarget()
    {
        ArrivalLocation = 2.5f;
    }

    public void BoxTarget()
    {
        ArrivalLocation = 3.3f;
    }
}
