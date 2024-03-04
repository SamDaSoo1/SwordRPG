using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quantity : MonoBehaviour
{
    [SerializeField] Sprite[] numbers;
    [SerializeField] SpriteRenderer num1;
    [SerializeField] SpriteRenderer num2;
    public int Count { get; set; }
    int idx1;
    int idx2;

    private void Awake()
    {
        idx1 = idx2 = Count = 0;
        num1.sprite = numbers[idx1];
        num2.sprite = numbers[idx2];
    }

    public void Up()
    {
        Count++;
        if (Count == 100)
        {
            Count = 99;
            return;
        }

        idx1 = Count / 10;
        idx2 = Count % 10;
        num1.sprite = numbers[idx1];
        num2.sprite = numbers[idx2];
    }

    public void Down()
    {
        Count--;
        if (Count == -1)
        {
            Count = 0;
            return;
        }

        idx1 = Count / 10;
        idx2 = Count % 10;
        num1.sprite = numbers[idx1];
        num2.sprite = numbers[idx2];
    }
}
