using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
public class CircleHit : MonoBehaviour
{
    [SerializeField] private PlayerCollider _barrier;
    private CircleSpeed _circleSpeed;
    private CircleNavigator _circleNavigator;
    private CircleCollider2D _circleCollider;

    private float _radius = 0.5f;
    private bool _hasContactPlayer;

    private bool CheckContact => Vector3.Distance(_barrier.transform.position, transform.position) <= _radius + _barrier.Radius;

    private void Awake()
    {
        _circleSpeed = GetComponent<CircleSpeed>();
        _circleNavigator = GetComponent<CircleNavigator>();
        _circleCollider = GetComponent<CircleCollider2D>();


        _hasContactPlayer = CheckContact;

        _circleCollider.radius = _radius;
    }

    private void FixedUpdate()
    {
        bool value = CheckContact;
        if (value != _hasContactPlayer)
        {
            _hasContactPlayer = value;

            if (_hasContactPlayer)
                PlayerCollisionEnter();
            else
                PlayerCollisionExit();
        }
    }

    private void PlayerCollisionEnter()
    {
        _circleSpeed.SetEscapeMode(true);
    }

    private void PlayerCollisionExit()
    {
        _circleSpeed.SetEscapeMode(false);
    }
}