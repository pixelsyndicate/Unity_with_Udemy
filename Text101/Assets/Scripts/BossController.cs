using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{

    public Text TextBox;

    public void Update()
    {
        
    }

    public void Start()
    {
        TextBox.text = @" c:\";
        TextBox.text += @"Begin Defrag";
        TextBox.text += "...";
    }
}
