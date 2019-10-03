using UnityEngine;
using UnityEngine.UI;

public class CountDiamonds : MonoBehaviour
{
    private Text _text;

    void Start()
    {
        _text.GetComponent<Text>();
        _text.text = PlayerPrefs.GetInt("Diamonds").ToString();
    }
}
