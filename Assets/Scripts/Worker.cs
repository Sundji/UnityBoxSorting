using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    private static readonly string _TAG_BOX = "Box";
    private static readonly string _TAG_CONTAINER = "Container";
    private static readonly string _TAG_WALL = "Wall";

    [SerializeField] private Vector2 _boxPositionWhileCarrying = Vector2.zero;
    [SerializeField] private float _walkingSpeed = 1.0f;

    private SpriteRenderer _spriteRenderer = null;
    private Rigidbody2D _rigidbody = null;

    private bool _isCarrying = false;
    private Box _carriedBox = null;
    private Dictionary<BoxColor, Vector2> _containerPositions = new Dictionary<BoxColor, Vector2>();
    private Vector2 _walkingDirection = Vector2.right;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = _walkingDirection * _walkingSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(_TAG_WALL)) ChangeWalkingDirection();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_isCarrying) return;

        if (collision.transform.CompareTag(_TAG_CONTAINER))
        {
            Container container = collision.transform.GetComponent<Container>();
            if (_carriedBox.BoxColor == container.ContainerColor)
            {
                _isCarrying = false;
                _carriedBox.DropBox();
                _carriedBox = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(_TAG_BOX))
        {
            if (_isCarrying) return;

            Box box = collision.transform.GetComponent<Box>();
            box.CarryBox(transform, _boxPositionWhileCarrying);
            _isCarrying = true;
            _carriedBox = box;

            if (_containerPositions.TryGetValue(box.BoxColor, out Vector2 containerPosition))
            {
                Vector2 containerDirection = transform.position.x > containerPosition.x ? Vector2.left : Vector2.right;
                if (_walkingDirection != containerDirection) ChangeWalkingDirection();
            }
        }

        if (collision.transform.CompareTag(_TAG_CONTAINER))
        {
            Container container = collision.transform.GetComponent<Container>();
            if (!_containerPositions.TryGetValue(container.ContainerColor, out Vector2 containerPosition)) _containerPositions.Add(container.ContainerColor, container.transform.position);
        }
    }

    private void ChangeWalkingDirection()
    {
        _rigidbody.velocity = Vector2.zero;
        _walkingDirection = _walkingDirection == Vector2.right ? Vector2.left : Vector2.right;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        _rigidbody.velocity = _walkingDirection * _walkingSpeed;
    }
}
