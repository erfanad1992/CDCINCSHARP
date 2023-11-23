using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

class Program
{
    static void Main()
    {
        string sqlServerConnectionString = "Server=.;Database=TestSourceDB;Trusted_Connection=True;MultipleActiveResultSets=true";

        using (var tableDependecy = new SqlTableDependency<TestTable>(sqlServerConnectionString, "TestTable"))
        {
            tableDependecy.OnChanged += TableDependency_Changed;
            tableDependecy.OnError += TableDependency_OnError;

            tableDependecy.Start();

            Console.WriteLine("Waiting");

            Console.ReadKey();
            tableDependecy.Stop();
        }
    }

    static void TableDependency_Changed(object sender, RecordChangedEventArgs<TestTable> e)
    {
        Console.WriteLine(Environment.NewLine);
        if (e.ChangeType != ChangeType.None)
        {
            var changeEntity = e.Entity;
            Console.WriteLine("ChangeType: " + e.ChangeType);
            Console.WriteLine("Id: " + changeEntity.Id);
            Console.WriteLine("Name: " + changeEntity.Name);
            Console.WriteLine("Id: " + changeEntity.family);
            Console.WriteLine(Environment.NewLine);
        }
    }

    static void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
    {
        Console.WriteLine(e.Message);
    }
}
    public class TestTable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string family { get; set; }
}
public class __EFMigrationsHistory
{
    public string MigrationId { get; set; }
    public string ProductVersion { get; set; }
}