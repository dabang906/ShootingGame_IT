using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    // 현재 점수
    private int currentScore;
    // 최고 점수 UI
    public Text bestScoreUI;
    // 최고 점수
    private int bestScore;
    // currentScore 에 값을 넣고 화면에 표시하기
    public void SetScore(int value)
    {
        // 3.ScoreManager 클래스의 속성에 값을 할당 한다.
        currentScore = value;
        // 4.화면에 현재 점수 표시하기
        currentScoreUI.text = "현재점수 : " + currentScore;
        //목표: 최고 점수를 표시하고 싶다.
        //1.현재 점수가 최고 점수 보다 크니까
        //  -> 만약 현재 점수가 최고 점수를 초과 하였다면”
        if (currentScore > bestScore)
        {
            //2.최고 점수가 갱신 시킨다.
            bestScore = currentScore;
            //3.최고 점수 UI 에 표시
            bestScoreUI.text = "최고점수 : " + bestScore;
            // 목표 : 최고점수를 저장하고싶다.
            PlayerPrefs.SetInt("Best Score", bestScore);
        }

    }
    // currentScore 값 가져오기
    public int GetScore()
    {
        return currentScore;
    }

    void Start()
    {
        // 순서 : 1. 최고점수 불러와서 bestScore 에 넣어주기
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        //        2. 최고점수 화면에 표시하기
        bestScoreUI.text = "최고점수 : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
