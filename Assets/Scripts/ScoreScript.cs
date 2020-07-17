using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public float Score;
    public float HiScore;
    public Text ScoreText;
    public Text HiText;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Score>HiScore){
            HiScore = Score;
        }
        ScoreText.text = Score.ToString();
        HiText.text = HiScore.ToString();
        int childs = transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }
}
