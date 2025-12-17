
using UnityEngine;

using GBB;

namespace LF.Initialization
{
    public class InitializationSubmodule : GameSubmodule
    {
        [SerializeField]
        private InitializationData initializationData;

        public override void AddSystems(GameStartup startup)
        {
            //Добавляем системы инициализации
            #region PreInit
            //Тестовая инициализация всего
            startup.AddPreInitSystem(new S_Test_Initialization());

            //Инициализация карты
            startup.AddPreInitSystem(new S_Map_Initialization());

            //Инициализация агентов
            startup.AddPreInitSystem(new S_Agent_Initialization());
            #endregion
        }

        public override void InjectData(GameStartup startup)
        {
            //Вводим данные
            startup.InjectData(initializationData);
        }
    }
}
