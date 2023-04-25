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
        
    }

    private void Print()
    {
        var array = _ints.Aggregate("", (current, value) => current + (value + ", "));
        
        Debug.Log(array);
    }
}
