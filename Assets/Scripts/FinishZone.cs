using System;
using UnityEngine;

public class FinishZone : MonoBehaviour
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
        Vector2 max = Camera.ViewportToWorldPoint(new Vector2(1, 1));
        transform.position = max - Vector2.one * 0.5f;
    }
}
