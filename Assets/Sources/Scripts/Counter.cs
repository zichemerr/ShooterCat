using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void ShowDisplay(int value)
    {
        _scoreText.text = value.ToString();
    }
}
