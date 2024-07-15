using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGameScript : MonoBehaviour
{
    public Text gameTitle;
    public Button startButton;
    public Image fadeImage; // Thêm biến này
    public float fadeInDuration = 2f;
    public float fadeOutDuration = 2f;
    public float waitBeforeFadeOut = 1f;

    void Start()
    {
        // Ẩn nút start khi bắt đầu
        startButton.gameObject.SetActive(false);
        startButton.interactable = false;

        // Đảm bảo gameTitle bắt đầu với alpha là 0
        Color titleColor = gameTitle.color;
        titleColor.a = 0;
        gameTitle.color = titleColor;

        // Bắt đầu coroutine để hiện dần màn hình
        StartCoroutine(ShowTitleThenButton());
    }

    IEnumerator ShowTitleThenButton()
    {
        // Hiện từ từ toàn bộ scene từ bóng tối
        yield return StartCoroutine(FadeOut(fadeImage, fadeInDuration));

        // Hiện từ từ tên game
        yield return StartCoroutine(FadeIn(gameTitle, fadeInDuration));

        // Đợi một chút trước khi ẩn tên game
        yield return new WaitForSeconds(waitBeforeFadeOut);

        // Ẩn từ từ tên game
        yield return StartCoroutine(FadeOut(gameTitle, fadeOutDuration));

        // Hiện từ từ nút start
        startButton.gameObject.SetActive(true);
        yield return StartCoroutine(FadeIn(startButton.image, fadeInDuration));
        startButton.interactable = true;
    }

    IEnumerator FadeIn(Graphic graphic, float duration)
    {
        Color color = graphic.color;
        color.a = 0;
        graphic.color = color;

        float timer = 0;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Clamp01(timer / duration);
            graphic.color = color;
            yield return null;
        }
    }

    IEnumerator FadeOut(Graphic graphic, float duration)
    {
        Color color = graphic.color;
        color.a = 1;
        graphic.color = color;

        float timer = 0;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Clamp01(1 - (timer / duration));
            graphic.color = color;
            yield return null;
        }
    }

    public void StartGame()
    {
       
        // Tải Scene chính của game khi nhấn nút start
        SceneManager.LoadScene("MainGameScene");
        var color = startButton.GetComponentInChildren<Text>().color;
        color.a = 0;
        startButton.GetComponentInChildren<Text>().color = color;
        startButton.interactable = false;

    }
}
