using UnityEngine;

public class Instructions_Cross : MonoBehaviour
{
    public GameObject instr_menu;
    public void Back() {
        instr_menu.SetActive(false);
    }
    public void Instruction_Open() {
        instr_menu.SetActive(true);
    }
}
