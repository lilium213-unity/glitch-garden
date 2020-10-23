using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    [field: SerializeField]
    public int StarsCount { get; private set; } = 50;

    TextMeshProUGUI starsText;

    // Start is called before the first frame update
    void Start()
    {
        starsText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starsText.text = StarsCount.ToString();
    }

    public void AddStars(int stars)
    {
        StarsCount += stars;
        UpdateDisplay();
    }

    public bool SpendStars(int stars)
    {
        if (StarsCount >= stars)
        {
            StarsCount -= stars;
            UpdateDisplay();
            return true;
        }
        else
            return false;
    }
}
