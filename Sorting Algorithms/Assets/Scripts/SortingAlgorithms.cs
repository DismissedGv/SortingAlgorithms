using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SortingAlgorithms : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int range = 10;

    //Timer
    float startTime;
    float currentTime;
    int[] arr;
    string arrayText;

    void Start()
    {
        startTime = Time.realtimeSinceStartup;
    }

    public void BubbleSort()
    {   
        startTime = Time.realtimeSinceStartup;
        Reset();

       
       for(int i = 0; i < range; i++) //Where the magic happens
       {
            for (int j = i+1; j < range; j++)
            {
                if (arr[j] < arr[i])
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            arrayText += ", " + arr[i].ToString();
       }
       currentTime = Time.realtimeSinceStartup - startTime;
       print("Bubble sorted runtime: " + (currentTime * 1000f) + "ms " + "array : " + arrayText);
    } 

    public void SelectionSort()
    {
        startTime = Time.realtimeSinceStartup;
        Reset();

        for(int i = 0; i < range; i++)
       {
        int min = i;
            for (int j = i+1; j < range; j++)
            {
                if (arr[min] > arr[j])
                {
                    min = j;
                }
            }
           
            (arr[i], arr[min]) = (arr[min], arr[i]);

            arrayText += ", " + arr[i].ToString();
       }
       currentTime = Time.realtimeSinceStartup - startTime;
       print("Bubble sorted runtime: " + (currentTime * 1000f) + "ms " + "array : " + arrayText);
    }

    public void QuickSortButton()
    {
        startTime = Time.realtimeSinceStartup;
        Reset();
        Quicksort(arr, 0, range - 1);
        for(int i = 0; i < arr.Length; i++)
        {
            arrayText += ", " + arr[i].ToString();
        }
        currentTime = Time.realtimeSinceStartup - startTime;
       print("Bubble sorted runtime: " + (currentTime * 1000f) + "ms " + "array : " + arrayText);
    }
    void Quicksort(int[] array, int left, int right)
{
    int i = left;
    int j = right;
    int pivot = array[(left + right) / 2];

    while(i <= j)
    {
        while (array[i] < pivot)
        {
            i++;
        }

        while (array[j] > pivot)
        {
            j--;
        }

        if(i <= j)
        {
            (arr[i], arr[j]) = (arr[j], arr[i]);
            i++;
            j--;
        }
    }

    if (left < j)
    {
        Quicksort(array, left, j);
    }

    if (i < right)
    {
        Quicksort(array, i, right);
    }
}

    void Reset()
    {
        arr = new int[range];
        arrayText = null;
        for(int i = 0; i < range; i++)
        {
            arr[i] = UnityEngine.Random.Range(1, range);
            arrayText += ", " + arr[i].ToString(); //Putting the text in the same line
        }

        print("Unsorted array : " + arrayText);
        arrayText = null;
        return;
    }
}
