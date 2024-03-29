﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBehaviour : MonoBehaviour
{
    protected bool _isPlaying;
    public virtual void Play() => _isPlaying = true;
    public virtual void Pause() => _isPlaying = false;

    protected abstract void EntityUpdate();

    protected virtual void Awake() => _isPlaying = false;

    private void FixedUpdate() => EntityUpdate();

}