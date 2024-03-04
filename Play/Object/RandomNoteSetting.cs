using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------MVC(Model, View, Control)클래스를 정의해서 끼리끼리 모아놓으면 관리하기 좋다-----------

// [System.Serializable] : 클래스를 인스펙터에 보이게 하고 싶을 때 사용하는 애트리뷰트

[System.Serializable]
public class RandomNoteSetting_model  //data
{

}

public class RandomNoteSetting_view //ui
{
    
}

public class RandomNoteSetting_cotrl // process
{

}

// --------------------------------------------------------------------------------------------

public class RandomNoteSetting : MonoBehaviour
{
    [SerializeField] Sprite mesoNoteImg;
    [SerializeField] Sprite bombNoteImg;
    [SerializeField] GameObject[] rightNote;
    [SerializeField] GameObject[] leftNote;

    int index = 2;
    public int Idx
    {
        get { return index; }
        set
        {
            index = value;
            if (index < 0) { index = 10; }
        }
    }

    public void Set()
    {
        int ranNum = Random.Range(0, 2);

        if (ranNum == 0)
        {
            rightNote[index].tag = "Meso";
            rightNote[index].GetComponent<SpriteRenderer>().sprite = mesoNoteImg;
            leftNote[index].tag = "Bomb";
            leftNote[index].GetComponent<SpriteRenderer>().sprite = bombNoteImg;
        }
        else if (ranNum == 1)
        {
            rightNote[index].tag = "Bomb";
            rightNote[index].GetComponent<SpriteRenderer>().sprite = bombNoteImg;
            leftNote[index].tag = "Meso";
            leftNote[index].GetComponent<SpriteRenderer>().sprite = mesoNoteImg;
        }

        Idx -= 1;
    }
}
