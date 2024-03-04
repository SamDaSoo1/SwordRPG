using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RelicData
{
    public string grade;
    public string ability1;
    public string ability2;
    public string ability3;
    public bool isOpen;
}

public class JsonCreate : MonoBehaviour
{
    void Awake()
    {
        for (int i = 1; i <= 6; i++)
        {
            // �����͸� ������ ��� ����
            string path = Path.Combine(Application.persistentDataPath, "RelicData" + i.ToString() + ".json");
            // ToJson�� ����ϸ� JSON���·� �����õ� ���ڿ��� �����ȴ�  
            string jsonData = JsonUtility.ToJson(new RelicData { grade = "����", ability1 = "", ability2 = "", ability3 = "", isOpen = false }, true);
            
            // ���� �̹� �����Ͱ� �����Ѵٸ� ����������
            if (File.Exists(path))
                return;

            // ���� ���� �� ����
            File.WriteAllText(path, jsonData);
        }
    } 
}
