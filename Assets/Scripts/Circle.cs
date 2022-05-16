using UnityEngine;

[RequireComponent(typeof(CircleMovement))]
[RequireComponent(typeof(CircleSpeed))]
[RequireComponent(typeof(CircleNavigator))]
public class Circle : EntityBehaviour
{
    private CircleMovement _circleMovement;
    private CircleSpeed _circleSpeed;
    private CircleNavigator _circleNavigator;

    protected override void Awake()
    {
        base.Awake();

        _circleMovement = GetComponent<CircleMovement>();
        _circleSpeed = GetComponent<CircleSpeed>();
        _circleNavigator = GetComponent<CircleNavigator>();
    }

    public void Init(Transform startZone, Transform finishZone)
    {
        _circleSpeed.Init();
        _circleNavigator.Init(finishZone);
        _circleMovement.Init(_circleSpeed, _circleNavigator, startZone);
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
