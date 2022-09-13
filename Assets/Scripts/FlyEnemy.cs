using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScr>().CambiarSprite();
            collision.gameObject.GetComponent<PlayerScr>().enabled = false;
            Invoke("ReiniciarJuego", 2f);
            this.GetComponent<FlyEnemy>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (GameObject.Find("jugadorSprite").GetComponent<SpriteRenderer>().sprite.name == "JuegoPlataforma2DOjo - copia")
            return;

        if (this.transform.position.x < -13.0f)
            Destroy(gameObject);

        this.transform.Translate(Vector2.left * 0.12f);
    }

    private void ReiniciarJuego()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
