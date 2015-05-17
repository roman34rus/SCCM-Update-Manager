using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCCM_UpdateManager
{
    // контейнер, содержащий обновления: UpdateList или Deployment
    class UpdateContainerClass
    {
        // конструктор
        public UpdateContainerClass(int _Type, int _Id, string _Name)
        {
            Type = _Type;
            Id = _Id;
            Name = _Name;
        }
        //-------------------------------------------------------

        // тип: 0 - UpdateList
        //      1 - Deployment
        public int Type
        {
            get;
            private set;
        }
        //-------------------------------------------------------

        // ID: SMS_AuthorizationList.CI_ID
        //     SMS_UpdatesAssignment.AssignmentID
        public int Id
        {
            get;
            private set;
        }
        //-------------------------------------------------------
        
        // имя: SMS_AuthorizationList.LocalizedDisplayName
        //      SMS_UpdatesAssignment.AssignmentName
        public string Name
        {
            get;
            private set;
        }
        //-------------------------------------------------------

        // выводимое имя контейнера: тип + имя
        public string DisplayName
        {
            get
            {
                string TypeStr = "";
                switch (Type)
                {
                    case 0: TypeStr = "UpdateList: "; break;
                    case 1: TypeStr = "Deployment: "; break;
                }
                return TypeStr + Name;
            }
        }
        //-------------------------------------------------------
    }
}
