using UnityEngine;
using UnityEngine.UI;
public class EndGameMessage : MonoBehaviour
{
    // Start is called before the first frame update 
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame

    private void Update()
    {
        if (ScoreTextScript.gameWon == true)
        {
            Debug.Log("Won");
            text.text = "You Won! Well done!";
        }
        else if (ScoreTextScript.gameWon == false)
        {
            Debug.Log("Lost");
            text.text = "Game Over Sorry :(";
        }
    }
}
