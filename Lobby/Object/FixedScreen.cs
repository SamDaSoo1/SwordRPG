using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedScreen : MonoBehaviour
{
    private void Start()
    {
        SetResolution();
    }

    /// <summary>
    /// �ػ� ���� �Լ�
    /// </summary>
    public void SetResolution()
    {
        int setWidth = 540; // ȭ�� �ʺ�
        int setHeight = 960; // ȭ�� ����

        //�ػ󵵸� �������� ���� ����
        //3��° �Ķ���ʹ� Ǯ��ũ�� ��带 ���� > true : Ǯ��ũ��, false : â���
        Screen.SetResolution(setWidth, setHeight, false);
    }
}
