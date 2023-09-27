using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
}