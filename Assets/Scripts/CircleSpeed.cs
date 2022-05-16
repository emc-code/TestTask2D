using UnityEngine;
using UnityEngine.UI;

public class CircleSpeed : MonoBehaviour
{
    [SerializeField] private float StartValue;
    [SerializeField] private float MaxValue;
    [SerializeField] private Slider Slider;

    private float _value;
    private float _acceleration;
    private bool _escapeMode;

    private void Reset() => _value = Mathf.Clamp(_value, _value, MaxValue);

    public void Init()
    {
        _escapeMode = false;
        _value = StartValue;

        Slider.onValueChanged.AddListener(SetAcceleration);
        SetAcceleration(Slider.value);
    }

    public void SetEscapeMode(bool value)
    {
        if (value == false)
            Reset();

        _escapeMode = value;
    }

    public float GetValue()
    {
        if ((_value < MaxValue) || (_escapeMode == true))
            SpeedUp();

        return _value;
    }
    
    private void SpeedUp()
    {
        _value += _acceleration * Time.deltaTime;

        if (_escapeMode == false)
            if (MaxValue < _value)
                _value = MaxValue;
    }

    private void SetAcceleration(float value)
    {
        if (value < 0)
            throw new System.ArgumentOutOfRangeException(nameof(value));

        _acceleration = value;
    }
}
