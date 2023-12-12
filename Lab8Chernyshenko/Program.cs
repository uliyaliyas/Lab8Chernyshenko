try
{
    Console.WriteLine("Введите количество поставщиков:");
    int n=int.Parse(Console.ReadLine());
    Sklad[] sklads = new Sklad[n];
    for (int i = 0; i < n; i++)
    {
        sklads[i] = new Sklad();
        Console.Write("Введите дату (дд.мм.гггг): ");
        string dateStr = Console.ReadLine();
        Console.Write("введите название: ");
        string name = Console.ReadLine();
        Console.Write("Введите ФИО: ");
        string FIO = Console.ReadLine();
        Console.Write("Введите время (чч:мм): ");
        string timeStr = Console.ReadLine();
        Console.Write("Вес: ");
        double weight=double.Parse(Console.ReadLine());
    }
    Console.WriteLine("Предполагаемое время разгрузки для каждого поставщика:");
    foreach (var sklad in sklads)
    {
        TimeSpan unloadingTime = sklad.GetUnloadingTime();
        Console.WriteLine($"Поставщик: {sklad.FIO}, Время разгрузки: {sklad.Time + unloadingTime}");
    }
    Console.WriteLine("Информация по поставщикам, планирующим поставку на завтра до 12:00:");
    DateTime tomorrow = DateTime.Today.AddDays(1);
    foreach (var sklad in sklads)
    {
        if (sklad.Date.Date == tomorrow.Date && sklad.Time.Hours < 12)
        {
            Console.WriteLine($"Поставщик: {sklad.FIO}, Дата: {sklad.Date}, Время: {sklad.Time}");
        }
    }

    Console.ReadLine();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
struct Sklad
{
    
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string FIO { get; set; }
    public TimeSpan Time { get; set; }
    public double Weight { get; set; }
    public Sklad(DateTime date, string name, string fio, TimeSpan time, double weight)
        {
            Date = date;
            Name = name;
            FIO = fio;
            Time = time;
            Weight = weight;
        }

    public TimeSpan GetUnloadingTime()
    {
        int minutes = (int)Math.Ceiling(Weight / 100) * 20;
        return TimeSpan.FromMinutes(minutes);
    }
}