using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SPFailSceneManager : MonoBehaviour
{
    void Update()
    {
        int randomnumber = Random.Range(1, 6);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.name == "GoStage")
            {
                SceneManager.LoadScene("Stage");
            }
            if (hit.collider != null && hit.collider.gameObject.name == "GoMenu")
            {
                SceneManager.LoadScene("Start Scene");
            }
            if (hit.collider != null && hit.collider.gameObject.name == "Retry")
            {
                SceneManager.LoadScene("Story-InGame");
            }
            if (hit.collider != null && hit.collider.gameObject.name == "Random")
            {
                if (randomnumber == 1)
                {
                    SceneManager.LoadScene("Example Scene");
                }
                else if (randomnumber == 2)
                {
                    SceneManager.LoadScene("Design Scene");
                }
                else if (randomnumber == 3)
                {
                    SceneManager.LoadScene("1-1 Intro Scene");
                }
                else if (randomnumber == 4)
                {
                    SceneManager.LoadScene("Stage");
                }
                else if (randomnumber == 5)
                {
                    SceneManager.LoadScene("P1 Win");
                }
            }
        }
    }
}