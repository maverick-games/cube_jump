using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    private Text _text;
    private Outline _outLine;

    private void Start()
    {
        _text = GetComponent<Text>();
        _outLine = GetComponent<Outline>();
    }

    private void Update()
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, Mathf.PingPong(Time.time / 2.5f, 1.0f));
        _outLine.effectColor = new Color(_outLine.effectColor.r, _outLine.effectColor.g, _outLine.effectColor.b,
            _text.color.a + 0.2f);
    }
}
