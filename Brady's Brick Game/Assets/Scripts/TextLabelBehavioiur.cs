using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class TextLabelBehavioiur : MonoBehaviour
{
    
    private TextMeshProUGUI label;
    public UnityEvent startEvent;

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        startEvent.Invoke();
    }

    public void UpdateLabel(FloatSO obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
    

}
