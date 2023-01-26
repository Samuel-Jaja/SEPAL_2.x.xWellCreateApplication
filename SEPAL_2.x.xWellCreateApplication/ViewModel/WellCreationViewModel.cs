using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using SEPAL_2.x.xWellCreateApplication.Model;
using SEPAL_2.x.xWellCreateApplication.Service;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SEPAL_2.x.xWellCreateApplication.ViewModel
{
    public class WellCreationViewModel:BindableBase
    {
        public WellCreationViewModel()
        {
            CreateWellCommand = new DelegateCommand(CreateWellCommandAction);
        }
        public DelegateCommand CreateWellCommand { get; set; }

        public async void CreateWellCommandAction()
        {
            WellModel wellModel = new WellModel
            {
                WellName = WellName,
                DrainagePoint = DrainagePoint,
                CreatedBy = CreatedBy,
                FieldName = FieldName,
            };

            string wellmodelbytestream = JsonConvert.SerializeObject(wellModel);
            var db = connection.GetDatabase();
            long count = await db.PublishAsync(channel, wellmodelbytestream);

            if (count > 0)
            {
                Helper.MessageResult("The message was published and acknowledged by at least one subscriber.");
            }
            else
            {
                Helper.MessageResult("The message was not acknowledged by any subscribers.");
            }
        }

        private const string redisConnectionString = "127.0.0.1,6379";
        private string channel = "Channel1";
        private ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(redisConnectionString);
        

        private string wellName;
        public string WellName
        {
            get { return wellName; }
            set { wellName = value; RaisePropertyChanged();}
        }

        private string drainagePoint;
        public string DrainagePoint
        {
            get { return drainagePoint; }
            set { drainagePoint = value; RaisePropertyChanged(); }
        }

        private string createdBy;
        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; RaisePropertyChanged(); }
        }

        private string fieldName;
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; RaisePropertyChanged(); }
        }
    }
}
