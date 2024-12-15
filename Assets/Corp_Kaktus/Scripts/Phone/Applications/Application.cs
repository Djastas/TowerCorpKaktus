using Tower.Runtime.Core.Phone;
using UnityEngine;

public abstract class Application : MonoBehaviour
{
   protected PhoneController _phoneController;
   public abstract void Open();
   public abstract void Close();
}
