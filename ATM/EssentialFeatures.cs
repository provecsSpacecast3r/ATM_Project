using FirstProject.Card;
using FirstProject.Persons;

interface EssentialFeatures
{
  bool Logging(Person foo, ATMCard input);
  void Withdraw(Person foo, ATMCard input);
  void CashAvaiability(ATMCard input);
  void LastTransactions(ATMCard input);
}