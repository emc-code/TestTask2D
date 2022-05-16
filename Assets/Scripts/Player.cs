using UnityEngine;

public class Player : EntityBehaviour
{
    [SerializeField] private Camera _camera;

    private void OnValidate()
    {
        if (_camera == null)
            throw new System.ArgumentNullException(nameof(_camera));
    }

    protected override void EntityUpdate()
    {
        if (_isPlaying)
            Move();
    }

    private void Move()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = _camera.ScreenToWorldPoint(screenPosition);

        transform.position = worldPosition;
    }
}