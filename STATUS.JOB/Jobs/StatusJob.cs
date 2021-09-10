using Newtonsoft.Json;
using Quartz;
using STATUS.JOB.Clients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STATUS.JOB.Jobs
{
    class StatusJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var client = new HttpClientUtil("http://localhost:5000/api/StatusServico");
            var getResult = client.GetAsync();
            var json = JsonConvert.SerializeObject(getResult.Result);
            var postResult = client.PostAsync(json);
            await Console.Out.WriteLineAsync($"Última execução às: {DateTime.Now}");
        }
    }
}
