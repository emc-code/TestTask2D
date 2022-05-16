using UnityEngine;

[RequireComponent(typeof(PlayerCollider))]
public class Player : EntityBehaviour
{   
    [SerializeField] private GameObject Sprite;

    private Camera _camera;

    private PlayerCollider _playerCollider;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Init(Camera camera)
    {
        _camera = camera;
        _playerCollider = GetComponent<PlayerCollider>();
        _playerCollider.Init();
    }

    protected override void EntityUpdate()
    {
        if (_isPlaying)
        {
            if (Sprite.activeSelf == false)
                Sprite.SetActive(true);

            Move();
        }
        else
        {
            Sprite.SetActive(false);
        }
    }

    private void Move()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = _camera.ScreenToWorldPoint(screenPosition);

        transform.position = worldPosition;
    }
}