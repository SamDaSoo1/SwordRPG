using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class CubePrice : MonoBehaviour
{
    [SerializeField] TMP_Text price;

    public int num = 0;

    private void Awake()
    {
        price.text = "0";
    }

    public void Add()
    {
        num += 100000;

        if (num > 9900000)
        {
            num = 9900000;
            return;
        }

        // 1000단위마다 콤마 넣는 포맷형식
        price.text = string.Format("{0:N0}", num);
    }

    public void Subtract()
    {
        num -= 100000;

        if (num < 0)
        {
            num = 0;
            return;
        }

        // 1000단위마다 콤마 넣는 포맷형식
        price.text = string.Format("{0:N0}", num);
    }
}
