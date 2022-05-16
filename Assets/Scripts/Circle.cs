using UnityEngine;

public class Circle : EntityBehaviour
{
    private CircleMovement _circleMovement;
    private CircleSpeed _circleSpeed;
    private CircleNavigator _circleNavigator;

    private void Awake()
    {
        _circleMovement = GetComponent<CircleMovement>();
        _circleSpeed = GetComponent<CircleSpeed>();
        _circleNavigator = GetComponent<CircleNavigator>();
    }

    public void Init(Transform startZone, Transform finishZone)
    {
        transform.position = startZone.position;

        _circleNavigator.Init(finishZone);
    }

    public override void Play()
    {
        base.Play();
        _circleMovement?.StartMovement();
    }

    public override void Pause()
    {
        base.Pause();
        _circleMovement?.StopMovement();
    }

    protected override void EntityUpdate()
    {
        _circleMovement.TryMove();
    }
}
