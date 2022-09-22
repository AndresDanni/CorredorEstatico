using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    private Rigidbody2D myBody;

    float tiempoDisparo = 0f;

    bool dobleSalto = false;
    public bool gameOver = false;

    private AudioSource Musica;

    public Sprite PlayerNormal;
    public Sprite PlayerGetDown;
    public Sprite PlayerDead;

    public GameObject Bala;


    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Musica = GetComponent<AudioSource>();
        Musica.Play();
        gameOver = false;
    }


    void FixedUpdate()
    {
        if (Input.GetKey("r") && gameOver)
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        if (gameOver)
            return;

        if (Input.GetKey("w") && Mathf.Abs(myBody.velocity.y) < 0.001f)
        {
            myBody.AddForce(Vector2.up * 9.0f, ForceMode2D.Impulse);
            dobleSalto = true;
        }

        if (Input.GetKey("w") && dobleSalto && Mathf.Abs(myBody.velocity.y) > 0.001f && myBody.velocity.y < 0)
        {
            dobleSalto = false;
            myBody.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
        }
        
        this.GetComponent<Animator>().SetBool("enSuelo", Mathf.Abs(myBody.velocity.y) < 0.001f);

        if (Input.GetKey("s") && Mathf.Abs(myBody.velocity.y) > 0.001f)
        {
            myBody.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
        }

        if (Input.GetKey("s") && Mathf.Abs(myBody.velocity.y) < 0.001f)
        {
            GetComponents<BoxCollider2D>()[1].enabled = true;
            GetComponents<BoxCollider2D>()[0].enabled = false;
            GetComponent<SpriteRenderer>().sprite = PlayerGetDown;
        }
        else
        {
            GetComponents<BoxCollider2D>()[0].enabled = true;
            GetComponents<BoxCollider2D>()[1].enabled = false;
            GetComponent<SpriteRenderer>().sprite = PlayerNormal;
        }

        if (Input.GetKey("e") && Time.time > tiempoDisparo + 0.5f)
        {
            Instantiate(Bala, gameObject.transform.position, Quaternion.identity);
            tiempoDisparo = Time.time;
        }
    }
    /*
    public void CambiarSprite()
    {
        GameObject.Find("Bloque1").GetComponent<Animator>().enabled = false;
        Musica.Stop();
        GetComponent<SpriteRenderer>().sprite = PlayerDead;
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Fly"))
        {
            gameOver = true;
            Musica.Stop();
            GetComponent<SpriteRenderer>().sprite = PlayerDead;
            this.GetComponent<Animator>().SetBool("enSuelo", true);
        }
    }
}
