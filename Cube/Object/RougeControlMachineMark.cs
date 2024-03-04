using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BaseRelic : MonoBehaviour
{
    [SerializeField] AbilityManager abilityManager;
    [SerializeField] Text grade;
    [SerializeField] Text NotLiberated;
    [SerializeField] Text abil1;
    [SerializeField] Text abil2;
    [SerializeField] Text abil3;

    RelicData data;

    int ranNum1;
    int ranNum2;
    int ranNum3;
    int ranNumLimit;
    int gradeNum;

    const int autoclickNum = 9984;

    protected string dataNum;

    public virtual void OnEnable()
    {
        string path = Path.Combine(Application.persistentDataPath, "RelicData" + dataNum + ".json");
        string jsonData = File.ReadAllText(path);
        data = JsonUtility.FromJson<RelicData>(jsonData);
        if (data.isOpen)
        {
            grade.text = data.grade;
            NotLiberated.enabled = false;
            abil1.text = data.ability1;
            abil2.text = data.ability2;
            abil3.text = data.ability3;
        }
        else if (!data.isOpen)
        {
            grade.text = "";
            NotLiberated.enabled = true;
            abil1.text = "";
            abil2.text = "";
            abil3.text = "";
        }
    }
    public virtual void OnDisable()
    {
        string jsonData = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.persistentDataPath, "RelicData" + dataNum + ".json");
        File.WriteAllText(path, jsonData);
    }
    public virtual bool IsOpen() 
    { 
        return data.isOpen; 
    }
    public virtual void Open() 
    {
        data.isOpen = true;
        ranNumLimit = 100;

        data.grade = "레어";
        abilityManager.NotLiberatedTextDisable();

        OptionGacha();
    }
    public virtual bool SetUp() 
    {
        // Rare -> Epic : 15%
        // Epic -> Unique : 3.5%
        // Unique -> Legendary : 1.4%


        if (data.grade == "레어")
        {
            ranNumLimit = 100;
            gradeNum = 15;

            if (Random.Range(0, ranNumLimit) < gradeNum)
            {
                GradeUp();
                return true;
            }
        }
        else if (data.grade == "에픽")
        {
            ranNumLimit = 1000;
            gradeNum = 35;

            if (Random.Range(0, ranNumLimit) < gradeNum)
            {
                GradeUp();
                return true;
            }
        }
        else if (data.grade == "유니크")
        {
            ranNumLimit = 1000;
            gradeNum = 14;

            if (Random.Range(0, ranNumLimit) < gradeNum)
            {
                GradeUp();
                return true;
            }
        }
        else if (data.grade == "레전드리")
        {
            ranNumLimit = 10000;
        }

        OptionGacha();

        return false;
    }
    public virtual void GradeUp()
    {
        if (data.grade == "레어")
        {
            data.grade = "에픽";
            ranNumLimit = 1000;
        }
        else if (data.grade == "에픽")
        {
            data.grade = "유니크";
            ranNumLimit = 1000;
        }
        else if (data.grade == "유니크")
        {
            data.grade = "레전드리";
            ranNumLimit = 10000;
        }

        OptionGacha();
    }
    public virtual void OptionGacha()
    {
        int count = 0;
       
        // 만약 오토클릭 옵션이 2개이상 뜨면 옵션 재설정
        while(true)
        {
            ranNum1 = Random.Range(0, ranNumLimit);
            ranNum2 = Random.Range(0, ranNumLimit);
            ranNum3 = Random.Range(0, ranNumLimit);

            if (autoclickNum <= ranNum1) { count++; }
            if (autoclickNum <= ranNum2) { count++; }
            if (autoclickNum <= ranNum3) { count++; }

            if (count <= 1) { break; }

            count = 0;
        }
 
        data.ability1 = abilityManager.Option(ranNum1, data.grade);
        data.ability2 = abilityManager.Option(ranNum2, data.grade);
        data.ability3 = abilityManager.Option(ranNum3, data.grade);

        StartCoroutine(abilityManager.AbilityOpenTextUpdate(data.ability1, data.ability2, data.ability3, data.grade));
    }
}

public class RougeControlMachineMark : BaseRelic
{
    public override void OnEnable()
    {
        dataNum = "1";
        base.OnEnable();
    }

    public override void OnDisable()
    {
        dataNum = "1";
        base.OnDisable();
    }
}
