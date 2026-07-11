
using GBB;

namespace LF.Planet.PlanetHexasphere
{
    public class PlanetHexasphere_Interlayer : GameSubmodule
    {
        public override void Systems_Add(GameStartup startup)
        {
            //Добавляем системы инициализации
            #region PreInit
            //Создание гексасфер для планет
            startup.PreInitSystem_Add(new S_Planet_Hexasphere_Creation());
            #endregion

            //Добавляем потиковые системы 
            #region PreTick
            //Создание гексасфер для планет
            startup.PreTickSystem_Add(new S_Planet_Hexasphere_Creation());
            #endregion
        }

        public override void Data_Inject(GameStartup startup)
        {

        }
    }
}
