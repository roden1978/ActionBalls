using UnityEngine;

namespace UI
{
    public abstract class Dialog : MonoBehaviour
    { 
        protected Canvas Base;
        protected void Hide()
       {
           Base.gameObject.SetActive(false);
       }
    }
}
