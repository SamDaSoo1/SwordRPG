using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BeltOfDreams : BaseRelic
{
    public override void OnEnable()
    {
        dataNum = "3";
        base.OnEnable();
    }

    public override void OnDisable()
    {
        dataNum = "3";
        base.OnDisable();
    }
}
