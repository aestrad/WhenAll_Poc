Task? task = null;
try
{
    var data = Enumerable.Range(0, 5);
    task =  Task.WhenAll(data.Select(

    async i =>
    {
        await Task.Delay((i + 1) * 1000);
        if (i == 1 || i == 3) throw new Exception($"*** system error No: {i}");

        Console.WriteLine($"Completing Task {i}");

        return i;
    }));

    await task;

}
catch (Exception e)
{

    Console.WriteLine($"Catching {e.Message} {e is AggregateException}");
    Console.WriteLine(value: $"Inspecting {task.Exception.Message} {task.Exception is not null}");
}