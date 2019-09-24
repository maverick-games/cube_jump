using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    private SpriteRenderer star;
    private float movementSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        star = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        star.color = new Color(star.color.r, star.color.g, star.color.g, Mathf.PingPong(Time.time / 2.5f, 1.0f));
        transform.position += transform.up * Time.deltaTime * movementSpeed;
    }
}
