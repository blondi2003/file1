using System.Text;
using System.Text.Encodings;
using System.Text.Encodings.Web;
using System.Text.Json;

    var path = "table.csv";
    //Регистрация провайдера кодировок
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    //регистрация кодировки  для поддержки кириллицы
    Encoding encoding = Encoding.GetEncoding(1251);

var lines = File.ReadAllLines(path);
Console.WriteLine(lines);
var workers = new Worker[lines.Length - 1];

for (int i = 1; i < lines.Length; i++)
{
    var splits = lines[i].Split(';');
    var worker = new Worker();
    worker.Фамилия = splits[0];
    worker.Возраст = Convert.ToDouble(splits[1]);
    worker.Опыт_работы = Convert.ToDouble(splits[2]);
    worker.Заработная_плата = Convert.ToDouble(splits[3]);
    workers[i - 1] = worker;
    //Console.WriteLine(worker);
}
var result = "result.csv";
using (StreamWriter streamWriter = new StreamWriter(result, false, encoding))
{
    streamWriter.WriteLine($"Name;Age;Experience;Wage;Coef;Premium");
    for (int i = 0; i < workers.Length; i++)
    {
        streamWriter.WriteLine(workers[i].ToExcel());
    }
}

var jsonOptions = new JsonSerializerOptions()
{
    Encoder = JavaScriptEncoder.Default
};

var json = JsonSerializer.Serialize(workers, jsonOptions);
File.WriteAllText("result.json", json);

var stringJson = File.ReadAllText("result.json");
var array = JsonSerializer.Deserialize<Worker[]>(stringJson);
foreach (var item in array)
{
    Console.WriteLine(item.ToString());
}

string jsonNewtonsoft = Newtonsoft.Json.JsonConvert.SerializeObject(workers, Newtonsoft.Json.Formatting.Indented);

File.WriteAllText("NewtonsoftResult.json", jsonNewtonsoft);

public class Worker
{
    public string Фамилия { get; set; }
    public double Возраст { get; set; }
    public double Опыт_работы { get; set; }

    public double Заработная_плата { get; set; }

    public double Соотношение_опыта_работы_и_заработной_платы { get => Заработная_плата / Опыт_работы; }
    public double Премия_сотрудника { get => (Опыт_работы * Заработная_плата)/100; }
    public override string ToString()
    {
        return $" {Фамилия}\n Возраст : {Возраст}\n Опыт работы: {Опыт_работы} \n Заработная плата: {Заработная_плата} \n Соотношение опыта работы и заработной платы:{Соотношение_опыта_работы_и_заработной_платы} \n Премия сотрудника:{Премия_сотрудника} рублей\n";
    }

    public string ToExcel()
    {
        return $" {Фамилия};{Возраст};{Опыт_работы};{Заработная_плата};{Соотношение_опыта_работы_и_заработной_платы};{Премия_сотрудника}";

    }
}