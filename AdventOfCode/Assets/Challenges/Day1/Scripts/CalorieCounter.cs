using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CalorieCounter : MonoBehaviour
{
    public List<Elf> _elves;

    void Start()
    {
        // Properties
        _elves = new List<Elf>();
        
        // Program
        string[] input = ReadInput("Assets/Challenges/Day1/Input.txt");
        AddElvesWithCalories(input);
        
        //Sort By Calorie Count Descending
        _elves.Sort((x, y) => y.CalorieCount.CompareTo(x.CalorieCount));
        
        //Find Largest (Part 1)
        Debug.Log(_elves[0].CalorieCount);
        
        //Find Sum Of 3 Largest (Part 2)
        Debug.Log(_elves[0].CalorieCount + _elves[1].CalorieCount + _elves[2].CalorieCount);
    }

    #region Input Parsing

    private string[] ReadInput(string path)
    {
        return File.ReadAllLines(path);
    }

    #endregion

    #region Calculation

    private void AddElvesWithCalories(string[] calories)
    {
        int currentTotal = 0;
        foreach (string calorie in calories)
        {
            if (calorie.Equals(""))
            {
                _elves.Add(new Elf(currentTotal));
                currentTotal = 0;
                continue;
            }
            currentTotal += Int32.Parse(calorie);
        }
        _elves.Add(new Elf(currentTotal));
    }

    #endregion

    #region Elf

    public class Elf
    {
        private int _calorieCount;

        public Elf()
        {
        }

        public Elf(int calorieCount)
        {
            _calorieCount = calorieCount;
        }

        public int CalorieCount
        {
            get => _calorieCount;
            set => _calorieCount = value;
        }

        public void AddToCalorieCount(int caloriesToAdd)
        {
            _calorieCount += caloriesToAdd;
        }
    }

    #endregion

}
