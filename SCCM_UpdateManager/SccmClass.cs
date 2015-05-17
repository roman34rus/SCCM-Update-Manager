using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using Microsoft.ConfigurationManagement.ManagementProvider;
using Microsoft.ConfigurationManagement.ManagementProvider.WqlQueryEngine;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SCCM_UpdateManager
{
    // класс для работы с сервером SCCM
    // используется WMI (SMS Provider)
    //
    // Update     - WMI-объект SMS_SoftwareUpdate
    // UpdateList - WMI-объект SMS_AuthorizationList
    // Deployment - WMI-объект SMS_UpdatesAssignment
    class SccmClass
    {
        // подключение к SMS Provider сервера SCCM
        // используется для выполнения WQL-запросов
        private WqlConnectionManager Connection;
        //-------------------------------------------------------

        // поключиться к SMS Provider сервера SCCM
        public bool Connect(string serverName, string userName, string userPassword)
        {
            try
            {
                SmsNamedValuesDictionary namedValues = new SmsNamedValuesDictionary();
                Connection = new WqlConnectionManager(namedValues);
                if (System.Net.Dns.GetHostName().ToUpper() == serverName.ToUpper())
                {
                    Connection.Connect(serverName);
                }
                else
                {
                    Connection.Connect(serverName, userName, userPassword);
                }
                MessageBox.Show("Successfully connected to " + serverName + " as " + userName);
                return true;
            }
            catch (SmsException ex)
            {
                MessageBox.Show("Failed to Connect. Error: " + ex.Message);
                Connection = null;
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Failed to authenticate. Error: " + ex.Message);
                Connection = null;
                return false;
            }
        }
        //-------------------------------------------------------
        
        // получить все UpdateList'ы
        public List<UpdateContainerClass> GetAllUpdateLists()
        {
            IResultObject UpdateLists = ExecQuery("Select * from SMS_AuthorizationList");
            List<UpdateContainerClass> Containers = new List<UpdateContainerClass>();
            foreach (IResultObject UpdateList in UpdateLists)
                Containers.Add(new UpdateContainerClass(0, UpdateList["CI_ID"].IntegerValue, UpdateList["LocalizedDisplayName"].StringValue));
            return Containers;            
        }
        //-------------------------------------------------------
        
        // получить все Deployment'ы    
        public List<UpdateContainerClass> GetAllDeployments()
        {
            IResultObject Deployments = ExecQuery("Select * from SMS_UpdatesAssignment");
            List<UpdateContainerClass> Containers = new List<UpdateContainerClass>();
            foreach (IResultObject Deployment in Deployments)
                Containers.Add(new UpdateContainerClass(1, Deployment["AssignmentID"].IntegerValue, Deployment["AssignmentName"].StringValue));
            return Containers;      
        }
        //-------------------------------------------------------

        // получить список ID Update'ов из UpdateList'а или Deployment'а
        // Type: 0 - UpdateList
        //       1 - Deployment
        // Id:   SMS_AuthorizationList.CI_ID
        //       SMS_UpdatesAssignment.AssignmentID
        public List<int> GetUpdateIds(int Type, int Id)
        {
            List<int> UpdateIds = new List<int>();
            switch (Type)
            {
                // из UpdateList'а
                case 0:
                    IResultObject UpdateLists = ExecQuery("Select * from SMS_AuthorizationList where CI_ID=" + Id.ToString());
                    foreach (IResultObject UpdateList in UpdateLists)
                    {
                        UpdateList.Get(); // получить lazy-свойства
                        UpdateIds.AddRange(UpdateList["Updates"].IntegerArrayValue);
                    }
                    break;
                // из Deployment'а
                case 1:
                    IResultObject Deployments = ExecQuery("Select * from SMS_UpdatesAssignment where AssignmentID=" + Id.ToString());
                    foreach (IResultObject Deployment in Deployments)
                        UpdateIds.AddRange(Deployment["AssignedCIs"].IntegerArrayValue);
                    break;
            }
            return UpdateIds;
        }
        //-------------------------------------------------------

        // сравнить 2 списка ID Update'ов
        // получить список ID Update'ов, которые присутствуют во втором списке, но отсутствуют в первом
        public List<int> CompareUpdateIds(List<int> Ids1, List<int> Ids2)
        {
            List<int> MissIds = new List<int>();
            foreach (int Id2 in Ids2)
                if (!Ids1.Contains(Id2))
                    MissIds.Add(Id2);
            return MissIds;
        }
        //-------------------------------------------------------

        // создать новый UpdateList
        // NewName    - имя
        // NewUpdates - массив ID Update'ов
        public bool CreateUpdateList(string NewName, int[] NewUpdates)
        {
            try
            {
                // подготовительные действия
                List<IResultObject> NewDescriptionInfo = new List<IResultObject>();
                IResultObject SMSCILocalizedProperties = Connection.CreateEmbeddedObjectInstance("SMS_CI_LocalizedProperties");
                SMSCILocalizedProperties["Description"].StringValue = "Created by SCCM UpdateManager";
                SMSCILocalizedProperties["DisplayName"].StringValue = NewName;
                SMSCILocalizedProperties["LocaleID"].StringValue = GetLocaleID().ToString();
                NewDescriptionInfo.Add(SMSCILocalizedProperties);
                // создание UpdateList'а
                IResultObject NewUpdateList = Connection.CreateInstance("SMS_AuthorizationList");
                NewUpdateList["Updates"].IntegerArrayValue = NewUpdates;
                NewUpdateList.SetArrayItems("LocalizedInformation", NewDescriptionInfo);
                NewUpdateList.Put();
                // успешное завершение
                return true;
            }
            catch (SmsException ex)
            {
                MessageBox.Show("Failed to create update list. Error: " + ex.Message);
                return false;
            }
        }
        //-------------------------------------------------------

        // выполнить WQL-запрос
        private IResultObject ExecQuery(string Query)
        {
            try
            {
                return Connection.QueryProcessor.ExecuteQuery(Query);
            }
            catch (SmsException ex)
            {
                MessageBox.Show("Failed to run query. Error: " + ex.Message);
                return null;
            }
        }
        //-------------------------------------------------------

        // получить LocaleID
        private int GetLocaleID()
        {
            IResultObject Identifications = ExecQuery("Select * from SMS_Identification");
            foreach (IResultObject Identification in Identifications)
                    return Identification["LocaleID"].IntegerValue;
            return 0;
        }
        //-------------------------------------------------------
    }
} 
 