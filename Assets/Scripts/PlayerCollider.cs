﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CircleCollider2D))]
public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    [SerializeField] private Transform Sprite;

    private CircleCollider2D _circleCollider;
    private float _radius;

    public float Radius => _radius;

    public void Init()
    {
        _circleCollider = GetComponent<CircleCollider2D>();

        SetRadius(Slider.value);
        Slider.onValueChanged.AddListener(SetRadius);
    }

    private void SetRadius(float value)
    {
        if (value < 0)
            throw new System.ArgumentOutOfRangeException(nameof(value));

        _radius = value;
        Sprite.localScale = new Vector3(_radius * 2, _radius * 2, 1);
        _circleCollider.radius = _radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerEnter(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnPlayerEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out CircleSpeed circleSpeed))
            circleSpeed.SetEscapeMode(false);
    }

    private void OnPlayerEnter(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ICircleNavigator circleNavigator))
        {         
            EscapePolicy escapePolicy = new EscapePolicy(transform, collision.transform);
            circleNavigator.AddMovePolicy(escapePolicy);
            collision.gameObject.GetComponent<CircleSpeed>().SetEscapeMode(true);
        }
    }
}