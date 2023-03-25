using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dapasa.FSM
{
    /// <summary>
    /// Clase base para la implementación de una máquina de estados finitos.
    /// En el <c>Awake</c> crea una colección con los estados (scripts que extienden <see cref="FSMState" />)
    /// que tenga asignados el <c>GameObject</c>. No debe sobrescribirse el método <c>Awake</c>. 
    /// Si se necesita ejecutar algo en ese punto, sobrescribir los métodos 
    /// <see cref="BeforeInitStates" /> y/o <see cref="AfterInitStates" />.
    /// </summary>
    /// <remarks>Debe extenderse para ser usada.</remarks>
    public abstract class FSMMachine : MonoBehaviour
    {
        /// <summary>
        /// Evento disparado al cambiar de estado.
        /// Recive por parámetro el estado que se activa y el anterior estado.
        /// </summary>
        /// <param>Nuevo estado</param>
        /// <param>Estado anterior</param>
        public OnChangeStateEvent OnStateChanged;

        Dictionary<Type, FSMState> estados;

        FSMState _state;

        /// <summary>
        /// Estado activo.
        /// </summary>
        public FSMState State
        {
            get => _state;
            set
            {
                if (_state == value) return;
                if (_state != null) _state.Active = false;
                OnStateChanged.Invoke(value, _state);
                _state = value;
                _state.Active = true;
            }
        }

        void Awake()
        {
            BeforeInitStates();
            InitStates();
            AfterInitStates();
        }

        void InitStates()
        {
            FSMState[] _ests = GetComponents<FSMState>();
            FSMState _e = null;
            estados = new Dictionary<Type, FSMState>();
            foreach (FSMState estado in _ests)
            {
                estado.Init(this);
                estados.Add(estado.GetType(), estado);
                if (estado.IsDefaultState) _e = estado;
                else estado.Active = false;
            }
            State = _e == null ? _ests[0] : _e;
        }

        /// <summary>
        /// Sobrescribir para ejecutar código en el <c>Awake</c> antes
        /// de que se inicialicen los estados de la máquina.
        /// </summary>
        protected virtual void BeforeInitStates() { }

        /// <summary>
        /// Sobrescribir para ejecutar código en el <c>Awake</c> después 
        /// de que se inicialicen los estados de la máquina.
        /// </summary>
        protected virtual void AfterInitStates() { }

        /// <summary>
        /// Permite activar un estado según su tipo.
        /// <example>Por ejemplo:
        /// <code>
        /// Maquina.SetStateByType(typeof(Estado));
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="t">Tipo del estado</param>
        /// <exception cref="ArgumentException">Si no existe un estado de ese tipo.</exception>
        public void SetStateByType(Type t)
        {
            if (estados.TryGetValue(t, out FSMState estado))
            {
                State = estado;
            }
            else
            {
                throw new ArgumentException($"No existe un estado {t}");
            }
        }

        /// <summary>
        /// Permite activar un estado según su nombre.
        /// El nombre del estado se especifica con su propiedad <see cref="FSMState.StateName"/>.
        /// Si el nombre del estado no es único, puede generar conflictos.
        /// </summary>
        /// <param name="stateName">Nombre del estado</param>
        /// <exception cref="ArgumentException">Si no existe un estado con ese nombre</exception>
        public void SetStateByName(string stateName)
        {
            foreach (var item in estados.Values)
            {
                if (item.StateName == stateName)
                {
                    State = item;
                    return;
                }
            }
            throw new ArgumentException($"No existe un estado {stateName}");
        }
    }

    [Serializable]
    public class OnChangeStateEvent : UnityEvent<FSMState, FSMState> { }

}