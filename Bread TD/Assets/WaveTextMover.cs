using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveTextMover : MonoBehaviour
{
    public float speed;

    public GameObject text;

    public GameObject canvas;

    //nodes are starting, stoping and end points for the moving text
    public GameObject[] PositionNodes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WaveAlert(int WaveNum)
    {
        //create Alert Text at startpoint and set values
        GameObject WaveAlert = Instantiate(text, transform.position ,Quaternion.identity);
        WaveAlert.transform.SetParent(canvas.transform);
        TextMeshProUGUI waveTextComponent = WaveAlert.GetComponentInChildren<TextMeshProUGUI>();

        if(waveTextComponent != null )
        {
            WaveAlert.GetComponentInChildren<RectTransform>().localScale = new Vector3(1,1,1);
            WaveAlert.GetComponent<WaveText>().Initialize(speed, PositionNodes);
            WaveAlert.GetComponentInChildren<TextMeshProUGUI>().text = new string("Wave " + WaveNum + " Starting");
        }
    }
}
