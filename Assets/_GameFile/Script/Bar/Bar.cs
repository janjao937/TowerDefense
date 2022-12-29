using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxBarValue(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }
    public void SetBarValue(int value) => slider.value = value;
    
}
