
using UnityEngine;

using GBB;

namespace LF.Initialization
{
    public class Initialization_Submodule : GameSubmodule
    {
        [SerializeField]
        private InitializationData initializationData;

        public override void Systems_Add(GameStartup startup)
        {
            //Добавляем системы инициализации
            #region PreInit
            //Тестовая инициализация всего
            startup.PreInitSystem_Add(new S_Test_Initialization());

            //Инициализация карты
            startup.PreInitSystem_Add(new S_Map_Initialization());

            //Инициализация агентов
            startup.PreInitSystem_Add(new S_Agent_Initialization());
            #endregion
        }

        public override void Data_Inject(GameStartup startup)
        {
            //Вводим данные
            startup.Data_Inject(initializationData);
        }
    }
}
