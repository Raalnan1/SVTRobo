using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace APISite.Controllers
{
    public class Robot
    {
        internal object distance;

        public String robotId { get; set; }
        public Int16 batteryLevel { get; set; }
        public Int16 x { get; set; }
        public Int16 y { get; set; }
    }

    [Route("api/Robots/[controller]")]
    [ApiController]
    public class ClosestController : ControllerBase
    {
        private object getDistance(int x, int y, Robot robot)
        {
            var Distance = Math.Sqrt((Math.Pow(x - robot.x, 2) + Math.Pow(y - robot.y, 2)));
            return Distance;
        }

        // POST: api/<ValuesController>
        [HttpPost]
        public async Task<Robot> AsyncPost(int x, int y)
        {
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://60c8ed887dafc90017ffbd56.mockapi.io/robots");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //            System.Diagnostics.Debug.WriteLine(await response.Content.ReadAsStringAsync());
            string jsonString = await response.Content.ReadAsStringAsync();

            List<Robot> robots = JsonConvert.DeserializeObject<List<Robot>>(jsonString);

            foreach (Robot robot in robots)
            {
                var distance = this.getDistance(x, y, robot);
                robot.distance = distance;
            }

            var sorted = robots.OrderBy(x => x.distance)
                            .ThenByDescending(x => x.batteryLevel)
                            .ToArray();

            return sorted[0];
        }

        // POST: api/<ValuesController>
        [HttpGet]
        public async Task<Robot> AsyncGet(int x, int y)
        {
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://60c8ed887dafc90017ffbd56.mockapi.io/robots");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //            System.Diagnostics.Debug.WriteLine(await response.Content.ReadAsStringAsync());
            string jsonString = await response.Content.ReadAsStringAsync();

            List<Robot> robots = JsonConvert.DeserializeObject<List<Robot>>(jsonString);

            foreach (Robot robot in robots)
            {
                var distance = this.getDistance(x, y, robot);
                robot.distance = distance;
            }

            var sorted = robots.OrderBy(x => x.distance)
                            .ThenByDescending(x => x.batteryLevel)
                            .ToArray();

            return sorted[0];
        }
    }
}
