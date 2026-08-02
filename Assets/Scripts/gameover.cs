using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
    
{
    [SerializeField] private GameObject pausemenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void pausebutton()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0;
    }
}
