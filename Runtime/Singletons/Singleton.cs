using UnityEngine;

namespace DPG_Unity_Common.Runtime.Singletons
{
    /// <summary>
    ///     Abstract class for a singleton.
    /// </summary>
    /// <typeparam name="TComponent">The generic type (of type component) to be the derived singleton.</typeparam>
    /// <example>
    ///     An example of how to use this class.
    /// <code language="C#">
    ///     public class ExampleSingletonClass : Singleton&lt;ExampleSingletonClass&gt;
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
        ///     Instance of the singleton
        /// </summary>
        public static TComponent Instance { get; private set; }

        protected virtual void Awake()
        {
            // Singleton pattern logic
            if (Instance is not null && Instance != this as TComponent)
            {
                Destroy(this);
            }
            else
            {
                Instance = this as TComponent;
            }
        }
    }
}