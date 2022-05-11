using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public float speed = 20.0f;
    private Vector2 _direction;
    private float maxAngle = 80.0f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        } else
        {
            _direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            _rigidBody.AddForce(_direction * this.speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = (GetComponent<BoxCollider2D>()).bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball._rigidBody.velocity);
            float bounceAngle = (offset / width) * maxAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxAngle, maxAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball._rigidBody.velocity = rotation * Vector2.up * ball._rigidBody.velocity.magnitude;
        }
    }

}
