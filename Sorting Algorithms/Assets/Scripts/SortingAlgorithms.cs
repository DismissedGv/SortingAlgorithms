using UnityEngine;

public class SortingAlgorithms : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int maxValue = 100;
    [SerializeField] int minValue = 1;
    [SerializeField] int range = 10;

    [Header("List")]
    [SerializeField] int[] unsorted;
    [SerializeField] int[] sorted;

    int[] arr;
    string arrayText;

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
       sorted = arr;
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
       sorted = arr;
    }

    public void QuickSortButton()
    {
        Reset();
        Quicksort(arr, 0, range - 1);
        print("Sorted array : " + arrayText);
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

        for(int i = 0; i < range; i++) //Apply random arr in the array in random amount
        {
            arr[i] = Random.Range(minValue, maxValue);
            arrayText += ", " + arr[i].ToString(); //Puts text in the same line
        }

        print("Unsorted array : " + arrayText);
        arrayText = null;
        unsorted = arr;

        return;
    }
}
