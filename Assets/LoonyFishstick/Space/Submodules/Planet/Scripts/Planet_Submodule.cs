
using UnityEngine;

using GBB;

namespace LF.Planet
{
    public class Planet_Submodule : GameSubmodule
    {
        [SerializeField]
        private Planet_Data planet_Data;

        public override void Systems_Add(GameStartup startup)
        {
            //Добавляем системы инициализации
            #region PreInit
            //Создание планет
            startup.PreInitSystem_Add(new S_Planet_Creation());
            #endregion
            #region PostInit
            //Очистка событий
            startup.PostInitSystem_Add(new S_Events_Clear());
            #endregion

            //Добавляем потиковые системы
            #region PreTick
            //Создание планет
            startup.PreTickSystem_Add(new S_Planet_Creation());
            #endregion
            #region PostTick
            //Очистка событий
            startup.PreTickSystem_Add(new S_Events_Clear());
            #endregion
        }

        public override void Data_Inject(GameStartup startup)
        {
            //Вводим данные
            startup.Data_Inject(planet_Data);
        }
    }
}