using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficultyMode : MonoBehaviour
{
    public enum Difficulties {Easy, Hard};

    public static Difficulties Difficulty = Difficulties.Hard;
}
