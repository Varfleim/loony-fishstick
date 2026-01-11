
using UnityEngine;

using GBB;

namespace LF.Agent
{
    public class Agent_Submodule : GameSubmodule
    {
        [SerializeField]
        private AgentData agentData;

        public override void Systems_Add(GameStartup startup)
        {
            //Добавляем системы инициализации
            #region PreInit
            //Создание агентов
            startup.PreInitSystem_Add(new S_Agent_Creation());
            #endregion
            #region PostInit
            //Очистка событий
            startup.PostInitSystem_Add(new S_Events_Clear());
            #endregion

            //Добавляем потиковые системы
            #region PreTick
            //Создание агентов
            startup.PreTickSystem_Add(new S_Agent_Creation());
            #endregion
            #region PostTick
            //Очистка событий
            startup.PostTickSystem_Add(new S_Events_Clear());
            #endregion
        }

        public override void Data_Inject(GameStartup startup)
        {
            //Вводим данные
            startup.Data_Inject(agentData);
        }
    }
}
