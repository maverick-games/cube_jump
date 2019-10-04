using UnityEngine;
using UnityEngine.UI;

public class CollectDiamonds : MonoBehaviour
{
    public Text counterDiamond;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 1);
            counterDiamond.text = PlayerPrefs.GetInt("Diamond").ToString();
        }
    }
}
