using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcButton : MonoBehaviour
{
    [SerializeField] GameObject npcBox;
    [SerializeField] Image buttonLockImg;
    [SerializeField] Text txt;
    [SerializeField] BaseRelic[] relics;

    public void OnClick()
    {
        if (relics[PlayerPrefs.GetInt("SelectRelic")].IsOpen()) { return; }

        SoundManager.instance.PlaySFX(eSound.Window);

        buttonLockImg.enabled = true;
        npcBox.transform.localScale = Vector3.one;
        txt.text = "봉인을 해제하시겠습니까?\r\n\r\n비용: 100,000";
    }
}
