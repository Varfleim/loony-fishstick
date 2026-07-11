
using UnityEngine;

using GBB;

namespace LF.Initialization
{
    public class Initialization_Submodule : GameSubmodule
    {
        [SerializeField]
        private Initialization_Data initialization_Data;

        public override void Systems_Add(GameStartup startup)
        {
            //Добавляем системы инициализации
            #region PreInit
            //Тестовая инициализация всего
            startup.PreInitSystem_Add(new S_Test_Initialization());

            //Инициализация карты
            startup.PreInitSystem_Add(new S_Map_Initialization());

            //Инициализация субъектов и объектов
            startup.PreInitSystem_Add(new S_SubjectAndObject_Initialization());

            //Инициализация GUI
            startup.PreInitSystem_Add(new S_GUI_Initialization());
            #endregion
        }

        public override void Data_Inject(GameStartup startup)
        {
            //Вводим данные
            startup.Data_Inject(initialization_Data);
        }
    }
}
