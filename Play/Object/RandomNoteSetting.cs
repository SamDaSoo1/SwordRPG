using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------MVC(Model, View, Control)Ŭ������ �����ؼ� �������� ��Ƴ����� �����ϱ� ����-----------

// [System.Serializable] : Ŭ������ �ν����Ϳ� ���̰� �ϰ� ���� �� ����ϴ� ��Ʈ����Ʈ

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
