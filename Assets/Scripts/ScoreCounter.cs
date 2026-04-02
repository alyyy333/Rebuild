using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public int score = 0;
    int maxPieces = 10;
    [SerializeField] TextMeshProUGUI piecesFoundText;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 1;
        piecesFoundText.text = "Pieces found: " + score + "/" + maxPieces;
    }
}
