using TMPro;
using UnityEngine;


//Just wanted to do this script
public class HintUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hintText;
    
    private PlayerInput _input;

    private void OnEnable()
    {
        _input = FindObjectOfType<PlayerInput>();

        UpdateHintUI();
    }

    private void UpdateHintUI()
    {
        _hintText.SetText($"'{_input.KeycodeRotateLeft}{_input.KeycodeRotateRight}' to rotate \n'{_input.KeycodeMove}' to move \n'{_input.KeycodeShoot}' to shoot \n'{_input.KeycodeWarp}' to warp");
    }
}
