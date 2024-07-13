using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Event
{
    public class CGameEventListener : MonoBehaviour
    {
        /*  // Start is called before the first frame update
          #region Private properties

          #endregion

          #region Private properties
        */

        [SerializeField]
        private CGameEventScriptable _event;

        [SerializeField]
        private UnityEvent _respose;

        // #region Main methods

        //private void OnEnable() => _event?.
        // #endregion

        private void OnEnable() => _event?.RegisterLister(this);

        private void OnDisable() => _event?.UnreagisterLister(this);

        public void OnEventRaise() => _respose?.Invoke();

    }
}
