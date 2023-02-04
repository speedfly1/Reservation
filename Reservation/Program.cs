// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using Reservation;

string fileName = "ResturentDateTime.json";
string jsonString = string.Empty;
jsonString= File.ReadAllText(fileName);
List<ReservationRequest> resturentReservation = JsonConvert.DeserializeObject<List<ReservationRequest>>(jsonString);


resturentReservation.ForEach(reserv => Reserve(reserv));


async Task Reserve(ReservationRequest reservation)
{
    string json = JsonConvert.SerializeObject(reservation);

    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://host/directory/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.Timeout = TimeSpan.FromSeconds(30.0);

    var response = client.PostAsync("https://ontopo.co.il/api/availability/searchAvailability", content).Result;
    var restring = await response.Content.ReadAsStringAsync();
    var responseAsobject = JsonConvert.DeserializeObject<ReservationResponse>(restring);

    Console.WriteLine(JsonConvert.SerializeObject(responseAsobject, Formatting.Indented));
    Console.WriteLine();

    var m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    using (StreamWriter w = File.AppendText(m_exePath + "\\" + $"log{reservation.criteria.time}.txt"))
    {
        Log(JsonConvert.SerializeObject(responseAsobject, Formatting.Indented), w);
    }
}


void Log(string logMessage, TextWriter txtWriter)
{
    try
    {
        txtWriter.Write("\r\nLog Entry : ");
        txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
            DateTime.Now.ToLongDateString());
        txtWriter.WriteLine("  :");
        txtWriter.WriteLine("  :{0}", logMessage);
        txtWriter.WriteLine("-------------------------------");
    }
    catch (Exception ex)
    {
    }
}