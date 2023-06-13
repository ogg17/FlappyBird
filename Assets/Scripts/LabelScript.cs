using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TMProLabelScript : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;
    void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string text)
    {
        
    }
}
