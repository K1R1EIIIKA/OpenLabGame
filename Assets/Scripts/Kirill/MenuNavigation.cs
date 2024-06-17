using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kirill
{
    public class MenuNavigation : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void LoadMainMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }
        
        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}