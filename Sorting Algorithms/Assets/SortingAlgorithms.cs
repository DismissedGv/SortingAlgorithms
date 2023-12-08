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
    public float temp;

    void Start()
    {
        startTime = Time.realtimeSinceStartup;
    }

    public void BubbleSort()
    {   
        Reset();
        startTime = Time.realtimeSinceStartup;
               
       for(int i = 0; i < range - 1; i++) //Where the magic happens
       {
            for (int j = 0; j < range - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);
                }
            }
       }
       currentTime = Time.realtimeSinceStartup - startTime;

       for(int i = 0; i < range; i++) { arrayText += ", " + arr[i].ToString(); }
       print("Bubble sorted runtime: " + (currentTime * 1000f) + "ms " + "array : " + arrayText);
       temp = currentTime;
    } 

    public void SelectionSort()
    {
        Reset();
        startTime = Time.realtimeSinceStartup;

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
       }
       currentTime = Time.realtimeSinceStartup - startTime;
       
       for(int i = 0; i < range; i++) { arrayText += ", " + arr[i].ToString(); }
       print("Bubble sorted runtime: " + (currentTime * 1000f) + "ms " + "array : " + arrayText);
       temp = currentTime;
    }

    public void QuickSortButton()
    {
        Reset();
        startTime = Time.realtimeSinceStartup;
        Quicksort(arr, 0, range - 1);
        
        currentTime = Time.realtimeSinceStartup - startTime;

        for(int i = 0; i < range; i++) { arrayText += ", " + arr[i].ToString(); }
        print("Bubble sorted runtime: " + (currentTime * 1000f) + "ms " + "array : " + arrayText);
        temp = currentTime;
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
