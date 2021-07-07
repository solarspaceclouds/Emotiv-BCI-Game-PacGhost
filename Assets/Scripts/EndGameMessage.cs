using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndGameMessage : MonoBehaviour
{
    // Start is called before the first frame update 
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        if (ScoreTextScript.gameWon == 1)
        {
            Debug.Log("Won");
            text.text = "You Won! Well done!";

        }
        else if (ScoreTextScript.gameWon == 2)
        {
            Debug.Log("Lost");
            text.text = "Game Over Sorry :(";
        }
    }

    // Update is called once per frame

    private void Update()
    {
        
    }
}
