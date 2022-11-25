using FirstProject.Persons;
using FirstProject.ATM;


namespace FirstProject
{
  class Program 
  {
    public static void Main (string[] args) 
    {
      var foo = new Person();
      var ATM = new CashMachine();

      while(foo.Use(ATM)){}
    }
  }
}