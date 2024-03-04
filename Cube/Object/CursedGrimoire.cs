using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CursedGrimoire : BaseRelic
{
    public override void OnEnable()
    {
        dataNum = "4";
        base.OnEnable();
    }

    public override void OnDisable()
    {
        dataNum = "4";
        base.OnDisable();
    }
}
