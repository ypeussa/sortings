using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sorters : MonoBehaviour
{
    private const int Size = 10;
    private int _lowIndex, _lowMid, _highMid, _highIndex; 
    private int[] _ints;
    
    private void Start()
    {
        Create();
        Print();
        
        Randomize();
        Print();
        
        Sort();
        Print();
    }

    private void Create()
    {
        _ints = new int[Size];

        for (var i = 0; i < _ints.Length; i++)
        {
            _ints[i] = i;
        }
    }
    
    private void Randomize()
    {
        var catalog = _ints.ToList();
        
        for (var i = 0; i < _ints.Length; i++)
        {
            var rndIndex = Random.Range(0, catalog.Count);
            
            _ints[i] = catalog[rndIndex];
            
            catalog.RemoveAt(rndIndex);
        }
    }

    private void Sort()
    {
        // The algorithm consists of array indexes, the search areas, sort areas
        // and the logic how to move values from and to those areas
        
        // There is a lowIndex and everything below that is sorted
        // The lowIndex starts from array start
        
        // There is a lowerMidIndex and a higherMidIndex and everything in between them is sorted
        // In the start these are in same index which is in the middle of the array
        
        // There is a highIndex and everything above that is sorted
        // The highIndex starts from array end
        
        // The search areas are
        // lowerSearchArea between lowIndex and lowerMidIndex
        // higherSearchArea between higherMidIndex and highIndex
        
        // The sort areas are:
        // lowSortArea that is in lowerIndex or below,
        // lowMidSortArea that is the index below lowerMidIndex,
        // midSortArea in between lowerMidIndex and higherMidIndex,
        // highMidSortArea index above higherMidIndex,
        // highSortArea in highIndex or above
        
        // The algorithm
        // Take value from checkIndex (In the start: first index above lowIndex) and compare value of
        // lowIndex => if smaller place to correct index in lowSortArea => lowIndex++
        // lowerMidIndex => if lower than lowerMidIndex and highSearchArea => move to lowerMidIndex - 1 => lowerMidIndex--
        // higherMidIndex => if higher than higherMidIndex and smaller than highIndex and lowerSearchArea => move to higherMidIndex + 1 => higherMidIndex++
        // highIndex => if larger place to correct index in highSortArea => highIndex--
        // After comparisons and possible movement take a new value for comparison
    }

    private void Print()
    {
        var array = _ints.Aggregate("", (current, value) => current + (value + ", "));
        
        Debug.Log(array);
    }
}
