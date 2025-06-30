using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager MyUIManager;

    public GameObject Character;
    public GameObject CamObj;
    
    const float CharacterSpeed = 3f;

    public int NowScore = 0;

    void Awake()
    {
        MyUIManager.DisplayScore(NowScore);
        MyUIManager.DisplayMessage("", 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    // For smooth cam moving, it's good to use LateUpdate.
    void LateUpdate()
    {
        MoveCam();
    }

    void MoveCam()
    {
        // CamObj는 Character의 x, y position을 따라간다.
        Vector3 characterPos = Character.transform.position;
        CamObj.transform.position = new Vector3(characterPos.x, characterPos.y, CamObj.transform.position.z);
    }

    void MoveCharacter()
    {
        // Character는 초당 CharacterSpeed의 속도로 우측으로 움직인다.
        Character.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * CharacterSpeed;
    }

    public void GameOver()
    {
        // Character를 삭제하고, "Game Over!"라는 메시지를 3초간 띄우고, RestartButton을 활성화한다.
        Destroy(Character);
        MyUIManager.BroadcastMessage("Game Over!", 3);
        MyUIManager.RestartButton.SetActive(true);
    }

    public void GetPoint(int point)
    {
        // point만큼 점수를 증가시키고 UI에 표시한다.
        NowScore += point;
        MyUIManager.DisplayScore(NowScore);
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
