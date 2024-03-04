using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EyepatchImbuedwithMagic : BaseRelic
{
    public override void OnEnable()
    {
        dataNum = "2";
        base.OnEnable();
    }

    public override void OnDisable()
    {
        dataNum = "2";
        base.OnDisable();
    }
}
