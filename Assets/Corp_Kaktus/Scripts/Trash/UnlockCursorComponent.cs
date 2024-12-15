using UnityEngine;

namespace Corp_Kaktus.Scripts.Trash
{
    public class UnlockCursorComponent : MonoBehaviour
    {
        public void UnlockCursor() => Cursor.lockState = CursorLockMode.None;

    }
}