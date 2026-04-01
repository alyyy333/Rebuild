using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static int score = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddScore()
    {
        score += 1;
        Debug.Log(score);
    }
}
