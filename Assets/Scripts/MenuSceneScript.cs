using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("DemoScene");
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
