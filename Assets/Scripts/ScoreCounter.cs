using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public int score = 0;
    [SerializeField] int maxPieces = 10;
    [SerializeField] TextMeshProUGUI piecesFoundText;
    [SerializeField] GameObject greenBar;

    RectTransform barRectTransform;

    float xBarPos;
    float xBarScale;

    void Start()
    {
        barRectTransform = greenBar.GetComponent<RectTransform>();
        barRectTransform.anchoredPosition = new Vector2(xBarPos, barRectTransform.anchoredPosition.y);
        barRectTransform.sizeDelta = new Vector2(xBarScale, barRectTransform.sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 1;
        piecesFoundText.text = "Pieces found: " + score + "/" + maxPieces;
        xBarPos = (200 * score / maxPieces) - 200;
        xBarScale = 400 * score / maxPieces;
        barRectTransform.anchoredPosition = new Vector2(xBarPos, barRectTransform.anchoredPosition.y);
        barRectTransform.sizeDelta = new Vector2(xBarScale, barRectTransform.sizeDelta.y);
    }
}
