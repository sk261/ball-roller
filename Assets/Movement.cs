using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody sphere;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        sphere = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        sphere.AddForce(movement * speed);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 3)
        {
            winText.text = "You Win!";
        }
    }
}
