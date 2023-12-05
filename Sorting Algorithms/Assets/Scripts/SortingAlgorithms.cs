using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class SortingAlgorithms : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int maxValue = 100;
    [SerializeField] int minValue = 1;
    [SerializeField] int range = 10;

    //Timer
    public TextMeshProUGUI currentTimeText;
    float currentTime;
    bool timerActive;

    int[] arr;
    string arrayText;

    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        if(timerActive)
        {
            currentTime += Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime); //Calmps digits 
        currentTimeText.text = time.Minutes + ":" + time.Seconds + ":" + time.Milliseconds;
    }

    public void BubbleSort()
    {
        Reset();

       
       for(int i = 0; i < range; i++) //Where the magic happens(Bubble sort)
       {
            for (int j = i+1; j < range; j++)
            {
                if (arr[j] < arr[i])
                {
                    //Swaping
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            arrayText += ", " + arr[i].ToString();
       }
       print("Sorted array : " + arrayText);
       timerActive = false;
    } 

    public void SelectionSort()
    {
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
            //Swaping
            int temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;

            arrayText += ", " + arr[i].ToString();
       }
       print("Sorted array : " + arrayText);
       timerActive = false;
    }

    public void QuickSortButton()
    {
        Reset();
        Quicksort(arr, 0, range - 1);
        print("Sorted array : " + arrayText);
        timerActive = false;
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
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
            arrayText += ", " + array[i].ToString();

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
        timerActive = true;

        for(int i = 0; i < range; i++) //Apply random arr in the array in random amount
        {
            arr[i] = UnityEngine.Random.Range(minValue, maxValue);
            arrayText += ", " + arr[i].ToString(); //Puts text in the same line
        }

        print("Unsorted array : " + arrayText);
        arrayText = null;
        return;
    }
}
