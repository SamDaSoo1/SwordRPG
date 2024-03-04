using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BadgeOfCreation : BaseRelic
{
    public override void OnEnable()
    {
        dataNum = "6";
        base.OnEnable();
    }

    public override void OnDisable()
    {
        dataNum = "6";
        base.OnDisable();
    }
}
