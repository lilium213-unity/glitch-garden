using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDefenderButton : MonoBehaviour
{
    [SerializeField] Color unselectedColor;
    [SerializeField] Defender defender;

    private void OnMouseDown()
    {
        Highlight();
        FindObjectOfType<DefenderSpawner>().SetDefender(defender);
    }

    private void Highlight()
    {
        var buttons = FindObjectsOfType<UIDefenderButton>();
        foreach (var button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = unselectedColor;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
