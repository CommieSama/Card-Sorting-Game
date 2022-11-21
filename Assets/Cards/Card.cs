using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int suit;
    //suits are hearts = 0, spades = 1, diamonds = 2, clubs = 3
    public int value;
    public bool upRight;
    public bool faceUp;
    public Text valueDisplay;
    public Image suitDisplay;
    public Image cardBack;
    public string highsuit = "JQKA";


    public void CardDraw(int v, int s)
    {
        suit = s;
        value = v;
        upRight = Random.value > 0.5f;
        faceUp = Random.value > 0.5f;
        if (value > 10)
        {
            valueDisplay.text = highsuit[value - 11].ToString();
        }
        else
        {
            valueDisplay.text = value.ToString();
        }
        if(!faceUp)
        {
            this.gameObject.transform.GetChild(1).SetAsFirstSibling();
        }
    }

 /*   void Start()
    {
        
    }

 /*   public Card(int v, int s)
    {
        suit = s;
        value = v;
        upRight = Random.value > 0.5f;
        faceUp = Random.value > 0.5f;
    } */

    public void Flip()
    {
        faceUp = !faceUp;
        this.gameObject.transform.GetChild(1).SetAsFirstSibling();
    }

    public void Rotate()
    {
        upRight = !upRight;
    }

    public void Print()
    {
        Debug.Log("value is " + value + ". card is upright: " + upRight + ". card is face up: " + faceUp + ". suit is " + suit);
    }
}
