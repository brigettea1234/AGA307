using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager> 
{
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public TMP_Text targetCountText;
    public TMP_Text difficultyText;
    public TMP_Text weaponSelectedText;
    public TMP_Text projectileText;

    private void Start()
    {
        UpdateScore(0);         //Defaults to 0 on start
        //UpdateTime(0);
        //UpdateTargetCount(0);
        UpdateDifficulty(_GM.difficulty.ToString());
        UpdateWeapon(_GM.weapon.ToString());
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score.ToString();
    }

    public void UpdateTargetCount(int _count)
    {
        targetCountText.text = "Target Count: " + _count.ToString();
    }

    public void UpdateDifficulty(string _difficulty)
    {
        difficultyText.text = "Difficulty: " + _difficulty;
    }

    public void UpdateWeapon(string _weapon)
    {
        weaponSelectedText.text = "Weapon Selected: " + _weapon;
    }

    public void UpdateProjectile(int _projectile)
    {

    }

    //public int GenerateRandomNumber()
    //{
    //    int rnd = Random.Range(0, 5);
    //    return rnd;
    //}

     /*public void UpdateTime(float _time)
    {
        //Convert the float to a string
        //timeText.text = _time.ToString("F2"); //F stands for float + 2 decimals
        //0:00 for the minutes, 1:00 for the seconds
        //timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }*/
}
