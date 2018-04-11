using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gold.Delegates;

public class GameManager : MonoBehaviour
{
    private static int _score;
    public static ValueChange<int> OnScoreChange;
    public static int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScoreChange(_score);
        }
    }
}
