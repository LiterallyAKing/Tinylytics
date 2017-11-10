using System;
using UnityEngine;

namespace BRAND_Analytics {
    [Serializable]
    public abstract class TrackableProperty
    {
        [SerializeField]
        protected UnityEngine.Object m_Target;
        [SerializeField]
        protected string m_Path;
    }
}
