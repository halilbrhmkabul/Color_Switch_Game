using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorPurple;
    public Color colorPink;
    public EdgeCollider2D edgeCr;

    public Text playText, starText;
    public int starScore;

    void Start()
    {
        SetRandomColor();
        Time.timeScale = 0;
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButton(0))
        {
            playText.gameObject.SetActive(false);
            Time.timeScale = 1;
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag =="star")
        {
            starScore += 1;
            starText.text = starScore.ToString();
            Destroy(col.gameObject);
            return;
        }


        if(col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        if(col.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter2D(EdgeCollider2D edCol)
    {
        if(edCol.tag == "colTouch")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0,4);

        switch(index)
        {
            case 0:
                currentColor = "cyan";
                sr.color = colorCyan;
                break;
            
            case 1:
                currentColor = "yellow";
                sr.color = colorYellow;
                break;

            case 2:
                currentColor = "purple";
                sr.color = colorPurple;
                break;
            
            case 3:
                currentColor = "pink";
                sr.color = colorPink;
                break;
                
        }
    }
}
