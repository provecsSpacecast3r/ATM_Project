using System;
using System.IO;
using FirstProject.Card;
using FirstProject.Persons;
using FirstProject.MenuOptions;


namespace FirstProject.ATM
{
  class CashMachine : EssentialFeatures
  {

    public bool Logging(Person foo, ATMCard input)
    {
        if (input.comparePin(foo.getPin()))
        {
          return true;
        }else
        {
          Console.WriteLine("<--------- Invalid PIN Given (non fare il ladro a casa dei ladri) --------->");
          return false;
        }
    }

    public void Withdraw(Person foo, ATMCard input)
    {
      int amount = 0;
      bool controller = true;
      Console.WriteLine("How much you want to withdraw? (The limit is 1000$)");

      do
      {
        try
        {
            amount = Convert.ToInt32(Console.ReadLine());

            if (amount < 0)
            {
              Console.Write("mistyped input, try again: ");
              controller = false;
            }else {controller = true;}
        }catch(Exception err)
          {
            if (err != null || amount < 0)
            {
              Console.Write("mistyped input, try again: ");
              controller = false;
            }
          }
      }while (!controller);

      Console.WriteLine(input.getBalance());
      var convertedBalance = Convert.ToInt64(input.getBalance());

      if (Logging(foo, input))
      {
        if(convertedBalance < amount)
        {
          Console.WriteLine("<--------- Not enough money --------->");
        }else if (amount > 1000)
        {
          Console.WriteLine("<--------- Withdraw limit is 1000$ --------->");
        }else 
        {
          var onActivity = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
          var updatedBalance = convertedBalance - amount;
          input.updateBalance(updatedBalance.ToString());
          input.updateTrasactionRegister($"Activity on {onActivity}: withdraw of {amount}");
          Console.WriteLine($"\nyour new balance is {input.getBalance()}");
        }
      }
    }

    public void CashAvaiability(ATMCard input)
    {
      Console.WriteLine($"\nyour actual balance is {input.getBalance()}");
    }

    public void LastTransactions(ATMCard input)
    {
      var fi = input.GetLastTransactions();
      FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Read , FileShare.Read); 

      StreamReader sr = new StreamReader(fs);
      
      string fileContent = sr.ReadToEnd();
      
      sr.Close();
      fs.Close();

      Console.WriteLine(fileContent);
    }

    public bool Use(Person foo, ATMCard input)
    {
      var scelta = 0;
      bool controller = true;
      if(Logging(foo, input))
      {
        Menu.options();
        do
        {
            try
            {
              scelta = Convert.ToByte(Console.ReadLine());
  
              if ( scelta < 0 || scelta > 2 )
              {
                Console.Write("\nmistyped input, try again: ");
                controller = false;
              }else {controller = true;}
              
            }catch(Exception err)
              {
                if (err != null)
                {
                  Console.Write("\nmistyped input, try again: ");
                  controller = false;
                }
              }
        }while(!controller);
  
          switch (scelta)
          {
            case 1:
            {
              Withdraw(foo, input);
              System.Threading.Thread.Sleep(5000);
              Console.Clear();
              return true;
            }  
            case 2:
            {
              CashAvaiability(input);
              System.Threading.Thread.Sleep(5000);
              Console.Clear();
              return true;
            }
            case 0:
            {
              Console.Clear();
              return false;
            }
            default: {return false;}       
          }
        }else{return false;}
    }
  }
}
