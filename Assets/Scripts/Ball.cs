using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200.0f;
    private Vector2 _direction;
    public Rigidbody2D _rigidBody { get; private set; }

    private void Start()
    {
        Invoke(nameof(AddStartingForce), 1f);
    }
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = -1f;

        Vector2 direction = new Vector2(x, y);
        _rigidBody.AddForce(direction.normalized * this.speed);
    }
}
