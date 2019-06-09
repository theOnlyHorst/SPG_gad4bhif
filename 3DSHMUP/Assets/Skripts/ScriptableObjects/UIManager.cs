using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "3DSHMUP/UIManager")]
public class UIManager : ScriptableObject
{

    public Text healthtxt;
   
    public Text scoretxt;


    public Text scoreFinTxt;

    public Text healthFinTxt;

    public Text scoreTotalTxt;

    public Text endStateTxt;
    private static UIManager m_instance;
        public static UIManager Instance{
        get{return m_instance;}
        }
    
    private void OnEnable() {
        if(m_instance == null)
            m_instance = this;
        else
            Debug.LogError("There may only be one UIManager!");
    }
    

    public void displayHealth(int health)
    {
        healthtxt.text = health.ToString();
    }

    public void displayScore(int score)
    {
        scoretxt.text = score.ToString();
    }

    public void displayResults(int score, int health,int healthBonus,int total,bool won)
    {
        endStateTxt.text = won?"YOU WON!":"GAME OVER";
        scoreFinTxt.text = score.ToString();
        healthFinTxt.text = (health*healthBonus).ToString()+" ("+health.ToString()+"x"+healthBonus.ToString()+")";
        scoreTotalTxt.text = total.ToString();
    }
}
