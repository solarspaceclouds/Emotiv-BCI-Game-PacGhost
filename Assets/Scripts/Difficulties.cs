using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor;
public class Difficulties : MonoBehaviour
{
    public enum DifficultyLevels { Basic, Expert};

    public static bool IsMultiplayer;

    public static DifficultyLevels Difficulty = DifficultyLevels.Basic;
    public void Start()
    {

    }
}
