using UnityEngine;

namespace Dapasa.FSM
{
    /// <summary>
    /// Clase base para los estados de una máquina de estados finitos.<br/>
    /// Funciona como un <c>MonoBehaviour</c> normal, se puede usar su método
    /// <c>Update</c> para actualizar la lógica del juego.<br/>
    /// Para ejecutar código a la entrada o salida del estado, usar los
    /// métodos <see cref="EnterState"/> y/o <see cref="ExitState"/>
    /// </summary>
    /// <remarks>Debe extenderse para ser usada.</remarks>
    [RequireComponent(typeof(FSMMachine))]
    public abstract class FSMState : MonoBehaviour
    {
        [Tooltip("Nombre del estado. Si no es único, puede generar conflictos.")]
        [SerializeField]
        string stateName = "";

        [Tooltip("Indica si es el estado por defecto.")]
        [SerializeField]
        bool isDefaultState = false;

        /// <summary>
        /// Referencia a la máquina de estados que controla este estado.<br/>
        /// Puesto que <see cref="FSMMachine"/> es una clase abstracta, puede ser
        /// interesante convertirla al tipo concreto que la implemente.<br/>
        /// <example>Por ejemplo:
        /// <code>
        /// MaquinaEnemigo maquina = machine as MaquinaEnemigo;
        /// </code>
        /// Dónde MaquinaEnemigo extiende <see cref="FSMMachine"/>.
        /// </example>
        /// </summary>
        protected FSMMachine machine;

        bool _active = false;

        [SerializeField] bool _init = false;

        /// <summary>
        /// Nombre del estado. Si no es único, puede generar conflictos.
        /// </summary>
        /// <value>Por defecto cadena vacía</value>
        public string StateName { get => stateName; set => stateName = value; }

        /// <summary>
        /// Indica si es el estado por defecto.
        /// </summary>
        /// <value>Por defecto <c>false</c></value>
        public bool IsDefaultState { get => isDefaultState; set => isDefaultState = value; }

        /// <summary>
        /// Indica si el estado está activo o no.
        /// </summary>
        internal bool Active
        {
            get => _active;
            set
            {
                enabled = value;
                if (_init)
                {
                    if (_active == value) return;
                }
                else
                {
                    _init = true;
                }

                _active = value;
                if (_active) EnterState();
                else ExitState();
            }
        }

        internal void Init(FSMMachine FSMmachine)
        {
            machine = FSMmachine;
        }

        /// <summary>
        /// Se ejecuta al activarse el estado.  
        /// </summary>
        protected abstract void EnterState();

        /// <summary>
        /// Se ejecuta al desactivarse el estado.
        /// </summary>
        protected abstract void ExitState();
    }
}