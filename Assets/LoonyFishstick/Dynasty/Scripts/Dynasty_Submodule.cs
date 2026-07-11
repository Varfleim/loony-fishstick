
using UnityEngine;

using GBB;

namespace LF.Dynasty
{
    public class Dynasty_Submodule : GameSubmodule
    {
        [SerializeField]
        private Dynasty_Data dynasty_Data;

        public override void Systems_Add(GameStartup startup)
        {
            //Добавляем системы инициализации
            #region PreInit
            //Создание династий
            startup.PreInitSystem_Add(new S_Dynasty_Creation());
            #endregion
            #region PostInit
            //Очистка событий
            startup.PostInitSystem_Add(new S_Events_Clear());
            #endregion

            //Добавляем потиковые системы
            #region PreTick
            //Создание династий
            startup.PreTickSystem_Add(new S_Dynasty_Creation());
            #endregion
            #region PostTick
            //Очистка событий
            startup.PreTickSystem_Add(new S_Events_Clear());
            #endregion
        }

        public override void Data_Inject(GameStartup startup)
        {
            //Вводим данные
            startup.Data_Inject(dynasty_Data);
        }
    }
}
