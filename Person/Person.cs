using FirstProject.ATM;
using FirstProject.Card;
using System;

namespace FirstProject.Persons
{
  class Person
  {
    private string _pin;
    private ATMCard _card;

    public Person ()
    {
      this._card = new ATMCard();
      this._pin = wichPin();
    }

    private string wichPin()
    {
      bool controller = true;
      string buffer = "";
      Console.WriteLine("Wich pin are you going to insert? ");

      do
      {
  
        buffer = Console.ReadLine();
  
        try
        {
          Convert.ToInt32(buffer);
          controller = true;
        }catch (Exception err)
        {
          if (err != null)
          {
            Console.Write("mistyped input, try again: ");
            controller = false;
          }
        }
      }while(!controller || buffer.Length != 5);

      
      return buffer;
    }


    public string getPin()
    {
      return this._pin;
    }

    public bool Use(CashMachine machine)
    {
      return machine.Use(this, this._card);
    }

    
  }
}