using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxBarValue(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }
    public void SetBarValue(float value) => slider.value = value;
    
}
