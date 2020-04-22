public class Employee
{
  public string Name;
  public int ZipCode;
  public DateTime DateOfBirth;
  public Employee(string name, int zipCode, DateTime dateOfBirth)
  {
      this.Name = name;
      this.ZipCode = zipCode;
      this.DateOfBirth = dateOfBirth;
  }
}

  List<Employee> data = new List<Employee>();
  data.Add(new Employee("Rakesh", 98074, new DateTime(1983, 01, 01)));
  data.Add(new Employee("Rakesh", 98007, new DateTime(1983, 01, 01)));
  data.Add(new Employee("Rakesh", 98007, new DateTime(1983, 01, 01)));
  data.Add(new Employee("Kumar", 98008, new DateTime(1983, 01, 01)));
  data.Add(new Employee("Kumar", 98007, new DateTime(1983, 01, 01)));
  data.Add(new Employee("Gupta", 98007, new DateTime(1983, 01, 01)));
  data.Add(new Employee("Gupta", 98007, new DateTime(1983, 01, 01)));


  var filteredData = data.Where(tmp => tmp.ZipCode == 98007);
  var selectData = data.Select( tmp => tmp.ZipCode).ToList();
  var sortedData = data.OrderBy(tmp => tmp.Name).OrderByDescending( tmp => tmp.ZipCode);

  var multisortedData = data.OrderBy(tmp => tmp.Name).ThenBy(tmp => tmp.ZipCode);

  var groupByData = data
                  .GroupBy(tmp => tmp.Name)
                  .OrderBy(tmp => tmp.Key)
                  .Select(tmp => new { Name = tmp.Key, Duplicate = tmp.Count() })
                  .OrderBy(tmp => tmp.Name)
                  .ThenByDescending(tmp => tmp.Duplicate);

  var groupBy_multipleColumData = data
                  .GroupBy(tmp => new { EName = tmp.Name, PostalCode = tmp.ZipCode })
                  .OrderBy(tmp => tmp.Key.EName)
                  .Select(tmp => new { Name = tmp.Key.EName, ZipCode = tmp.Key.PostalCode, Duplicate = tmp.Count() });
