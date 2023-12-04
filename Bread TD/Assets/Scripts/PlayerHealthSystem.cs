using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PlayerHealthSystem : MonoBehaviour
{
    public int Health = 3;

    public List<GameObject> Hearts;

    public Sprite FullHeart;
    public Sprite NoHeart;

    [SerializeField]
    private GameManager manger;

    // Start is called before the first frame update
    void Start()
    {
        manger = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreadDie()
    { 
    }

    public void LoseHelth()
    {
        foreach (GameObject heart in Hearts)
        {
            if (heart.GetComponent<Image>().sprite == FullHeart)
            {
                heart.GetComponent<Image>().sprite = NoHeart;
                return;
            }
        }
    }
}
