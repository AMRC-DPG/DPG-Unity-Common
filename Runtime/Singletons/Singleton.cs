using UnityEngine;

namespace DPG_Unity_Common.Runtime.Singletons
{
    /// <summary>
    ///     Abstract class for the Singleton Pattern.
    /// </summary>
    /// <typeparam name="TComponent">The generic type (of type component) to have the Singleton pattern.</typeparam>
    /// <example>
    ///     An example of how to utilise this class.
    /// <code language="C#">
    ///     public class Sounds : Singleton&lt;Sounds&gt;
    ///     {
    ///         protected override void Awake()
    ///         {
    ///             // Custom code
    ///             base.Awake();
    ///         }
    ///
    ///         private void Start()
    ///         {
    ///             throw new NotImplementedException();
    ///         }
    ///
    ///         private void Update()
    ///         {
    ///             throw new NotImplementedException();
    ///         }
    ///     }
    /// </code>
    /// </example>
    public abstract class Singleton<TComponent> : MonoBehaviour
        where TComponent : Component
    {
        /// <summary>
        ///     Boolean for if the script is destroyable on load or not.
        /// </summary>
        [SerializeField] [Tooltip("Boolean for if the script is destroyable on load or not.")]
        private bool dontDestroyOnLoad;

        /// <summary>
        ///     Instance of the singleton
        /// </summary>
        public static TComponent Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance is not null && Instance != this as TComponent)
            {
                Destroy(this);
            }
            else
            {
                Instance = this as TComponent;

                if (dontDestroyOnLoad) DontDestroyOnLoad(this);
            }
        }
    }
}