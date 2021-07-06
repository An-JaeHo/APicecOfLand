using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    PlayerInfo player;

    [SerializeField]
    Image prgressBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    private void Start()
    {
        StartCoroutine(LoadSceneProgress());
        player = GameObject.FindGameObjectWithTag("GameManger").GetComponent<PlayerInfo>();
        player.StartGame();
    }

    IEnumerator LoadSceneProgress()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                prgressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.deltaTime;
                prgressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (prgressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
