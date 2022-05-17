using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private Circle Circle;
    [SerializeField] private Player Player;
    [SerializeField] private FinishZone FinishZone;
    [SerializeField] private StartZone StartZone;

    private void OnValidate()
    {
        if ((Circle == null) || (Player == null) || (FinishZone == null) || (StartZone == null))
            throw new ArgumentNullException();
    }

    private void Awake()
    {
        Play();
    }

    public void Play()
    {
        StartZone.UpdatePosition();
        FinishZone.UpdatePosition();

        Circle.Init(StartZone.transform, FinishZone.transform);
        Player.Init(Camera);

        Circle.Play();
        Player.Play();
    }

    public void Pause()
    {
        Circle.Pause();
        Player.Pause();
    }
}