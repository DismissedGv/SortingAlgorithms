using UnityEngine;
using System.Linq;

public class BubbleSort : MonoBehaviour
{
    [Header("Settings")]
    public int maxValue = 100;
    public int minValue = 1;
    public int range = 10;

    [Header("Timer")]
    [SerializeField] float time;

    int[] arr;
    int tempArr;
    string array;
    public bool done = true;

    void Start()
    {
        arr = new int[range];
    }

    void FixedUpdate()
    {
        if(!done)
        {
            time += Time.deltaTime;
        }
    }

    public void Sort()
    {
        Reset();
        
        for(int i = 0; i < range; i++) //Apply random numbers in the array in random amount
        {
            arr[i] = Random.Range(minValue, maxValue);
            array += ", " + arr[i].ToString();
        }

        print("Unsorted array : " + array);
        array = null;
       
       for(int i = 0; i < range; i++) //Where the magic happens(Bubble sort)
       {
            for (int j = i+1; j < range; j++)
            {
                if (arr[j] < arr[i])
                {
                    tempArr = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tempArr;
                }
            }
            array += ", " + arr[i].ToString();
       }

       print("Sorted array : " + array);

       done = true;
    }   

    void Reset()
    {
        done = false;
        time = 0;
        arr = new int[range];
        array = null;
        return;
    }
}
