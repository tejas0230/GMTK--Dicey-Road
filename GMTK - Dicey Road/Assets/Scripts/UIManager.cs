using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public string[] instructions;

    public GameObject GameNamePanel;
    public GameObject InstructionsPanel;
    public Animator diceAnimator;
    public Animator InstructionsAnimator;
    public float StringChangetime;
    public TMP_Text instructionsText;

    public  static UIManager Instance;

    public int instructionIndex = 0;
    bool play = true;
    public bool spacePressed = false;
    public bool escapePressed = false;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    
    void Start()
    {
        diceAnimator.ResetTrigger("Space");
        spacePressed = false;
        escapePressed = false;
        
    }

    
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            
            GameNamePanel.SetActive(false);
            
        }
        else
        {
            GameNamePanel.SetActive(true);
            diceAnimator = GameObject.FindGameObjectWithTag("DicePlaceHolder").GetComponent<Animator>();
            if (Input.GetKey(KeyCode.Space) && !spacePressed)
            {
                diceAnimator.SetTrigger("Space");
                spacePressed = true;
                escapePressed = false;
            }
        }


        if(SceneManager.GetActiveScene().name=="Level0")
        {
            InstructionsPanel.SetActive(true);
            
            if(play && instructionIndex<4)
            {
                play = false;
               StartCoroutine(showInstructions(instructionIndex));
            }
               
            
        }
        else
        {
            InstructionsPanel.SetActive(false);
        }

        if(Input.GetKey(KeyCode.Escape) && !escapePressed)
        {
            LevelLoader.instance.loadAnyLevel(1);
            escapePressed = true;
            
        }
        
    }


   public void changeScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    IEnumerator showInstructions(int i)
    {
        instructionsText.text = instructions[i];
        InstructionsAnimator.SetBool("PlayAnim",true);
        yield return new WaitForSeconds(5);
        InstructionsAnimator.SetBool("PlayAnim", false);
        play = true;
        instructionIndex += 1;
    }
}
