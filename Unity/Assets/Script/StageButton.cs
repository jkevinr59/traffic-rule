using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour {
    public int stage;
    public int level;
    public Sprite disabledSprite;
    public Sprite noStarSprite;
    public Sprite oneStarSprite;
    public Sprite twoStarSprite;
    public Sprite threeStarSprite;
    private Image spriteRenderer;
    // Use this for initialization
    void Start () {
        GameObject gameControl = GameObject.FindGameObjectWithTag("GameController");
        SaveDataController saveController = gameControl.GetComponent<SaveDataController>();
        int currentStar = saveController.GetStar(this.stage, this.level);
        this.showStar(currentStar);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showStar(int star)
    {
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
        else if (star == 0)
        {
            spriteRenderer.sprite = this.noStarSprite;
        }
    }
}
