using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SourceOfPain : BaseRelic
{
    public override void OnEnable()
    {
        dataNum = "5";
        base.OnEnable();
    }

    public override void OnDisable()
    {
        dataNum = "5";
        base.OnDisable();
    }
}
