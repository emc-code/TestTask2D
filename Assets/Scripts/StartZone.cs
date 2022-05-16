using System;
using UnityEngine;

public class StartZone : MonoBehaviour
{
    [SerializeField] private Camera Camera;

    private void OnValidate()
    {
        if (Camera == null)
            throw new ArgumentNullException(nameof(Camera));
    }

    private void Update() => UpdatePosition();

    public void UpdatePosition()
    {
        Vector2 min = Camera.ViewportToWorldPoint(new Vector2(0, 0));
        transform.position = min + Vector2.one * 0.7f;
        // transform.position = min - Vector2.up * 2.7f;
    }
}