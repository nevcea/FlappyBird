using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    private void Start() => InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);

    private void OnEnable() => ResetPosition();

    private void Update()
    {
        HandleInput();
        ApplyGravity();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Jump();
        }
    }

    private void Jump()
    {
        direction = Vector3.up * strength;
        SoundManager.Instance.PlayWing();
    }

    private void ApplyGravity()
    {
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex = (spriteIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void ResetPosition()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
        else if (collision.CompareTag("Scoring"))
        {
            GameManager.Instance.IncreaseScore();
        }
    }
}