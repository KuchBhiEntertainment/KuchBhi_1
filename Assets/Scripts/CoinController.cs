using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour 
{
    public int pointsToAdd = 50;
    bool got = false;
    float opacity = 1;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (got) return;
        if (other.gameObject.name == "Penguin")
        {
            audioSource.Play();
            ScoreController.AddPoints(pointsToAdd);
            got = true;
        }
    }
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, got ? 500*Time.deltaTime : 0);
        transform.Rotate(new Vector3(0,0,-50 * Time.deltaTime));
        var sprite = GetComponent<SpriteRenderer>();
        if (got)
        {
            opacity -= 0.95f * Time.deltaTime;
            if (opacity < 0)
            {
                Object.Destroy(gameObject);
                opacity = 0;
            }
        }
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, opacity);
    }
}
