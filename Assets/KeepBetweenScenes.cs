using UnityEngine;
using System.Collections;

namespace roastedrooster.chickenrun.utils {
    public class KeepBetweenScenes : MonoBehaviour {

        void Start() {
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}

