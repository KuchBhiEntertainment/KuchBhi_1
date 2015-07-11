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
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, got ? 2 : 0);
        transform.Rotate(new Vector3(0,50 * Time.deltaTime,0));
        var sprite = GetComponent<SpriteRenderer>();
        if (got)
        {
            opacity -= 0.5f * Time.deltaTime;
            if (opacity < 0)
            {
                Object.Destroy(gameObject);
                opacity = 0;
            }
        }
        sprite.color = new Color(1, 0, 0, opacity);
    }
}
