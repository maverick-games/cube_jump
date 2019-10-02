using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "restart":
                SceneManager.LoadScene("main");
                break;
            case "facebook":
                Application.OpenURL("https://facebook.com");
                break;
        }
    }
}
