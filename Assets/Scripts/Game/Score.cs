using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text record;
    private Text _text;
    private bool _gameStart;

    void Start()
    {
        _text = GetComponent<Text>();
        record.text = "TOP: " + PlayerPrefs.GetInt("Record");
        CubeJump.countBlocks = 0;
    }

    void Update()
    {
        if (_text.text == "0") _gameStart = true;
        if (_gameStart)
        {
            _text.text = CubeJump.countBlocks.ToString();
            if (PlayerPrefs.GetInt("Record") < CubeJump.countBlocks)
            {
                record.text = "TOP: " + CubeJump.countBlocks;
                PlayerPrefs.SetInt("Record", CubeJump.countBlocks);
            }
        }
    }
}
