using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "Architecture/SceneConfig/New SceneConfig")]
    public class SceneConfig : ScriptableObject
    {
        [SerializeField, ClassReference(typeof(BaseManager))]
        private BaseManager managers;
    }
}
