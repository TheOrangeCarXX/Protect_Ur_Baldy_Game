using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Maps() 
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Main_Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Map_1(){
        SceneManager.LoadSceneAsync(2);
    }
    public void Map_2(){
        SceneManager.LoadSceneAsync(3);
    }
    public void Map_3(){
        SceneManager.LoadSceneAsync(4);
    }
    public void Map_4(){
        SceneManager.LoadSceneAsync(5);
    }
    public void Map_5(){
        SceneManager.LoadSceneAsync(6);
    }
    public void Map_6(){
        SceneManager.LoadSceneAsync(7);
    }
}
