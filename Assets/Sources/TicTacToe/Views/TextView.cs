using TMPro;
using UnityEngine;

namespace TicTacToe.Views
{
    public class TextView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        public void ChangeText(string value)
            => _text.SetText(value);
    }
}