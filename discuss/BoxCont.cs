using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoxCont : MonoBehaviour
{
    public bool boxget = false;
    public int boxgetcheack = 0;
    public int boxNuber = 0;
    public string boxtext = "";
    public string Opentext = "";
    
    public Text text;
    public int Whatget = 0;
    //Whatgetが1ならカギ、2なら矢を得る
    public Sprite OpenImage;
    public bool isOpen = false;
    //public GameObject boxwindow ;
    //public GameObject yeswindow;
    //public GameObject nowindow;
    [Multiline]
    public string SelectText = "";
    //private bool IsMessage = false;
    // Start is called before the first frame update
    void Start()
    {
        //boxwindow.SetActive(false);
        //yeswindow.SetActive(false);
        //nowindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void FixedUpdate()
	{
        if (boxgetcheack == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
			{
                            
                
                
                if (isOpen == false)
				{
                    winMane.textMain = boxtext;
                    SelectMane.textSelect = SelectText;


                }
                else
				{
                    winMane.textMain = Opentext;
                }
                winMane.windowOn = 1;
                if (isOpen == false)
				{
                    if (winMane.IsSelectWin ==0)
					{
                        winMane.IsSelectWin = 1;
                    }
                    
                    if (SelectMane.SelectResult == 1)
					{
                        if (Whatget == 1)
                        {
                            ItemKeeper.haskeys++;
                        }
                        else if (Whatget == 2)
                        {
                            ItemKeeper.hasArrows++;
                        }
                        isOpen = true;
                        GetComponent<SpriteRenderer>().sprite = OpenImage;
                        boxgetcheack = 2;
                    }
                    else if (SelectMane.SelectResult ==2)
					{
                        boxgetcheack = 2;
                    }
                    



                }



            }


        }
        else if (boxgetcheack == 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                winMane.windowOut = 1;

                //boxwindow.SetActive(false);
                //PlayController.gameState = "playing";
                boxgetcheack = 0;
            }
            
        }
    }
	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boxget = true;
            boxgetcheack = 1;
        }
    }
	private void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
            boxget = false;
            boxgetcheack = 0;
        }
	}
}
