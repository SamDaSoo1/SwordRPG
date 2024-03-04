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
            // 데이터를 저장할 경로 지정
            string path = Path.Combine(Application.persistentDataPath, "RelicData" + i.ToString() + ".json");
            // ToJson을 사용하면 JSON형태로 포멧팅된 문자열이 생성된다  
            string jsonData = JsonUtility.ToJson(new RelicData { grade = "레어", ability1 = "", ability2 = "", ability3 = "", isOpen = false }, true);
            
            // 만약 이미 데이터가 존재한다면 만들지않음
            if (File.Exists(path))
                return;

            // 파일 생성 및 저장
            File.WriteAllText(path, jsonData);
        }
    } 
}
