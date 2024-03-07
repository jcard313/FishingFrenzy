using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerScore : MonoBehaviour
{
    public TextMeshProUGUI depthText; //text that dislays depth


    void Update()
    {
        float depth = Time.time * speedMultiplier.Instance.speedMult; //how I calculate the depth (time * speedMultiplier)
        depthText.text = "Depth: " + Mathf.RoundToInt(depth).ToString() + "m"; //prints the depth
    }
}
