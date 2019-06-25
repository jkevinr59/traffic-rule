using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultBoard : MonoBehaviour {

    public Sprite oneStarSprite;
    public Sprite twoStarSprite;
    public Sprite threeStarSprite;

    private Image spriteRenderer;
    // Use this for initialization
    void Start () {
        this.spriteRenderer = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showStar(int star) {
        this.spriteRenderer = gameObject.GetComponent<Image>();
        if (star == 1)
        {
            spriteRenderer.sprite = this.oneStarSprite;
        }

        else if (star == 2)
        {
            spriteRenderer.sprite = this.twoStarSprite;
        }
        else if (star == 3)
        {
            spriteRenderer.sprite = this.threeStarSprite;
        }
    }
}
