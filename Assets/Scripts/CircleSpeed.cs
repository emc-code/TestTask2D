using UnityEngine;
using UnityEngine.UI;

public class CircleSpeed : EntityBehaviour
{
    public float Value => _value;

    [SerializeField] private float StartSpeed;
    [SerializeField] private float TargetSpeed;
    [SerializeField] private Slider Slider;

    private bool _escapeMode = false;
    private float _value;
    private float _acceleration;

    private void Reset() => _value = Mathf.Clamp(_value, _value, TargetSpeed);

    public void Init()
    {
        _value = StartSpeed;
        Slider.onValueChanged.AddListener(SetAcceleration);
        SetAcceleration(Slider.value);
    }

    public void SetEscapeMode(bool escapeMode)
    {
        if (escapeMode == false)
            Reset();

        _escapeMode = escapeMode;
    }

    protected override void EntityUpdate()
    {
        if ((_value < TargetSpeed) || (_escapeMode == true))
            SpeedUp();
    }

    public void SpeedUp()
    {
        _value += _acceleration * Time.deltaTime;

        if (_escapeMode == false)
            if (TargetSpeed < _value)
                _value = Mathf.Clamp(_value, _value, TargetSpeed);
    }

    private void SetAcceleration(float value)
    {
        if (value < 0)
            throw new System.ArgumentOutOfRangeException(nameof(value));

        _acceleration = value;
    }
}
